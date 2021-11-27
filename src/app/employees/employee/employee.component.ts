import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { EmployeeService } from 'src/app/shared/employee.service';
import { ToastrService } from 'ngx-toastr';
import { Employee } from 'src/app/shared/employee';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe } from '@angular/common';
@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  empId:number;
  employee:Employee= new Employee();

 constructor(public empService: EmployeeService,
  private toastrService: ToastrService,
  private router: Router,private route:ActivatedRoute) { }
   ngOnInit(): void {
   
    // this.resetform();
    //getdepartments
    this.empService.BindCmbDepartment();
  //get emp id from activated route
  this.empId=this.route.snapshot.params['EmployeeId'];
  if(this.empId!=0|| this.empId!=null){
    this.empService.getEmployee(this.empId).subscribe(
      data=>{
        console.log(data);
        var datePipe = new DatePipe("en-UK");
        let formatedDate: any = datePipe.transform(data.DateOfJoining, 'yyyy-MM-dd')
        data.DateOfJoining = formatedDate;
        this.empService.formData=data;
      }


    );
  }
   
  }

  onSubmit(form: NgForm) {
    console.log(form.value);
    let addId = this.empService.formData.EmployeeId;
    //insert
    if (addId == 0 || addId == null) {
      this.insertEmployeeRecord(form);
    }
    else {
      this.updateEmployeeRecord(form);
    }
  }
  //Clear all content at Intialization
  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();

    }
  }
  //insert
  insertEmployeeRecord(form?: NgForm) {
    console.log("Inserting a record...");
    console.log(form.value);
    this.empService.insertEmployee(form.value).subscribe(
      (result) => {
        console.log(result);
        this.resetForm(form);
       this.toastrService.success('Employee Record has been Inserted','Employee App');
      }
    );
    window.location.reload();
  }
  //update
  updateEmployeeRecord(form: NgForm) {
    console.log("Updating a record...");
    console.log(form.value);
    this.empService.updateEmployee(form.value).subscribe(
      (result) => {
        console.log(result);
        this.resetForm(form);
       this.toastrService.success('Employee Record has been Updated','Employee App');
      }
    );
    //window.alert("Employee Record has been updated");
    //window.location.reload();
   
  }


}

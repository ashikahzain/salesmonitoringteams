import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Employee } from 'src/app/shared/employee';
import { EmployeeService } from 'src/app/shared/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
  page: number = 1;
  filter: string;
  constructor(public employeeService: EmployeeService,
    private toastrService: ToastrService,
    private router:Router) { }

  ngOnInit(): void {
    this.employeeService.bindListEmployees();
  }
  //populate form by clicking the column
  populateForm(emp: Employee) {
    console.log(emp);
    var datePipe = new DatePipe("en-UK");
    let formatedDate: any = datePipe.transform(emp.DateOfJoining, 'yyyy-MM-dd')
    emp.DateOfJoining = formatedDate;
    this.employeeService.formData = Object.assign({}, emp);
  }
  //update an employee

  updateEmployee(EmployeeId:number){
    console.log(EmployeeId);
    this.router.navigate(['employee',EmployeeId])

  }

}

import { Injectable } from '@angular/core';
import { Employee } from './employee';
import { Department } from './department';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  //create an instance of employee
  formData: Employee = new Employee();
  departments: Department[];
  employees: Employee[];

  constructor(private httpClient: HttpClient) { }

  //Get department for Binding
  BindCmbDepartment() {
    this.httpClient.get(environment.apiUrl + '/api/department/GetDepartments')
      .toPromise().then(
        response => this.departments = response as Department[])
  }

  //insert https://localhost:44332/api/employee/addemployee
  insertEmployee(employee: Employee): Observable<any> {
    console.log("Insertion in service");
    return this.httpClient.post(environment.apiUrl + "/api/employee/addemployee", employee);
  }

  //update
  updateEmployee(employee: Employee): Observable<any> {
    return this.httpClient.put(environment.apiUrl + '/api/employee/updateemployee', employee);
  }

  //delete
  ///deleteEmployee(id: number) {
   // return this.httpClient.put(environment.apiUrl + '/api/employee/updateemployee' , id)
  //}
  //get all employees
  bindListEmployees() {
    this.httpClient.get(environment.apiUrl + "/api/employee/getemployees")
      .toPromise().then(response => this.employees = response as Employee[]);
  }
  //get by id
  getEmployee(EmployeeId: number): Observable<any> {
    return this.httpClient.get(environment.apiUrl + '/api/employee/getemployeebyId?id=' + EmployeeId)
  }
}

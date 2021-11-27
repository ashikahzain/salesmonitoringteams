import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeComponent } from './employees/employee/employee.component';
import { EmployeeListComponent } from './employees/employee-list/employee-list.component';
import { EmployeesComponent } from './employees/employees.component';
import { EditemployeeComponent } from './employees/editemployee/editemployee.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { AdminComponent } from './admin/admin.component';
import { ManagerComponent } from './manager/manager.component';
import { AuthGuard } from './shared/auth.guard';


const routes: Routes = [
  {path:'',redirectTo:"/login",pathMatch:'full'},
  {path:'login' ,component:LoginComponent},
  { path: 'employees', component: EmployeesComponent },
  { path: 'employee', component: EmployeeComponent },
  {path:'editemployee',component:EditemployeeComponent},
  {path:'employee/:EmployeeId',component:EmployeeComponent},
  {path:'employeelist',component:EmployeeListComponent},
  {path:'home',component:HomeComponent},
  {path:'admin',component:AdminComponent,canActivate:[AuthGuard],data:{role:'1'}},
  {path:'manager',component:ManagerComponent,canActivate:[AuthGuard],data:{role:'2'}}
  //route.snapshot.params[]
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient:HttpClient,private router:Router) { }

getUserByPaasword(user:User): Observable<any>{
  console.log(user.UserName);
  console.log(user.Password);
  return this.httpClient.get(environment.apiUrl+'/api/login/getuser/'+user.UserName+'/'+user.Password);
}

public logout(){
  localStorage.removeItem('UserName');
  localStorage.removeItem('ACCESS_ROLE');
  sessionStorage.removeItem('UserName');
  sessionStorage.removeItem('token');
}
public loginVerify(user:User){
console.log("Attempt authorization");
console.log(user);
  return this.httpClient.get(environment.apiUrl+'/api/login/'+user.UserName+'/'+user.Password)
}
}


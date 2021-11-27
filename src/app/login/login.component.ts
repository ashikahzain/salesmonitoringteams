import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../shared/user';
import { AuthService } from '../shared/auth.service'
import {Jwtresponse} from '../shared/jwtresponse'
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  //declare variables
  loginForm: FormGroup;
  isSubmitted = false;
  loginUser: User = new User();
  error = '';
  jwtResponse:any= new Jwtresponse()
  constructor(private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthService) { }

  ngOnInit(): void {
    //formGroup
    this.loginForm = this.formBuilder.group(
      {
        UserName: ['', [Validators.required, Validators.minLength(2)]],
        Password: ['', [Validators.required]]
      }
    );
  }
  //Get controls
  get formControls() {
    return this.loginForm.controls;
  }

  //login Verify Credentials
  loginCredentials() {
    this.isSubmitted = true;
    console.log(this.loginForm.value);

    //valid or invalid
    if (this.loginForm.invalid) {
      return;
    }

   // #region valid form
    if (this.loginForm.valid) {
      //calling methods from service
      this.authService.loginVerify(this.loginForm.value).subscribe(
        data => { console.log(data); 
          this.jwtResponse=data;
          sessionStorage.setItem("jwtToken", this.jwtResponse.token);
          localStorage.setItem("UserName", this.jwtResponse.uName);
          localStorage.setItem("ACCESS_ROLE", this.jwtResponse.RoleId);
         
         if (this.jwtResponse.RoleId===1){
            //LOGGED AS ADMIN
            console.log("Admin");
           
            this.router.navigateByUrl('/admin');
          }
          else if( this.jwtResponse.RoleId===2){
            console.log("Manager");
            sessionStorage.setItem("jwtToken", this.jwtResponse.token);
            sessionStorage.setItem("UserName", this.jwtResponse.uName);
            sessionStorage.setItem("ACCESS_ROLE", this.jwtResponse.RoleId);
            this.router.navigateByUrl('/manager');
          }
          else if(this.jwtResponse.RoleId===3){
            console.log("User");
            sessionStorage.setItem("jwtToken", this.jwtResponse.token);
          sessionStorage.setItem("UserName", this.jwtResponse.uName);
          sessionStorage.setItem("ACCESS_ROLE", this.jwtResponse.RoleId);
            this.router.navigateByUrl('/employee');
          }
          else{
            this.error = "Permission Denied!"
          }

        },
        error => {
          this.error = "Invalid User name or Password. Try Again"
        }
      );
      //check the role based on role id it redirects to respective components
     
    }

    //#region logout

  }
  loginVerifyTest(){
    if (this.loginForm.valid) {
      this.authService.getUserByPaasword(this.loginForm.value).subscribe(
        data=>{
          console.log(data);
        },
        (error)=>{
          console.log(error);
        }
      )
    }
  }


}






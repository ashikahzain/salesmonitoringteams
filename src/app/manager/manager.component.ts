import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';

@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.css']
})
export class ManagerComponent implements OnInit {
  loggeduserName: string;
  constructor(private authservice: AuthService,private router:Router) { }

  ngOnInit(): void {
    this.loggeduserName = localStorage.getItem("UserName");
  }
  logout(){
    this.authservice.logout();
    this.router.navigateByUrl('login');
  }
}

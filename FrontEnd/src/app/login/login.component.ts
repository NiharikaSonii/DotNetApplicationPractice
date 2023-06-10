import { Component } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  email = "";
  password = "";
  errorMsg = "";
  user : any;

  constructor(private http : HttpClient, private router : Router){}

  ngOnInit() {
    if(sessionStorage.getItem("userId") != undefined){
      this.router.navigate(['/planJourney']);
    }
  }

  auth() {
    if(this.email.trim().length == 0 && this.password.trim().length == 0) {
      this.errorMsg = "email and Password are required"
    }
    else if(this.email.trim().length == 0) {
      this.errorMsg = "email is required"
    }
    else if(this.password.trim().length == 0) {
      this.errorMsg = "password is required"
    }
    else {
      this.errorMsg = "";
      this.http.post('https://localhost:7015/api/Users/login', 
      {
        "Email" : this.email,
        "Password" : this.password
      }
      ).subscribe((result)=>{
        console.log(result);

        if(result != null) {
          this.user = result;
          sessionStorage.setItem("userId", this.user.userId);
          sessionStorage.setItem("userfname", this.user.fName);
          sessionStorage.setItem("userlname", this.user.lName);
          this.router.navigate(['/planJourney']);
        }
        else
        this.errorMsg="Invalid Username And Password";
      });
    }

    

  }
 
}

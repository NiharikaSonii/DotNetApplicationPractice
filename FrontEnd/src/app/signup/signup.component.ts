import { Component } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})

export class SignupComponent {

  fname = "";
  lname = "";
  gender = null;
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
    if(this.fname.trim().length == 0) {
      this.errorMsg = "First Name Can not be null";
    }
    else if (this.gender == null) {
      this.errorMsg = "Please choose your gender";
    }
    else if (this.email.trim().length == 0) {
      this.errorMsg = "Please enter the email";
    }
    else if (this.password.trim().length == 0) {
      this.errorMsg = "please enter the password";
    }
    else{
      this.errorMsg="";
      // this.http.post(url, data).subscribe((result) => { console.log(result); });
      this.http.post('https://localhost:7015/api/Users/signup', 
      {
        "Fname" : this.fname,
        "Lname" : this.lname,
        "Gender" : this.gender,
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
      });
    }
  }

}

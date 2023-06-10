import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-booking-page',
  templateUrl: './booking-page.component.html',
  styleUrls: ['./booking-page.component.css']
})
export class BookingPageComponent {
  price = "";
  from ="";
  to = "";
  date = "";
  departure = "";
  arrival = "";
  flight : any;
  fname = "";
  lname ="";
  gender = "";
  age = "";
  mobile = "";
  userId : any;
  passanger :  any;
  booking : any;
  username : any;
  


  constructor(private route: ActivatedRoute, private http : HttpClient, private router: Router) {}

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      const data = params['data']; // Access the data from the query parameters
      console.log(data); // Do something with the data

      this.userId = sessionStorage.getItem("userId");
      this.username = sessionStorage.getItem("userfname");

      this.http.post('https://localhost:7015/api/Timings/getDetailById', {
        "id" : data
      })
      .subscribe((result)=>{
      this.flight = result;
      console.log(this.flight);

      this.price = this.flight.price;
      this.from = this.flight.boarding;
      this.to = this.flight.destination;
      this.date = this.flight.departureDate;
      this.departure = this.flight.departureTime;
      this.arrival = this.flight.arrivalTime;
    });
    });
  }

  passangerDetails() {
    console.log(this.fname + this.lname + this.gender + this.age + this.mobile);
    this.http.post('https://localhost:7015/api/Passanger/AddPassanger',
      {
        "fName": this.fname,
        "lName": this.lname,
        "gender": this.gender,
        "age": this.age,
        "mobile": this.mobile
      }
    ).subscribe((result)=>{
     if(result != null) {
       this.passanger = result;
       console.log(this.passanger);
     }
     else {
      this.router.navigate(['/error']);
     }

     this.http.post('https://localhost:7015/api/Booking/AddBooking', {
      "user": this.userId,
      "passanger": this.passanger.passangerId,
      "date": this.date,
      "timing": this.flight.timingId
    }).subscribe((result)=>{
     if(result != null) {
        this.booking = result;
        console.log(this.booking);  
     }
     else {
      this.router.navigate(['/error']);
     }
    });

    });

    


  }

}
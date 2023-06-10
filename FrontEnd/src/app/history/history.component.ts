import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent {

  bookings : any;
  userId : any;


  constructor( private http : HttpClient, private router: Router) {}

  ngOnInit(){
      this.userId = sessionStorage.getItem("userId");

      this.http.post('https://localhost:7015/api/Booking/getDetailById', {
      "id" : this.userId
      })
      .subscribe((result)=>{
        this.bookings = result;
        console.log(this.bookings);
    });
  }

  CanceBooking(data : any){
    console.log(data);
    this.http.post('https://localhost:7015/api/Booking/CancelBooking',
       {
        "id" : data
       }
      )
      .subscribe((result)=>{
       console.log(result);
       this.router.navigate(['/history']);
    });
  }

}

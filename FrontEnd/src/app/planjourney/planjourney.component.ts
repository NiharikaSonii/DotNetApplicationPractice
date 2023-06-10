import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-planjourney',
  templateUrl: './planjourney.component.html',
  styleUrls: ['./planjourney.component.css']
})
export class PlanjourneyComponent {

  from ="";
  to = "";
  date : any;
  isShowDiv =true;
  errorMsg = "";
  /* getting current date months in java script returns 0 for january and so on incremental */
  Date1 = new Date();

  currentMonth = this.Date1.getUTCMonth()+1;
  currentDate = this.Date1.getDate();
  currentYear = this.Date1.getUTCFullYear();

  todaymonth : any;
  todaydate : any;
  today : any;

  constructor(private http : HttpClient, private router: Router){}
  flights : any;
  // flights =[{departure:'kahi se', arrival:'kahi ko bhi', availableSeats:'10' ,price:'0000', name: 'airindia'},
  // {departure:'idher se', arrival:'udher ko',availableSeats:'2', price:'0001', name: 'emirates'}];

  ngOnInit() : void {

    if(this.currentMonth < 10){
      this.todaymonth = "0"+this.currentMonth;
    }
    else{
      this.todaymonth = this.currentMonth;
    }

    if(this.currentDate < 10){
      this.todaydate = "0"+this.currentDate;
    }
    else {
      this.todaydate = this.currentDate;
    }

    this.today = this.currentYear+"-"+this.todaymonth+"-"+this.todaydate;

  }

  search() {
    console.log("CURRENT DATE AS : "+this.today);
    console.log("INPUT AS : "+this.date);
   
    if(this.from.trim().length == 0){
      this.errorMsg = "Please Provide the Boarding Station";
    }
    else if(this.to.trim().length == 0){
      this.errorMsg = "Please Provide the Destination Station";
    }
    else if(this.date == undefined ){
      this.errorMsg = "please choose a date";
    }
    else{
      this.errorMsg="";
      const d = new Date(this.date);
      console.log("date = "+d.getDate());
      console.log("Month = "+(d.getMonth()+1));
      console.log("year = "+d.getFullYear());
      console.log(this.from);
      console.log(this.to) 

      this.isShowDiv = false;
    }

    this.http.post('https://localhost:7015/api/Timings/GetAirlines', {
      "From" : this.from,
      "To" : this.to,
      "DepartureDate" : this.date
    }).subscribe((result)=>{
      this.flights = result;
      console.log(this.flights);
    });

  }

  BookingReq(data : any){
      console.log(data);
      if(sessionStorage.getItem("userId") == undefined){
        this.router.navigate(['/login']);
      }
      else
      this.router.navigate(['/bookingform'], { queryParams: { data } } );
  }
}

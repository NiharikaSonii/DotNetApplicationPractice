import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';
import { SignupComponent } from './signup/signup.component';
import { PlanjourneyComponent } from './planjourney/planjourney.component';
import { BookingPageComponent } from './booking-page/booking-page.component';
import { HistoryComponent } from './history/history.component';

const routes: Routes = [
  {path: '', redirectTo: 'home', pathMatch: 'full'},
  {path: 'login', component: LoginComponent},
  {path: 'home', component: HomeComponent},
  {path: 'signup', component: SignupComponent},
  {path: 'planJourney', component: PlanjourneyComponent},
  {path: 'bookingform', component: BookingPageComponent},
  {path: 'error', component: PagenotfoundComponent},
  {path: 'history', component: HistoryComponent},
  {path: '**', component: PagenotfoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

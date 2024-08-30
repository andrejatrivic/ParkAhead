import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ParkingsComponent } from './parkings/parkings.component';
import { ParkingSpotsComponent } from './parking-spots/parking-spots.component';
import { LandingComponent } from './landing/landing.component';
import { MapComponent } from './map/map.component'
import { ReservationComponent } from './reservation/reservation.component';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';

import { AuthGuard } from './guards/auth.guard';
import { GuestGuard } from './guards/guest.guard';

const routes: Routes = [
  { path: 'landing', component: LandingComponent },
  { path: 'parkings', component: ParkingsComponent },
  { path: 'reservations', component: ReservationComponent },
  //{ path: 'reservations', component: ReservationComponent, canActivate: [AuthGuard] },
  { path: 'parking-spots', component: ParkingSpotsComponent },
  { path: 'map', component: MapComponent },
  { path: 'user', component: UserComponent },
  { path: 'login', component: LoginComponent, canActivate: [GuestGuard] },
  { path: 'registration', component: RegistrationComponent, canActivate: [GuestGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

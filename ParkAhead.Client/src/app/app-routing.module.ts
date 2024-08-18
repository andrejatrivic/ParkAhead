import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ParkingsComponent } from './parkings/parkings.component';
import { ParkingSpotsComponent } from './parking-spots/parking-spots.component';
import { LandingComponent } from './landing/landing.component';

const routes: Routes = [
  { path: 'landing', component: LandingComponent },
  { path: 'parkings', component: ParkingsComponent },
  { path: 'parking-spots', component: ParkingSpotsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

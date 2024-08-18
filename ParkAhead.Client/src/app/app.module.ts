import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module'; 

import { AppComponent } from './app.component';
import { ParkingSpotsComponent } from './parking-spots/parking-spots.component';
import { ParkingSpotService } from './services/parking-spot.service';

@NgModule({
  declarations: [
    AppComponent,
    ParkingSpotsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule 
  ],
  providers: [ParkingSpotService],
  bootstrap: [AppComponent]
})
export class AppModule { }

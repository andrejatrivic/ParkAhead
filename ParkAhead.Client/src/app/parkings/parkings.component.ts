import { Component, OnInit } from '@angular/core';
import { ParkingService } from '../services/parkings.service';
import { Parking } from '../parkings/parking.interface';

@Component({
  selector: 'app-parkings',
  templateUrl: './parkings.component.html',
  styleUrls: ['./parkings.component.css']
})
export class ParkingsComponent implements OnInit {
  parkings: Parking[] = [];
  constructor(private parkingService: ParkingService) { }

  ngOnInit(): void {
    this.parkingService.getParkings().subscribe((parkings) => {
      this.parkings = parkings;
    });
  }
}

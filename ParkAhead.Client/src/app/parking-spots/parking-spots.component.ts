import { Component, OnInit } from '@angular/core';
import { ParkingSpotService } from '../services/parking-spot.service';
import { ParkingSpot } from './parking-spots.interface';

@Component({
  selector: 'app-parking-spots',
  templateUrl: './parking-spots.component.html',
  styleUrls: ['./parking-spots.component.css']
})
export class ParkingSpotsComponent implements OnInit {
  parkingSpots: ParkingSpot[] = [];

  constructor(private parkingSpotService: ParkingSpotService) { }

  ngOnInit(): void {
    this.parkingSpotService.getParkingSpots().subscribe((parkingSpots) => {
      this.parkingSpots = parkingSpots;
    });
  }
}

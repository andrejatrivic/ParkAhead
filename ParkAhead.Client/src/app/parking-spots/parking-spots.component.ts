import { Component, OnInit } from '@angular/core';
import { ParkingSpotService } from '../services/parking-spot.service';
import { ParkingService } from '../services/parkings.service';
import { ParkingSpot } from './parking-spots.interface';
import { Parking } from '../parkings/parking.interface';

@Component({
  selector: 'app-parking-spots',
  templateUrl: './parking-spots.component.html',
  styleUrls: ['./parking-spots.component.css']
})
export class ParkingSpotsComponent implements OnInit {
  parkingSpots: ParkingSpot[] = [];
  parkings: Parking[] = [];
  selectedParkingId: number | null = null;

  constructor(private parkingSpotService: ParkingSpotService,
              private parkingService: ParkingService) { }

  ngOnInit(): void {
    this.parkingService.getParkings().subscribe((parkings) => {
      this.parkings = parkings;
    });
  }

  getRowClass(statusId: number): string {
    switch (statusId) {
      case 1:
        return 'status-green';
      case 2:
        return 'status-red';
      case 3:
        return 'status-orange';
      default:
        return '';
    }
  }

  onParkingChange(event: Event): void {
    const target = event.target as HTMLSelectElement;
    const parkingId = Number(target.value);
    this.selectedParkingId = parkingId;
    this.fetchParkingSpots(parkingId);
  }

  fetchParkingSpots(parkingId: number): void {
    this.parkingSpotService.getParkingSpotsSpotId(parkingId).subscribe((parkingSpots) => {
      this.parkingSpots = parkingSpots;
    });
  }
}

import { Component } from '@angular/core';
import { ParkingService } from '../services/parkings.service';
import { ParkingSpotService } from '../services/parking-spot.service';
import { Parking } from '../parkings/parking.interface';
import { ParkingSpot } from '../parking-spots/parking-spots.interface';

@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.css']
})
export class ReservationComponent {
  parkings: Parking[] = [];
  selectedParkingImage: string | null = null;
  parkingSpots: ParkingSpot[] = [];
  selectedParkingId: number | null = null;

  constructor(private parkingSpotService: ParkingSpotService, private parkingService: ParkingService) { }

  ngOnInit(): void {
    this.parkingService.getParkings().subscribe((parkings) => {
      this.parkings = parkings;
      if (this.parkings.length > 0) {
        // Initialize with the first parking
        this.selectedParkingId = this.parkings[0].id;
        this.selectedParkingImage = this.parkings[0].imageUrl;
        this.fetchParkingSpots(this.selectedParkingId);
      }
    });
  }

  onParkingSelect(event: Event): void {
    const selectElement = event.target as HTMLSelectElement;
    const selectedImageUrl = selectElement.value;
    const selectedParking = this.parkings.find(parking => parking.imageUrl === selectedImageUrl);

    if (selectedParking) {
      this.selectedParkingImage = selectedImageUrl;
      this.selectedParkingId = selectedParking.id;
      this.fetchParkingSpots(this.selectedParkingId);
    }

    console.log('Selected parking:', selectedParking);
  }

  fetchParkingSpots(parkingId: number): void {
    console.log('Fetching parking spots for parking ID:', parkingId);
    this.parkingSpotService.getParkingSpotsParkingId(parkingId).subscribe((parkingSpots) => {
      this.parkingSpots = parkingSpots;
      console.log('Fetched parking spots:', this.parkingSpots);
    });
  }

  getSpotColor(spot: ParkingSpot): string {
    switch (spot.statusId) {
      case 1: // Available
        return 'green';
      case 2: // Occupied
        return 'red';
      case 3: // Reserved
        return 'orange';
      default:
        return 'gray';
    }
  }

  onSpotClick(spot: ParkingSpot): void {
    // Example logic for click event
    spot.statusId = 4; // Change status ID to a new value representing the clicked state
    console.log('Clicked on spot:', spot);
  }
}

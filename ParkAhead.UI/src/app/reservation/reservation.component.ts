import { Component, AfterViewInit, ElementRef, ViewChild } from '@angular/core';
import { ParkingService } from '../services/parkings.service';
import { ParkingSpotService } from '../services/parking-spot.service';
import { ReservationService } from '../services/reservation.service';
import { Parking } from '../parkings/parking.interface';
import { ParkingSpot } from '../parking-spots/parking-spots.interface';

@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.css']
})
export class ReservationComponent implements AfterViewInit {
  parkings: Parking[] = [];
  selectedParkingImage: string | null = null;
  parkingSpots: ParkingSpot[] = [];
  selectedParkingId: number | null = null;
  imageWidth: number = 0;
  imageHeight: number = 0;
  selectedSpot: ParkingSpot | null = null;
  registrationPlate: string = '';

  @ViewChild('imageElement') imageElement: ElementRef<HTMLImageElement> | undefined;

  constructor(
    private parkingSpotService: ParkingSpotService,
    private parkingService: ParkingService,
    private reservationService: ReservationService
  ) { }

  ngOnInit(): void {
    this.parkingService.getParkings().subscribe((parkings) => {
      this.parkings = parkings;

      if (this.parkings.length > 0) {
        this.selectedParkingId = this.parkings[0].id;
        this.selectedParkingImage = this.parkings[0].imageUrl;
        this.fetchParkingSpots(this.selectedParkingId);
      }
    });
  }

  ngAfterViewInit(): void {
    this.updateImageDimensions();
  }

  onParkingSelect(event: Event): void {
    const selectElement = event.target as HTMLSelectElement;
    const selectedImageUrl = selectElement.value;
    const selectedParking = this.parkings.find(parking => parking.imageUrl === selectedImageUrl);

    if (selectedParking) {
      this.selectedParkingImage = selectedImageUrl;
      this.selectedParkingId = selectedParking.id;
      this.fetchParkingSpots(this.selectedParkingId);
      this.updateImageDimensions();
    }
  }

  fetchParkingSpots(parkingId: number): void {
    this.parkingSpotService.getParkingSpotsParkingId(parkingId).subscribe((parkingSpots) => {
      this.parkingSpots = parkingSpots;
    });
  }

  getSpotColor(spot: ParkingSpot): string {
    switch (spot.statusId) {
      case 1:
        return 'green';
      case 2:
        return 'red';
      case 3:
        return 'orange';
      default:
        return 'gray';
    }
  }

  onSpotClick(spot: ParkingSpot): void {
    this.selectedSpot = spot;  
  }

  updateImageDimensions(): void {
    if (this.imageElement && this.imageElement.nativeElement) {
      const img = this.imageElement.nativeElement;
      this.imageWidth = img.width;
      this.imageHeight = img.height;
    }
  }

  onImageLoad(): void {
    this.updateImageDimensions();
  }

  onReserveSpot(): void {
    if (!this.selectedSpot?.id) {
      alert("Please select a valid parking spot.");
      return;
    }

    this.reservationService.reserveParkingSpot(this.selectedSpot.id, this.registrationPlate).subscribe(
      (response: string) => {
        if (response !== "FAILED") {
          alert("Succesfull reservation!");
        } else {
          alert("Unsucessful registration.");
        }
      },
      (error) => {
        console.error('Error reserving spot:', error);
        alert("There was an error processing your request.");
      }
    );
  }

  isSpotAvailable(): boolean {
    return this.selectedSpot?.statusId === 1;
  }
}

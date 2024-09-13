import { Component, AfterViewInit, ElementRef, ViewChild } from '@angular/core';
import { ParkingService } from '../services/parkings.service';
import { ParkingSpotService } from '../services/parking-spot.service';
import { ReservationService } from '../services/reservation.service';
import { Parking } from '../parkings/parking.interface';
import { ParkingSpot } from '../parking-spots/parking-spots.interface';
import { Reservation } from './reservation.interface';
 
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
  selectedSpotId: number | null = null;
  myReservedSpot: Reservation | null = null;
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

    this.reservationService.getMyReservation().subscribe(
      (reservation: Reservation) => {
        this.myReservedSpot = reservation;
      },
      (error) => {
        console.error('Error fetching reservation:', error);
      }
    );

    this.getMyReservation();
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
    if (spot.statusId === 1 && spot.id === this.selectedSpotId) {
      return 'hotpink'; 
    }
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
    this.selectedSpotId = spot.id; 
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

  isSpotAvailable(): boolean {
    return this.selectedSpot?.statusId === 1;
  }

  getMyReservation(): void {
    this.reservationService.getMyReservation();
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

          if (this.selectedParkingId) {
            this.fetchParkingSpots(this.selectedParkingId);
          }
          this.selectedSpot = null;
          this.getMyReservation();
        } else {
          alert("Unsucessful reservation.");
        }
      },
      (error) => {
        console.error('Error reserving spot:', error);
        alert("There was an error processing your request.");
      }
    );
  }

  onCancelReservation(reservationId: number): void {
    this.reservationService.cancelReservation(reservationId).subscribe(
      (response: string) => {
        if (response === "TIMEOUT") {
          alert("You can't cancel the reservation after 5 minutes!");
        }
        else if (response !== "FAILED") {
          alert("Succesfull canceled reservation!");

          if (this.selectedParkingId) {
            this.fetchParkingSpots(this.selectedParkingId);
          }
          this.selectedSpot = null;
          this.getMyReservation();
        } 
        else {
          alert("Unsucessful canceled reservation.")
        }
      },
      (error) => {
        console.error('Error canceling reservation:', error);
        alert("There was an error processing your request.");
      }
    );
  }

  onArrivedAtParkingSpot(reservationId: number): void {
    this.reservationService.arrivedAtParkingSpot(reservationId).subscribe(
      (response: string) => {
        if (response !== "FAILED") {
          alert("Succesfull arriving at spot!");

          if (this.selectedParkingId) {
            this.fetchParkingSpots(this.selectedParkingId);
          }
          this.selectedSpot = null;
          this.getMyReservation();
        } else {
          alert("Unsucessful arriving at spot.")
        }
      },
      (error) => {
        console.error('Error arriving at spot:', error);
        alert("There was an error processing your request.");
      }
    );
  }
}

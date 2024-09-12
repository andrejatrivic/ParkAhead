import { Component, OnInit } from '@angular/core';
import * as L from 'leaflet';

import { ParkingService } from '../services/parkings.service';
import { ParkingSpotService } from '../services/parking-spot.service';
import { ReservationService } from '../services/reservation.service';
import { Parking } from '../parkings/parking.interface';
import { ParkingSpot } from '../parking-spots/parking-spots.interface';
import { Reservation } from '../reservation/reservation.interface';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {
  private map: L.Map | undefined;
  parkings: Parking[] = [];
  parkingSpots: ParkingSpot[] = [];
  selectedParkingId: number | null = null;

  constructor(
    private parkingSpotService: ParkingSpotService,
    private parkingService: ParkingService,
    private reservationService: ReservationService
  ) { }

  ngOnInit(): void {
    this.initMap();
    this.initParkingSelect();
  }

  private initMap(): void {
    this.map = L.map('map', {
      center: [45.749050, 15.996592],
      zoom: 11
    });

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      maxZoom: 20,
      attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(this.map);
  }

  private initParkingSelect(): void {
    this.parkingService.getParkings().subscribe((parkings) => {
      this.parkings = parkings;

      if (this.parkings.length > 0) {
        this.selectedParkingId = this.parkings[0].id;
        this.fetchParkingSpots(this.selectedParkingId);
      }
    });
  }

  fetchParkingSpots(parkingId: number): void {
    this.parkingSpotService.getParkingSpotsParkingId(parkingId).subscribe((parkingSpots) => {
      this.parkingSpots = parkingSpots;
      if (this.parkingSpots.length > 0) {
        this.setMarkers(this.parkingSpots);
      }
    });
  }

  onParkingSelect(event: Event): void {
    const selectElement = event.target as HTMLSelectElement;
    const selectedParkingId = Number(selectElement.value);

    if (selectedParkingId) {
      this.selectedParkingId = selectedParkingId;
      this.fetchParkingSpots(this.selectedParkingId);
    }
  }

  setMarkers(parkingSpots: ParkingSpot[]): void {
    if (this.map) {
      this.clearMarkers(); 

      for (const parkingSpot of parkingSpots) {
        const { latitude, longitude, statusId } = parkingSpot;
        const icon = this.setIcon(statusId);
        L.marker([latitude, longitude], { icon }).addTo(this.map); 
      }
    }
  }

  setIcon(statusId: number): L.Icon {
    let iconUrl: string;

    switch (statusId) {
      case 1:
        iconUrl = 'images/green-marker.png';
        break;
      case 2:
        iconUrl = 'images/red-marker.png';
        break;
      case 3:
        iconUrl = 'images/orange-marker.png';
        break;
      default:
        iconUrl = ''; 
    }

    return L.icon({
      iconUrl
    });
  }

  private clearMarkers(): void {
    if (this.map) {
      this.map.eachLayer((layer) => {
        if (layer instanceof L.Marker) {
          this.map?.removeLayer(layer);
        }
      });
    }
  }
}

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
  selectedParkingImage: string | null = null;

  constructor(private parkingService: ParkingService) { }

  ngOnInit(): void {
    this.parkingService.getParkings().subscribe((parkings) => {
      this.parkings = parkings;
      if (this.parkings.length > 0) {
        this.selectedParkingImage = this.parkings[0].imageUrl;
      }
    });
  }

  onParkingSelect(event: Event): void {
    const selectElement = event.target as HTMLSelectElement;
    this.selectedParkingImage = selectElement.value;
  }
}

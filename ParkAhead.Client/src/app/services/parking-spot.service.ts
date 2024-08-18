import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ParkingSpot } from '../parking-spots/parking-spots.interface';

@Injectable({
  providedIn: 'root'
})
export class ParkingSpotService {
  private baseUrl = 'https://localhost:7204/api/ParkingSpot';

  constructor(private http: HttpClient) { }

  getParkingSpots(): Observable<any[]> {
    return this.http.get<ParkingSpot[]>(`${this.baseUrl}/GetParkingsSpots`);
  }
}

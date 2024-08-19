import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Parking } from '../parkings/parking.interface';

@Injectable({
  providedIn: 'root'
})
export class ParkingService {
  private baseUrl = 'https://localhost:7204/api/Parking';

  constructor(private http: HttpClient) { }

  getParkings(): Observable<any[]> {
    return this.http.get<Parking[]>(`${this.baseUrl}/GetParkings`);
  }
}

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CookieService } from 'ngx-cookie-service';
import { Reservation } from '../reservation/reservation.interface'

@Injectable({
  providedIn: 'root'
})
export class ReservationService {
  private baseUrl = 'https://localhost:7204/api/Reservation';
  spotId: number = 0;
  registrationPlate: string = '';

  constructor(private http: HttpClient, private cookieService: CookieService) { }

  reserveParkingSpot(spotId: number, registrationPlate: string): Observable<string> {
    const jwtToken = this.cookieService.get('jwt');

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${jwtToken}`,
      'Accept': 'text/plain'
    });

    const options = {
      headers: headers,
      responseType: 'text' as 'json' 
    };

    return this.http.post<string>(
      `${this.baseUrl}/reservation/${spotId}/${registrationPlate}`,
      '', 
      options
    );
  }

  getMyReservation(): Observable<any> {
    const jwtToken = this.cookieService.get('jwt');

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${jwtToken}`,
      'Accept': 'text/plain'
    });

    return this.http.get<Reservation>(`${this.baseUrl}/my-reservation`, { headers });
  }

  cancelReservation(reservationId: number): Observable<any> {
    const jwtToken = this.cookieService.get('jwt');

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${jwtToken}`,
      'Accept': 'text/plain'
    });

    const options = {
      headers: headers,
      responseType: 'text' as 'json' 
    };

    return this.http.delete(`${this.baseUrl}/reservation/${reservationId}`, options);
  }

  arrivedAtParkingSpot(reservationId: number): Observable<any> {
    const jwtToken = this.cookieService.get('jwt');

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${jwtToken}`,
      'Accept': 'text/plain'
    });

    const options = {
      headers: headers,
      responseType: 'text' as 'json'
    };

    return this.http.put(`${this.baseUrl}/reservation/${reservationId}/arrival`, {}, options);
  }
}

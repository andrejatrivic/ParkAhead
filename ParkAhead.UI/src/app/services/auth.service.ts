import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl = 'https://localhost:7204/api/User';
  passwordHash: string = '';

  constructor(private http: HttpClient) { }

  async login(username: string, password: string): Promise<Observable<any>> {
    const encoder = new TextEncoder();
    const data = encoder.encode(password);
    const hashBuffer = await crypto.subtle.digest('SHA-256', data);
    this.passwordHash = Array.from(new Uint8Array(hashBuffer))
      .map(b => b.toString(16).padStart(2, '0'))
      .join('');

    return this.http.post(`${this.baseUrl}/Login`, { username, passwordHash: this.passwordHash }, { responseType: 'text' });
  }

  async register(username: string, email: string, phoneNumber: string, password: string): Promise<Observable<any>> {
    const encoder = new TextEncoder();
    const data = encoder.encode(password);
    const hashBuffer = await crypto.subtle.digest('SHA-256', data);
    this.passwordHash = Array.from(new Uint8Array(hashBuffer))
      .map(b => b.toString(16).padStart(2, '0'))
      .join('');

    return this.http.post(`${this.baseUrl}/Registration`, { username, email, phoneNumber, passwordHash: this.passwordHash }, { responseType: 'text' });
  }
}

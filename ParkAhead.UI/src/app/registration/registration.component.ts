import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent {
  username: string = '';
  email: string = '';
  phone: string = '';
  password: string = '';

  constructor(private authService: AuthService, private router: Router, private cookieService: CookieService) { }

  async onSubmit(): Promise<void> {
    (await this.authService.register(this.username, this.email, this.phone, this.password)).subscribe(
      (response: string) => {
        if (response !== "FAILED") {
          this.cookieService.set('jwt', response);
          this.router.navigate(['/parking-spots']);
        } else {
          alert('Failed registration.');
        }
      },
      (error: any) => {
        console.error('Registration error:', error);
        alert('Failed registration.');
      }
    );
  }
}

import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';  
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']  
})
export class LoginComponent {
  username: string = '';
  password: string = '';

  constructor(private authService: AuthService, private router: Router, private cookieService: CookieService) { }

  async onSubmit(): Promise<void> {
    (await this.authService.login(this.username, this.password)).subscribe(
      (response: string) => {
        console.log("response: " + response);

        if (response !== "FAILED") {
          this.cookieService.set('jwt', response);
          this.router.navigate(['/parking-spots']);
        } else {
          alert('Greška kod prijave.');
        }
      },
      (error: any) => {
        console.error('Login error:', error);
        alert('Greška kod prijave.');
      }
    );
  }
}

import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  isLoggedIn: boolean = false;
  constructor(private cookieService: CookieService, private router: Router) {
    this.isLoggedIn = this.cookieService.check('jwt');
  }

  logout() {
    this.cookieService.delete('jwt');
    this.isLoggedIn = false;
    this.router.navigate(['/login']);
  }

  ngOnInit() {
  }

  title = 'ParkAhead.UI';
}

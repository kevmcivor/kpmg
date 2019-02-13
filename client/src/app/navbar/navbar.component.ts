import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  isNavbarCollapsed = true;

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  isLoggedIn() {
    return this.authService.isLoggedIn();
  }
}

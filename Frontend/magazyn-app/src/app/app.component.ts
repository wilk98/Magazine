import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  isUserLoggedIn: boolean = false;
  currentUserEmail?: string;

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit() {
    this.authService.currentUser.subscribe(user => {
      this.isUserLoggedIn = !!user;
      this.currentUserEmail = user?.email || undefined; 
    });
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}

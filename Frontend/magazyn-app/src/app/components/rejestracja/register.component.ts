import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConfig } from '../../config/app.config';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: 'register.component.html',
})
export class RegisterComponent {
  registerModel = {
    email: '',
    password: ''
  };
  message: string | null = null;

  constructor(private http: HttpClient, private router: Router) {}

  onRegister(): void {
    this.http.post(`${AppConfig.apiUrl}account/register`, this.registerModel).subscribe({
      next: (response) => {
        console.log('Rejestracja zakończona sukcesem', response);
        this.message = 'Rejestracja zakończona sukcesem. Możesz się teraz zalogować.';
        this.router.navigate(['/magazyny']);
      },
      error: (error) => {
        console.error('Wystąpił błąd podczas rejestracji', error);
        this.message = 'Wystąpił błąd podczas rejestracji. Spróbuj ponownie.';
      }
    });
  }
}

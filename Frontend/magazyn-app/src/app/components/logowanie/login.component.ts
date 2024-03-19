import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent {
  loginModel = {
    email: '',
    password: ''
  };

  message: string | null = null;

  constructor(private authService: AuthService, private router: Router) {}

  onLogin(): void {
    this.authService.login(this.loginModel.email, this.loginModel.password).subscribe({
      next: (response) => {
        this.message = 'Zalogowano pomyślnie';
        this.router.navigate(['/magazyny']);
      },
      error: (error) => {
        this.message = 'Błąd logowania. Sprawdź dane logowania i spróbuj ponownie.';
      }
    });
  }
}

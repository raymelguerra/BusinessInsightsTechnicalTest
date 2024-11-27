import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
import { environment } from '../environments/environment';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HttpClientModule, CommonModule, FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'FizzBuzz.WebApp';

  randomNumber: number = this.getRandomNumber();
  limit: number | null = null;
  result: string[] | null = null;

  constructor(private http: HttpClient) {}

  getRandomNumber(): number {
    return Math.floor(Math.random() * 100) + 1; // Número entre 1 y 100
  }

  generateRandomNumber(): void {
    this.randomNumber = this.getRandomNumber();
  }

  sendData(): void {
    if (!this.limit || this.limit <= 0) {
      alert('Por favor, ingresa un límite válido.');
      return;
    }

    const payload = { startNumber: this.randomNumber, limit: this.limit };
    this.http.post<string[]>(`${environment.apiUrl}/FizzBuzz/generate`, payload).subscribe({
      next: (response) => (this.result = response),
      error: (err) => alert('Ocurrió un error al procesar la solicitud.'),
    });
  }
  
}

import { Component, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-data',
  standalone: true,
  imports: [CommonModule],
  template: `
    <h2>Data from the backend:</h2>
    <ul>
      @for (item of data; track item) {
        <li>{{ item }}</li>
      }
    </ul>
  `,
})
export class DataComponent {
  data: string[] = [];
  private http = inject(HttpClient);

  constructor() {
    this.http.get<string[]>('https://localhost:7278/data').subscribe((response) => {
      this.data = response;
    });
  }
}

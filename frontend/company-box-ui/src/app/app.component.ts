import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'company-box-ui';

  private http = inject(HttpClient);
  
  ngOnInit(): void {
    console.log('trying to call backend...');
    const apiUrl = 'http://localhost:8080/api/test/ping'; 
  }


}

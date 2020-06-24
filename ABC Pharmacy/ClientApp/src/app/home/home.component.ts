import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {
  public medicines: Medicine[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Medicine[]>(baseUrl + 'pharmacy').subscribe(result => {
      this.medicines = result;
      this.medicines.forEach(function (value) {
        const oneDay = 24 * 60 * 60 * 1000; // hours*minutes*seconds*milliseconds
        const today = Date.now();
        var expDate = new Date(value.expiryDate);

        const diffDays = Math.round(Math.abs((today - expDate.getTime()) / oneDay));
        if (diffDays < 30) {
          value.expiryalert = true;
        }
      }); 
    }, error => console.error(error));
  }
}

interface Medicine {
  fullName: string;
  brand: number;
  price: number;
  quantity: number;
  expiryDate: Date;
  notes: string;
  expiryalert: boolean;
}

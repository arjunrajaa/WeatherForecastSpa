import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WeatherService } from '../services/weather.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  loc: any;
  currentWeather: any = <any>{};
  forecastWeather: any = <any>{};
  msg!: string;

  constructor(private weatherService: WeatherService) {
  }
  ngOnInit() {
  }
  searchWeather() {
    this.msg = '';
    this.currentWeather = {};
    this.forecastWeather = {};
    this.weatherService.getCurrentWeather(this.loc)
      .subscribe(res => {
        this.currentWeather = res;
      }, err => {
        if (err.error && err.error.message) {
          alert(err.error.message);
          this.msg = err.error.message;
          return;
        }
        alert('Failed to get weather.');
      }, () => {
      })
    this.weatherService.getForecast(this.loc)
      .subscribe(res => {
        this.forecastWeather = res;
      }, err => {
        if (err.error && err.error.message) {
          alert(err.error.message);
          this.msg = err.error.message;
          return;
        }
        alert('Failed to get forecasted weather.');
      }, () => {
      })
  }
  resultFound() {
    return Object.keys(this.currentWeather).length > 0;
  }
}

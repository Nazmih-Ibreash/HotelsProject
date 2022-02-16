import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'

import { AppComponent } from './app.component';
import { HotelService } from './services/hotel.service';
import HotelListView from './views/hotelListView.component';

@NgModule({
  declarations: [
        AppComponent,
        HotelListView
  ],
  imports: [
      BrowserModule,
      HttpClientModule
  ],
    providers: [
        HotelService,
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }

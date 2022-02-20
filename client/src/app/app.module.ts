import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';


import { AppComponent } from './app.component';
import { HotelService } from './services/hotel.service';
import  HotelListView  from './views/hotelListView.component';
import { CartView } from './views/cartView.component';
import { Checkout } from './pages/checkout.component';
import { ShopPage } from './pages/shopPage.component';
import router from './router';
import { FormsModule } from '@angular/forms';
import { StarComponent } from './shared/star.component';


@NgModule({
  declarations: [
        AppComponent,
        HotelListView,
        CartView,
        ShopPage,
        Checkout,
        StarComponent
  ],
  imports: [ 
      BrowserModule,
      FormsModule,
      HttpClientModule,
      router
  ],
    providers: [
        HotelService,

    ],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { Component } from "@angular/core";
import { HotelService } from "../services/hotel.service";


@Component({
  selector: "checkout",
  templateUrl: "checkout.component.html",
  styleUrls: ['checkout.component.css']
})
export class Checkout {

    constructor(public hotelService: HotelService) {
  }

  onCheckout() {
    // TODO
    alert("Doing checkout");
  }
}
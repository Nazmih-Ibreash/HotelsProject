import { Component } from "@angular/core";
import { HotelService } from "../services/hotel.service";

@Component({
    selector: "cart",
    templateUrl: "cartView.component.html",
    styleUrls: ["cartView.component.css"]
})
export class CartView {
    constructor(public hotelService: HotelService) {

    }
}
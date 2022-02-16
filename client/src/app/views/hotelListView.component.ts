import { OnInit } from "@angular/core";
import { Component } from "@angular/core";
import { HotelService } from "../services/hotel.service";
import { Hotels } from "../shared/Hotel";


@Component({
    selector: "hotel-list",
    templateUrl: "hotelListView.component.html"
})
export default class HotelListView implements OnInit {
    public hotels: Hotels[] = [];

    constructor(private hotelService: HotelService) {
        this.hotels = hotelService.hotels;
    }

    ngOnInit(): void {
        this.hotelService.getHotels().subscribe();
    }


}
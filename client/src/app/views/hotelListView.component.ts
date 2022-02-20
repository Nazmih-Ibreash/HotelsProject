import { OnInit } from "@angular/core";
import { Component } from "@angular/core";
import { HotelService } from "../services/hotel.service";
import { Hotels } from "../shared/Hotel";


@Component({
    selector: "hotel-list",
    templateUrl: "hotelListView.component.html",
    styleUrls: ["hotelListView.component.css"]
})
export default class HotelListView implements OnInit {
    public hotels: Hotels[] = [];
    public _searchFilter: string = "";
    public filteredHotels: Hotels[] = [];

    constructor(public hotelService: HotelService) {
        this.hotels = hotelService.hotels;
        this.filteredHotels = this.hotels;
    } 

    ngOnInit(): void {
        this.hotelService.getHotels().subscribe();
    }


}
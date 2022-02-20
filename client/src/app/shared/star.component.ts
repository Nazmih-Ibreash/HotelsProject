import { Component, EventEmitter, Input, OnChanges } from "@angular/core";
import { HotelService } from "../services/hotel.service";
@Component({
    selector: 'pm-star',
    templateUrl: './star.component.html',
    styleUrls: ['./star.component.css']
})
export class StarComponent implements OnChanges {
    @Input() rating!: number;
    cropWidth: number = 75;

    constructor(public hotelService: HotelService) {}

    ngOnChanges(): void {
        this.cropWidth = this.rating * 75 / 5;
    }
}

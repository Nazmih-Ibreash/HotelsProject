import { Component, EventEmitter, Input, OnChanges } from "@angular/core";

@Component({
    selector: 'pm-star',
    templateUrl: './star.component.html',
    styleUrls: ['./star.component.css']
})
export class StarComponent implements OnChanges {
    @Input() rating!: number;
    cropWidth: number = 100;

    constructor() { }

    ngOnChanges(): void {
        this.cropWidth = this.rating * 100 / 5;
    }
}

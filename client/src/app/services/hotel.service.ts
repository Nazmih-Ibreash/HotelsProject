import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { Hotels } from "../shared/Hotel";

@Injectable()
export class HotelService {
    constructor(private http: HttpClient) {

    }

    public hotels: Hotels[] = [];

    getHotels() {
        return this.http.get<[]>("/api/hotels")
            .pipe(map(data => {
                this.hotels = data;
            }))
    }

}
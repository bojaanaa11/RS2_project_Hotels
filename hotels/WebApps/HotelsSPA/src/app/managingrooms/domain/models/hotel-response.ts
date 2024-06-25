import { IRoomResponse } from "./room-response";

export interface IHotelResponse {
    id: string;
    name: string;
    address: string;
    city: string;
    country: string;
    fileImages: Array<string>;
    rooms: Array<IRoomResponse>;
    //description: string;
}
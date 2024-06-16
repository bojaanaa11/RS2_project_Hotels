import { IRoomResponse } from "./room-response";

export interface IHotelResponse {
    id: string;
    name: string;
    address: string;
    city: string;
    country: string;
    fileimages: Array<string>;
    rooms: Array<IRoomResponse>;
}
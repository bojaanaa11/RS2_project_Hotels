import { IRoom } from "./room";

export interface IHotel {
    id: string;
    name: string;
    address: string;
    city: string;
    country: string;
    fileImages: string[];
    rooms: IRoom[];
    //description: string;
}
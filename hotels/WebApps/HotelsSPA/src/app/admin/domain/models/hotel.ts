import { IRoom } from "./room";

export interface IHotel {
    id: string;
    name: string;
    address: string;
    city: string;
    country: string;
    fileImages: Array<string>;
    rooms: Array<IRoom>;
    description: string;
}
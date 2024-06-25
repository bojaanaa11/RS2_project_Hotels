export interface IRoom {
    id: string;
    hotelId: string;
    roomNumber: string;
    status: boolean;
    price: number;
    fileImages: string[];
    description: string;
}
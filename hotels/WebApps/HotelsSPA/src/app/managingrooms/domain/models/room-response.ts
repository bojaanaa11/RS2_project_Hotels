export interface IRoomResponse {
    id: string;
    hotelid: string;
    roomnumber: string;
    status: boolean;
    price: number;
    fileImages: Array<string>;
    description: string;
}
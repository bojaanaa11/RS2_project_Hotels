export interface IRoomResponse {
    id: string;
    hotelid: string;
    roomnumber: string;
    status: boolean;
    price: number;
    fileimages: Array<string>;
    description: string;
}
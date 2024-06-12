import { IHotelRating } from "./hotel-rating";

export interface INewRatingRequest {
    hotelId: string,
    hotelName: string,
    guestId: string,
    reservationId: string,
    hotelRating: IHotelRating

}
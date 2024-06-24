export interface IHotelReview {
    id: number,
    hotelId: string,
    hotelName: string,
    guestId: string,
    reservationId: string,
    rating: number,
    comment: string,
    ratingDate: string | undefined
}
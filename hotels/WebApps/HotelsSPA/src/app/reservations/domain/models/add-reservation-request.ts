export interface IAddReservationRequest {
    id: string;                     // generate it
    userId: string;                 // same as username
    hotelId: string;                // take from managing rooms
    hotelName: string;              // take from managing rooms
    roomId: string;                 // take from managing rooms
    bookingDateTime: string;        // take current date and time
    startDateTime: string;          // user enters it 
    endDateTime: string;            // user enters it
    status: string;                 // if user clicks reserve status is "Booked" or "Confirmed" (later if he cancels change this to "Canceled") 
}
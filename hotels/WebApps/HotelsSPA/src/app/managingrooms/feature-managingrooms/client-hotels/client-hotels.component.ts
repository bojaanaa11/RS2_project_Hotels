import { Component, OnInit } from '@angular/core';
import { HotelFacadeService } from '../../domain/application-services/hotel-facade.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-client-hotels',
  templateUrl: './client-hotels.component.html',
  styleUrl: './client-hotels.component.css'
})
export class ClientHotelsComponent implements OnInit {
  
  constructor(private hotelService: HotelFacadeService, private router: Router) {}

  url = 'http://localhost:4200/managingrooms';

  ngOnInit(): void {
    this.hotelService.getAllHotels().subscribe((response:any) => {
      this.hotels = response;
      console.log(this.hotels);
    })
  }

  hotels = [
    {
      id: "1",
      name: "Hotel1",
      address: "Francuska 3",
      city: "Belgrade",
      country: "Serbia",
      fileimages: "https://images.app.goo.gl/3KYYJ6iTfQcMLPX76",
      rooms: [
        {
          id: "1",
          hotelid: "1",
          roomnumber: "100",
          status: "available",
          price: 5000,
          fileimages: ["https://images.app.goo.gl/bYd4SssnTLq6rMQaA", "https://images.app.goo.gl/bYd4SssnTLq6rMQaA"],
          description: "Dvokrevetna soba sa terasom."
        },
        {
          id: "2",
          hotelid: "1",
          roomnumber: "101",
          status: "available",
          price: 5000,
          fileimages: ["https://images.app.goo.gl/bYd4SssnTLq6rMQaA", "https://images.app.goo.gl/bYd4SssnTLq6rMQaA"],
          description: "Dvokrevetna soba sa pogledom na Kalemegdan."

        }
      ],
      description: "Hotel je u samom centru grada"
    },
    {
      id: "2",
      name: "Hotel2",
      address: "Spanskih boraca 53",
      city: "Belgrade",
      country: "Serbia",
      fileImages: "https://images.app.goo.gl/Q66tqjqdmybocV6a7",
      rooms: [
        {
          id: "3",
          hotelid: "2",
          roomnumber: "100",
          status: "available",
          price: 5000,
          fileimages: ["https://images.app.goo.gl/bYd4SssnTLq6rMQaA", "https://images.app.goo.gl/bYd4SssnTLq6rMQaA"],
          description: "Dvokrevetna soba sa terasom."
        },
        {
          id: "4",
          hotelid: "2",
          roomnumber: "100",
          status: "available",
          price: 5000,
          fileimages: ["https://images.app.goo.gl/bYd4SssnTLq6rMQaA", "https://images.app.goo.gl/bYd4SssnTLq6rMQaA"],
          description: "Dvokrevetna soba sa terasom."
        }
      ],
      description: "Hotel je u samom centru grada"
    }
  ];

  goToRoomComponent(hotelId: string) {
    sessionStorage.setItem('hotelId', hotelId);
    this.router.navigate([this.url + '/client-rooms'])
  }

}

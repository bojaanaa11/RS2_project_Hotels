import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HotelFacadeService } from '../../domain/application-services/hotel-facade.service';
import { IHotel } from '../../domain/models/hotel';

@Component({
  selector: 'app-update-hotel',
  templateUrl: './update-hotel.component.html',
  styleUrl: './update-hotel.component.css'
})
export class UpdateHotelComponent {
  hotelForm: FormGroup;
  hotelId: string;

  constructor(private hotelService: HotelFacadeService, private router: Router) {
    const hotel: IHotel = this.hotelForm.value;
    this.hotelForm = new FormGroup({
      id: new FormControl(hotel.id, Validators.required),
      name: new FormControl(hotel.name, Validators.required),
      address: new FormControl(hotel.address, Validators.required),
      city: new FormControl(hotel.city, Validators.required),
      country: new FormControl(hotel.country, Validators.required),
      fileimages: new FormControl(hotel.fileImages, Validators.required),
      rooms: new FormControl(hotel.rooms, Validators.required),
      description: new FormControl(hotel.description, Validators.required),
    })
  }

  ngOnInit(): void {
    
  }

  public UpdateHotel(): void {
    if (this.hotelForm.invalid) {
      window.alert('Form has errors!');
      return;
    }

    const hotel: IHotel = this.hotelForm.value;

    this.hotelService.UpdateHotel(hotel).subscribe((response: any) => {
      console.log(`Hotel successfully updated`);
      window.alert(`Hotel successfully updated!`);
      this.hotelForm.reset();
      this.router.navigate(['/managingrooms']);
    }),
      (error: any) => {
      console.log(`Error updating hotel: `, error);
      window.alert(`Error updating hotel!`);
    }
  }
}

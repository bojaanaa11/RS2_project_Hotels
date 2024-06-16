import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AppStateService } from '../../../shared/app-state/app-state.service';
import { ManageReservationsFacadeService } from '../../domain/application-services/manage-reservations-facade.service';

@Component({
  selector: 'app-create-reservation-form',
  templateUrl: './create-reservation-form.component.html',
  styleUrl: './create-reservation-form.component.css'
})
export class CreateReservationFormComponent implements OnInit {
  public createReservationForm: FormGroup;

  constructor(private route: ActivatedRoute, private appStateService: AppStateService, private manageReservationsService: ManageReservationsFacadeService) {
    this.createReservationForm = new FormGroup({
      id: new FormControl(this.generateReservationId()),
      userId: new FormControl(this.appStateService.getUserName()),
      hotelId: new FormControl(""),
      hotelName: new FormControl(""),   
      roomId: new FormControl(""),
      bookingDateTime: new FormControl(this.generateCurrentDateTime()),
      startDateTime: new FormControl(""), 
      endDateTime: new FormControl("")
    });
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const hotelId = params['hotelId'] || '';
      const hotelName = params['hotelName'] || '';
      const roomId = params['roomId'] || '';

      this.createReservationForm.patchValue({
        hotelId: hotelId,
        hotelName: hotelName,
        roomId: roomId
      });
    });
  }
  
  generateReservationId(): string {
    const chars = '0123456789ABCDEF';
    let result = '';
    for (let i = 0; i < 24; i++) {
      const randomIndex = Math.floor(Math.random() * chars.length);
      result += chars[randomIndex];
    }
    return result;
  }

  generateCurrentDateTime(): string {
    const now = new Date();

    const day = String(now.getDate()).padStart(2, '0');
    const month = String(now.getMonth() + 1).padStart(2, '0');
    const year = now.getFullYear();
  
    const hours = String(now.getHours()).padStart(2, '0');
    const minutes = String(now.getMinutes()).padStart(2, '0');
  
    return `${day}/${month}/${year} ${hours}:${minutes}`;
  }

  public onCreateReservationSubmit(): void {
    if(this.createReservationForm.invalid) {
      window.alert('Form has errors!');
      return;
    }

    this.manageReservationsService.create(
      this.createReservationForm.value.id, 
      this.createReservationForm.value.userId,
      this.createReservationForm.value.hotelId,
      this.createReservationForm.value.hotelName,
      this.createReservationForm.value.roomId,
      this.createReservationForm.value.bookingDateTime,
      this.createReservationForm.value.startDateTime,
      this.createReservationForm.value.endDateTime,
      "Confirmed"
    ).subscribe((success: boolean) => {
      window.alert(`Reservation ${success ? 'is' : 'is not'} successful.`);
    })
  }
}

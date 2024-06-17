import { Component, OnInit } from '@angular/core';
import { AppStateService } from '../../../shared/app-state/app-state.service';
import { ManageReservationsFacadeService } from '../../domain/application-services/manage-reservations-facade.service';

@Component({
  selector: 'app-list-reservations',
  templateUrl: './list-reservations.component.html',
  styleUrl: './list-reservations.component.css'
})
export class ListReservationsComponent implements OnInit  {
  reservations: any[] = [];

  constructor(private manageReservationsService: ManageReservationsFacadeService,private appStateService: AppStateService) {}

  ngOnInit(): void {
    this.getReservations();
  }

  getReservations(): void {
    this.manageReservationsService.getReservations(
      this.appStateService.getUserId()
    ).subscribe((reservations: any[]) => {
      this.reservations = reservations;
    })
  }
}

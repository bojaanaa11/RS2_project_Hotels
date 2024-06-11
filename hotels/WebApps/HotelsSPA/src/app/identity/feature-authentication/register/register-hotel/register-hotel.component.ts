import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationFacadeService } from '../../../domain/application-services/authentication-facade.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register-hotel',
  templateUrl: './register-hotel.component.html',
  styleUrl: './register-hotel.component.css'
})
export class RegisterHotelComponent implements OnInit {
  public registerHotelForm: FormGroup;

  constructor(private authenticationService: AuthenticationFacadeService, private routerService: Router) {
    this.registerHotelForm = new FormGroup({
      firstName: new FormControl("", [Validators.required]),
      lastName: new FormControl("", [Validators.required]),
      username: new FormControl("", [Validators.required, Validators.minLength(3)]),
      password: new FormControl("", [Validators.required, Validators.minLength(8)]),
      email: new FormControl("", [Validators.required]),
      phoneNumber: new FormControl("", [Validators.required]),
    })
  }

  ngOnInit(): void {
    
  }

  public onRegisterHotelFormSubmit(): void {
    if (this.registerHotelForm.invalid) {
      window.alert('Form has errors!');
      return;
    }

    this.authenticationService.registerAsHotel(
      this.registerHotelForm.value.firstName,
      this.registerHotelForm.value.lastName,
      this.registerHotelForm.value.username, 
      this.registerHotelForm.value.password,
      this.registerHotelForm.value.email,
      this.registerHotelForm.value.phoneNumber).subscribe((success: boolean) => {
      window.alert(`Registration ${success ? 'is' : 'is not'} successful!`);
      this.registerHotelForm.reset();
      if(success) {
        this.routerService.navigate(['/identity', 'login']);
      }
    });
  }
}

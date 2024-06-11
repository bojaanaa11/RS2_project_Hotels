import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationFacadeService } from '../../../domain/application-services/authentication-facade.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register-guest',
  templateUrl: './register-guest.component.html',
  styleUrl: './register-guest.component.css'
})
export class RegisterGuestComponent implements OnInit {
  public registerGuestForm: FormGroup;

  constructor(private authenticationService: AuthenticationFacadeService, private routerService: Router) {
    this.registerGuestForm = new FormGroup({
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

  public onRegisterGuestFormSubmit(): void {
    if (this.registerGuestForm.invalid) {
      window.alert('Form has errors!');
      return;
    }

    this.authenticationService.registerAsGuest(
      this.registerGuestForm.value.firstName,
      this.registerGuestForm.value.lastName,
      this.registerGuestForm.value.username, 
      this.registerGuestForm.value.password,
      this.registerGuestForm.value.email,
      this.registerGuestForm.value.phoneNumber).subscribe((success: boolean) => {
      window.alert(`Registration ${success ? 'is' : 'is not'} successful!`);
      this.registerGuestForm.reset();
      if(success) {
        this.routerService.navigate(['/identity', 'login']);
      }
    });
  }

}

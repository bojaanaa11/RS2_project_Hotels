import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationFacadeService } from '../../domain/application-services/authentication-facade.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrl: './login-form.component.css'
})
export class LoginFormComponent implements OnInit {
  public loginForm: FormGroup;

  constructor(private authenticationService: AuthenticationFacadeService, private routerService: Router) {
    this.loginForm = new FormGroup({
      username: new FormControl("", [Validators.required, Validators.minLength(3)]),
      password: new FormControl("", [Validators.required, Validators.minLength(8)]),
    })
  }

  ngOnInit(): void {
    
  }

  public onLoginFormSubmit(): void {
    if (this.loginForm.invalid) {
      window.alert('Form has errors!');
      return;
    }

    this.authenticationService.login(this.loginForm.value.username, this.loginForm.value.password).subscribe((success: boolean) => {
      window.alert(`Login ${success ? 'is' : 'is not'} successful!`);
      this.loginForm.reset();
      if(success) {
        this.routerService.navigate(['/identity', 'profile']);
      }
    });
  }

}

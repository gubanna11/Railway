import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { confirmPasswordValidator } from '../../../../helpers/confirm-password';
import { UserforRegistrationDto } from '../../../../models/user/registration/userForRegistrationDto';
import { AuthService } from '../../../../services/auth.service';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import ValidateForm from '../../../../helpers/valdiateForm';
import * as toastr from 'toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit {
  public registerForm!: FormGroup;
  public errorMessage: string = '';
  public showError!: boolean;

  constructor(private formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      firstName: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
      confirmPassword: new FormControl('')
    }, {
      validators: confirmPasswordValidator("password", "confirmPassword")
    });
  }

  public registerUser(registerFormValue: any) {
    if (this.registerForm.valid) {
      const user: UserforRegistrationDto = {
        firstName: registerFormValue.firstName,
        lastName: registerFormValue.lastName,
        email: registerFormValue.email,
        password: registerFormValue.password,
        confirmPassword: registerFormValue.confirmPassword
      };

      this.authService.register(user).subscribe({
        next: () => {
          toastr.success('You registered successfully!', 'SUCCESS', { timeOut: 5000 });
          this.router.navigate(["/auth/login"])
        },
        error: (err: HttpErrorResponse) => {
          console.log(err)
          this.errorMessage = err.message;
          this.showError = true;
        }
      })
    } else {
      ValidateForm.validateAllFormFields(this.registerForm);
    }
  }
}

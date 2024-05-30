import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../../../../services/auth.service';
import { UserForAuthDto } from '../../../../models/user/auth/userForAuthDto';
import { AuthResponseDto } from '../../../../models/user/auth/authResponseDto';
import { HttpErrorResponse } from '@angular/common/http';
import ValidateForm from '../../../../helpers/valdiateForm';
import * as toastr from 'toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  private returnUrl!: string;

  loginForm!: FormGroup;
  errorMessage: string = '';
  showError!: boolean;

  public isValidEmail!: boolean;

  constructor(private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private authService: AuthService,
  ) {

  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', Validators.required]
    });


    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  onLogin(loginFormValue: any) {
    if (this.loginForm.valid) {

      const userForAuth: UserForAuthDto = {
        email: loginFormValue.userName,
        password: loginFormValue.password
      }
      this.authService.login(userForAuth)
        .subscribe({
          next: (res: AuthResponseDto) => {
            localStorage.setItem("token", res.token);
            this.authService.sendAuthStateChangeNotification(res.isAuthSuccessful);
            toastr.success('', 'SUCCESS', { timeOut: 5000 });
            this.router.navigate([this.returnUrl]);
          },
          error: (err: HttpErrorResponse) => {
            this.errorMessage = err.message;
            this.showError = true;
          }
        })
    }
    else {
      ValidateForm.validateAllFormFields(this.loginForm);
    }
  }
}

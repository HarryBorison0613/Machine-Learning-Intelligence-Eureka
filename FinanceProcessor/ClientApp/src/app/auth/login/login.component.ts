import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthService } from "src/app/_services/auth.service";
import { TokenStorageService } from "src/app/_services/token-storage.service";
import { ToastrService } from "ngx-toastr";
import { Router } from '@angular/router';
import { AbstractControl, FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import Validation from 'src/app/_services/validation';
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'app-login',
  templateUrl: 'login.component.html',
  styleUrls: ['login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {
  form: FormGroup = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });
  submitted = false;

  isLoggedIn = false;
  userRole = "";
  userStatus = "";

  private Email: string = null;
  private Password: string = null;

  fieldTextType: boolean;

  constructor(private formBuilder: FormBuilder, private authService: AuthService, private router: Router, public toastr: ToastrService, private tokenStorage: TokenStorageService, private spinner: NgxSpinnerService) {}

  ngOnInit(): void {
    var body = document.getElementsByTagName("body")[0];
    body.classList.add("login-page");

    if (this.tokenStorage.getToken()) {
      this.isLoggedIn = true;
      this.userRole = this.tokenStorage.getUser().userRole;
      this.router.navigate(['/dashboard']);
    }
    this.form = this.formBuilder.group(
      {
        email: ['', [Validators.required, Validators.email]],
        password: [
          '',
          [
            Validators.required,
            Validators.minLength(6),
            Validators.maxLength(40)
          ]
        ]
      }
    );
  }

  get f(): { [key: string]: AbstractControl } {
    return this.form.controls;
  }

  toggleFieldTextType() {
    this.fieldTextType = !this.fieldTextType;
  }

  onSubmit(): void {
    this.submitted = true;

    if (this.form.invalid) {
      return;
    }

    if (this.form.valid) {
      this.spinner.show();
      const Email = this.form.value.email;
      const Password = this.form.value.password;

      this.authService.login( Email,  Password ).subscribe({
        next: data => {
          this.tokenStorage.saveToken(data.accessToken);
          this.tokenStorage.saveUser(data);
          this.isLoggedIn = true;
          this.userRole = this.tokenStorage.getUser().userRole;
          this.userStatus = this.tokenStorage.getUser().status;
          this.spinner.hide();
          this.toastr.show(
            '<span data-notify="icon" class="tim-icons icon-bell-55"></span>',
            "Login Success!",
            {
              timeOut: 4000,
              closeButton: true,
              enableHtml: true,
              toastClass: "alert alert-success alert-with-icon",
              positionClass: "toast-top-right"
            }
          );
          if (this.userStatus == "Expired") {
            this.router.navigate(['/membership']);
          } else {
            this.router.navigate(['/profile']);
          }
        },
        error: err => {
          this.spinner.hide();
          this.toastr.show(
            '<span data-notify="icon" class="tim-icons icon-bell-55"></span>',
            err.error,
            {
              timeOut: 4000,
              closeButton: true,
              enableHtml: true,
              toastClass: "alert alert-danger alert-with-icon",
              positionClass: "toast-top-right"
            }
          );
        }
      });
    }
  }
  ngOnDestroy() {
    var body = document.getElementsByTagName("body")[0];
    body.classList.remove("login-page");
  }
}

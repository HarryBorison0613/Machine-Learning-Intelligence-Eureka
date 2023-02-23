import { Component, OnInit } from '@angular/core';
import { AuthService } from "src/app/_services/auth.service";
import { ToastrService } from "ngx-toastr";
import { Router } from '@angular/router';
import { AbstractControl, FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import Validation from 'src/app/_services/validation';
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'app-register',
  templateUrl: 'register.component.html',
  styleUrls: ['register.component.css']
})
export class RegisterComponent implements OnInit {
  form: FormGroup = new FormGroup({
    firstname: new FormControl(''),
    lastname: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl(''),
    confirmPassword: new FormControl(''),
    acceptTerms: new FormControl(false),
  });
  submitted = false;

  private FirstName: string = null;
  private LastName: string = null;
  private Email: string = null;
  private Password: string = null;

  fieldTextType: boolean;
  repeatFieldTextType: boolean;

  constructor(private formBuilder: FormBuilder, private authService: AuthService, private router: Router, public toastr: ToastrService, private spinner: NgxSpinnerService) {}

  ngOnInit(): void {
    this.form = this.formBuilder.group(
      {
        firstname: ['', Validators.required],
        lastname: ['', Validators.required],
        email: ['', [Validators.required, Validators.email]],
        password: [
          '',
          [
            Validators.required,
            Validators.minLength(6),
            Validators.maxLength(40)
          ]
        ],
        confirmPassword: ['', Validators.required],
        acceptTerms: [false, Validators.requiredTrue]
      },
      {
        validators: [Validation.match('password', 'confirmPassword')]
      }
    );
  }

  get f(): { [key: string]: AbstractControl } {
    return this.form.controls;
  }

  toggleFieldTextType() {
    this.fieldTextType = !this.fieldTextType;
  }

  toggleRepeatFieldTextType() {
    this.repeatFieldTextType = !this.repeatFieldTextType;
  }

  onSubmit(): void {
    this.submitted = true;

    if (this.form.invalid) {
      return;
    }

    if (this.form.valid) {
      const FirstName = this.form.value.firstname;
      const LastName = this.form.value.lastname;
      const Email = this.form.value.email;
      const Password = this.form.value.password;
      this.spinner.show();
      this.authService.register( FirstName, LastName, Email,  Password ).subscribe({
        next: data => {
          this.spinner.hide();
          this.toastr.show(
            '<span data-notify="icon" class="tim-icons icon-bell-55"></span>',
            "Register Success!",
            {
              timeOut: 4000,
              closeButton: true,
              enableHtml: true,
              toastClass: "alert alert-success alert-with-icon",
              positionClass: "toast-top-right"
            }
          );
          this.router.navigateByUrl("/login");
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

  onReset(): void {
    this.submitted = false;
    this.form.reset();
  }
}

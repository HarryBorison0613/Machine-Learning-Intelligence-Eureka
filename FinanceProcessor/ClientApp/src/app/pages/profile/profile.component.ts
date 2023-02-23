import { Component, OnInit } from '@angular/core';
import { ParameterService } from '../service/parameterservice';
import { TokenStorageService } from 'src/app/_services/token-storage.service';
import { UserService } from 'src/app/_services/user.service';
import { Router } from '@angular/router';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  FormControl,
  Validators,
} from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-user',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})
export class ProfileComponent implements OnInit {
  userId: string;
  email: string;
  userName: string;
  dispalyName: string;
  fullName: string;
  firstName: string;
  lastName: string;
  address: string;
  aptSuite: string;
  city: string;
  postalCode: string;
  regionCode: string;
  countryCode: string;
  aboutMe: string;
  noCountryCode: boolean = false;

  form: FormGroup = new FormGroup({
    email: new FormControl(''),
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    address: new FormControl(''),
    aptSuite: new FormControl(''),
    city: new FormControl(''),
    postalCode: new FormControl(''),
    regionCode: new FormControl(''),
    aboutMe: new FormControl(''),
  });
  submitted = false;
  fieldTextType: boolean;
  repeatFieldTextType: boolean;

  countries: any[];
  selectedCountry: any;
  filteredCountries: any[];

  constructor(
    private countryService: ParameterService,
    private tokenStorage: TokenStorageService,
    private userService: UserService,
    private formBuilder: FormBuilder,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private router: Router
  ) {
    this.spinner.show();
  }

  ngOnInit() {
    this.userId = this.tokenStorage.getUser().userId;

    this.userService.getUserInfo(this.userId).subscribe({
      next: (data) => {
        this.spinner.hide();
        this.email = data.email;
        this.firstName = data.firstName;
        this.lastName = data.lastName;
        this.fullName = this.firstName.concat(' ', this.lastName);
        this.dispalyName = this.firstName.concat(
          ' ',
          this.lastName.slice(0, 1).toUpperCase(),
          '.'
        );
        this.address = data.address;
        this.aptSuite = data.aptSuite;
        this.city = data.city;
        this.postalCode = data.postalCode;
        this.regionCode = data.regionCode;
        this.aboutMe = data.aboutMe;
        this.selectedCountry = { name: '', code: '' };
        this.selectedCountry.code = data.country;

        this.form = this.formBuilder.group({
          email: [this.email, [Validators.required, Validators.email]],
          firstName: [this.firstName, Validators.required],
          lastName: [this.lastName, Validators.required],
          address: [this.address, Validators.required],
          aptSuite: [this.aptSuite, Validators.required],
          city: [this.city, Validators.required],
          postalCode: [this.postalCode, Validators.required],
          regionCode: [
            this.regionCode,
            [
              Validators.required,
              Validators.minLength(2),
              Validators.maxLength(2),
            ],
          ],
          aboutMe: [this.aboutMe],
        });
      },
      error: (err) => {
        console.log(err.error);
      },
    });
    this.countries = this.countryService.getCountries();
  }

  filterCountry(event) {
    let filtered: any[] = [];
    let query = event.query;
    for (let i = 0; i < this.countries.length; i++) {
      let country = this.countries[i];
      if (country.name.toLowerCase().indexOf(query.toLowerCase()) == 0) {
        filtered.push(country);
      }
    }

    this.filteredCountries = filtered;
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

    if (this.selectedCountry.code == undefined) {
      this.toastr.show(
        '<span data-notify="icon" class="tim-icons icon-bell-55"></span>',
        'Country Code Required!',
        {
          timeOut: 1000,
          closeButton: true,
          enableHtml: true,
          toastClass: 'alert alert-danger alert-with-icon',
          positionClass: 'toast-top-center',
        }
      );
    }

    if (this.form.valid && this.selectedCountry) {
      this.spinner.show();

      this.email = this.form.value.email;
      this.firstName = this.form.value.firstName;
      this.lastName = this.form.value.lastName;
      this.address = this.form.value.address;
      this.aptSuite = this.form.value.aptSuite;
      this.city = this.form.value.city;
      this.postalCode = this.form.value.postalCode;
      this.regionCode = this.form.value.regionCode.toUpperCase();
      this.aboutMe = this.form.value.aboutMe;
      this.countryCode = this.selectedCountry.code;

      this.userService
        .createProfile(
          this.userId,
          this.email,
          this.firstName,
          this.lastName,
          this.address,
          this.aptSuite,
          this.city,
          this.postalCode,
          this.regionCode,
          this.countryCode,
          this.aboutMe
        )
        .subscribe({
          next: (data) => {
            this.spinner.hide();
            this.toastr.show(
              '<span data-notify="icon" class="tim-icons icon-bell-55"></span>',
              data.result,
              {
                timeOut: 4000,
                closeButton: true,
                enableHtml: true,
                toastClass: 'alert alert-success alert-with-icon',
                positionClass: 'toast-top-right',
              }
            );
            this.router.navigate(['/membership']);
          },
          error: (err) => {
            this.spinner.hide();
            this.toastr.show(
              '<span data-notify="icon" class="tim-icons icon-bell-55"></span>',
              err.error,
              {
                timeOut: 4000,
                closeButton: true,
                enableHtml: true,
                toastClass: 'alert alert-danger alert-with-icon',
                positionClass: 'toast-top-right',
              }
            );
          },
        });
    }
  }
}

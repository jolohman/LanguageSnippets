import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  private _registerForm: FormGroup;

  constructor(private _form: FormBuilder) {
    this.createForm();
   }

  ngOnInit() {
  }

  createForm() {
    this._registerForm = this._form.group({
      email: new FormControl,
      password: new FormControl,
      confirmPassword: new FormControl
    });
  }

  onSubmit() {
    console.log(this._registerForm.value);
  }

}

import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent {
  formValidation = new FormGroup({
    name: new FormControl("ahmed", Validators.required),
    age: new FormControl(24, [Validators.min(20), Validators.max(40)]),
    email: new FormControl("ahmed@gmail.com", Validators.required)
  })

  getValue(){

  }

  get NameValid(){
    return this.formValidation.controls["name"].valid;
  }
  get AgeValid(){
    return this.formValidation.controls["age"].valid;
  }
  get EmailValid(){
    return this.formValidation.controls["email"].valid;
  }
}

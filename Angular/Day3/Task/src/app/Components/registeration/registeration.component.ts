import { NgIf } from '@angular/common';
import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-registeration',
  templateUrl: './registeration.component.html',
  styleUrls: ['./registeration.component.css']
})
export class RegisterationComponent {
  name = "";
  age = "";
  add(){
    if(this.name.length >= 3 && +this.age > 20 && +this.age < 40){
      this.myEvent.emit({name: this.name, age: this.age})
    }
  }

  @Output() myEvent = new EventEmitter();
}

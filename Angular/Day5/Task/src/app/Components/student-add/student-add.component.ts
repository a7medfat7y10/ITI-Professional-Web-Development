import { Component } from '@angular/core';
import { StudentsService } from 'src/app/Services/students.service';

@Component({
  selector: 'app-student-add',
  templateUrl: './student-add.component.html',
  styleUrls: ['./student-add.component.css']
})
export class StudentAddComponent{
  myService: any;
  constructor(myService: StudentsService){
    this.myService = myService;
  }
  
  Add(name: any, email: any, phone: any){
    let newStudent = {name, email, phone};
    this.myService.AddNewStudent(newStudent).subscribe();
  }
}

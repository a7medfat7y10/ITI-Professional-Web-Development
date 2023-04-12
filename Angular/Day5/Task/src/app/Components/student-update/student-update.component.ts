import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { StudentsService } from 'src/app/Services/students.service';

@Component({
  selector: 'app-student-update',
  templateUrl: './student-update.component.html',
  styleUrls: ['./student-update.component.css']
})
export class StudentUpdateComponent {
  ID: any;
  student: any;
  constructor(myActivated: ActivatedRoute, private myService: StudentsService){
    this.ID = myActivated.snapshot.params["id"];
  }

  Update(name: any, email: any, phone: any){
    this.myService.getStudentById(this.ID).subscribe({
      next:(data)=>{ this.student = data},
      error:(err)=>{}
      }
    );
    this.student.name = name;
    this.student.email = email;
    this.student.phone = phone;

    this.myService.UpdateStudentByID(this.ID, this.student).subscribe();
  }
}

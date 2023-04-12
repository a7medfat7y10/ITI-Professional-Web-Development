import { Component, OnInit} from '@angular/core';
import { StudentsService } from 'src/app/Services/students.service';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})

export class StudentsComponent implements OnInit{
  constructor(private myService: StudentsService){}
  students:any;
  ngOnInit(): void {
    // throw new Error('Method not implemented.');
    this.myService.getAllStudents().subscribe({
      next:(data)=>{this.students = data},
      error:()=>{}
    });
  }

  Delete(id: any){
    this.myService.DeleteStudentByID(id).subscribe();
  }

}

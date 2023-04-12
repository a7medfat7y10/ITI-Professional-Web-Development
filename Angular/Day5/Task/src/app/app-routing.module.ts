import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentsComponent } from './Components/students/students.component';
import { StudentDetailsComponent } from './Components/student-details/student-details.component';
import { StudentAddComponent } from './Components/student-add/student-add.component';
import { StudentUpdateComponent } from './Components/student-update/student-update.component';
import { ErrorComponent } from './Components/error/error.component';

const routes: Routes = [
  {path: "", component:StudentsComponent},
  {path: "students", component:StudentsComponent},
  {path: "students/:id", component:StudentDetailsComponent},
  {path: "addstudent", component:StudentAddComponent},
  {path: "updatestudent/:id", component:StudentUpdateComponent},
  {path: "**", component:ErrorComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

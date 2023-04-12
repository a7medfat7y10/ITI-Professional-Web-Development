import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {
  private readonly url = "http://localhost:3000/students";
  constructor(private readonly myClient: HttpClient) { }
  getAllStudents(){
    return this.myClient.get(this.url);
  }

  getStudentById(id: any){
    return this.myClient.get(this.url + '/' + id)
  }

  AddNewStudent(student: any){
    return this.myClient.post(this.url, student);
  }

  UpdateStudentByID(id: any, student:any){
    return this.myClient.put(this.url + "/" + id, student);
  }

  DeleteStudentByID(id: any){
    return this.myClient.delete(this.url + "/" + id);
  }
}

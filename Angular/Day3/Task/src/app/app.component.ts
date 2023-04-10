import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'Task';
  students: {name: string, age: number}[] = [];
  getData(data:any){
    this.students.push(data);
  }
}

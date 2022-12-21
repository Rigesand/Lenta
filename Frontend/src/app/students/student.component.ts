import { Component } from '@angular/core';
import {StudentService} from "../services/student.service";
import {Guid} from "guid-typescript";

@Component({
  selector: 'app-students',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.scss']
})
export class StudentComponent {
  constructor(public studentService:StudentService) {}

  ngOnInit(): void {
    this.studentService.GetAllStudents().subscribe(()=> {})
  }

  Submit(data: Guid)
  {
    this.studentService.id=data;
  }

}

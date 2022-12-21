import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup} from "@angular/forms";
import {StudentService} from "../services/student.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-createStudent',
  templateUrl: './createStudent.component.html',
  styleUrls: ['./createStudent.component.scss']
})
export class CreateStudentComponent implements OnInit{

  form: FormGroup

  constructor(public studentService:StudentService, private fb:FormBuilder,
              private router: Router) {}

  ngOnInit(): void {
    this.form=this.fb.group(
      {
        FullName: '',
        BirthDate: Date,
        UniversityName:'',
        Course:'',
        Faculty:'',
        PhoneNumber:'',
        Email:'',
        Description:'',
        CreateUser:'',
      }
    )
  }

  Submit()
  {

    this.studentService.Create(this.form.value).subscribe(()=>
    {
      this.router.navigate(['students']).then(() => {});
    })
  }
}

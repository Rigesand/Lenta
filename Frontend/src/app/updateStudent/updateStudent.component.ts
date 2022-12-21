import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup} from "@angular/forms";
import {StudentService} from "../services/student.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-createStudent',
  templateUrl: './updateStudent.component.html',
  styleUrls: ['./updateStudent.component.scss']
})
export class UpdateStudentComponent implements OnInit{

  form: FormGroup

  constructor(public studentService:StudentService,
              private fb:FormBuilder,
              private router: Router ) {}

  ngOnInit(): void {
    const student=this.studentService.GetUserById(this.studentService.id);
    this.form=this.fb.group(
      {
        Id: student.id,
        FullName: student.fullName,
        BirthDate: student.birthDate,
        UniversityName: student.universityName,
        Course:student.course,
        Faculty:student.faculty,
        PhoneNumber:student.phoneNumber,
        Email:student.email,
        Description:student.description,
        ChangeUser: ''
      })
  }

  Submit()
  {
    this.studentService.ChangeUserDetails(this.form.value).subscribe(()=>
    {
      this.router.navigate(['students']).then(() => {});
    })
  }
}

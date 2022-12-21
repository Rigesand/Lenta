import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {CreateStudentComponent} from "./createStudent/createStudent.component";
import {StudentComponent} from "./students/student.component";
import {UpdateStudentComponent} from "./updateStudent/updateStudent.component";
import {LoginComponent} from "./login/login.component";
import {RegisterComponent} from "./register/register.component";

const routes: Routes = [
  {path:'',component: LoginComponent},
  {path:'register',component: RegisterComponent},
  {path:'createStudent',component: CreateStudentComponent},
  {path:'updateStudent',component: UpdateStudentComponent},
  {path:'students',component: StudentComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

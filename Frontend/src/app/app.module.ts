import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { CreateStudentComponent } from './createStudent/createStudent.component';
import { StudentComponent } from './students/student.component';
import {HttpClientModule} from "@angular/common/http";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {UserService} from "./services/user.service";
import {StudentService} from "./services/student.service";
import {UpdateStudentComponent} from "./updateStudent/updateStudent.component";
import {LoginComponent} from "./login/login.component";
import {RegisterComponent} from "./register/register.component";
import {PersistanceService} from "./services/persistance.service";

@NgModule({
  declarations: [
    AppComponent,
    TopBarComponent,
    CreateStudentComponent,
    StudentComponent,
    UpdateStudentComponent,
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [UserService,StudentService,PersistanceService],
  bootstrap: [AppComponent]
})
export class AppModule { }

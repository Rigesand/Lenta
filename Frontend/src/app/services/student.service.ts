import {Injectable} from "@angular/core";
import {HttpClient, HttpParams} from "@angular/common/http";
import {Observable, tap} from "rxjs";
import {StudentDto} from "../models/student/studentDto";
import {StudentCreateDto} from "../models/student/studentCreateDto";
import {StudentChangeDto} from "../models/student/studentChangeDto";
import {Guid} from "guid-typescript";
import {PersistanceService} from "./persistance.service";

@Injectable()
export class StudentService
{
  constructor(private http:HttpClient,private persistanceService: PersistanceService) {
  }

  public id: Guid

  students: StudentDto[]


  GetAllStudents(): Observable<StudentDto[]>
  {
    const email=this.persistanceService.get('email')
    const url = "api/Student/GetAllStudents"
    return this.http.get<StudentDto[]>(url,
      {
        params: new HttpParams().set('email', email)
      }
      ).pipe(tap(students => this.students = students))
  }

  Create(data: StudentCreateDto) {
    const url = "api/Student/Create"
    return this.http.post<StudentCreateDto>(url, data).pipe()
  }

  ChangeUserDetails(data: StudentChangeDto)
  {
    const url = "api/Student/ChangeUserDetails"
    return this.http.post<StudentChangeDto>(url, data).pipe()
  }

  GetUserById(id: Guid): StudentDto
  {
    return this.students.find(it=>it.id===id)
  }
}

import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {UserRegisterDto} from "../models/user/userRegisterDto";
import {UserLoginDto} from "../models/user/userLoginDto";
import {Observable, tap} from "rxjs";
import {UserDto} from "../models/user/userDto";

@Injectable()
export class UserService
{
  constructor(private http:HttpClient) {
  }

  public roles: string[]

  register(data: UserRegisterDto)
  {
    const url = "api/Auth/Register"
    return this.http.post<UserRegisterDto>(url, data).pipe()
  }

  login(data: UserLoginDto): Observable<UserDto>
  {
    const url = "api/Auth/Login"
    return this.http.post<UserDto>(url, data).pipe()
  }
}

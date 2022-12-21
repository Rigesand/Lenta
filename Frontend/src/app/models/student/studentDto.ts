import {Guid} from "guid-typescript";

export interface StudentDto
{
  id:Guid,
  fullName:string,
  birthDate: Date,
  universityName:string,
  course: number,
  faculty:string,
  phoneNumber:string,
  email:string,
  description:string,
  createdDate:Date,
  changeDate:Date,
  createUser:string,
  changeUser:string
}

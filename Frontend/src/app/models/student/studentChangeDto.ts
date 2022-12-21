import {Guid} from "guid-typescript";

export interface StudentChangeDto
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
  changeUser:string
}

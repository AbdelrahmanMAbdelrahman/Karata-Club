import { Proiority } from "../../BeltRank/Models/Enums/Priority"

export interface CourseReq{
    courseName:string,
    fees:number,
    numberOfHours:number,
    numberOfSessions:number,
    startAt:string,
    priority:Proiority,
    image?:File
}
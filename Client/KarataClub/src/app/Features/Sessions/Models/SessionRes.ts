import { BeltRankFileRes } from "../../BeltRank/Models/BeltRankFileRes";
import { CourseRes } from "../../Courses/Models/CourseRes";
import { MemberRes } from "../../Members/Models/MemberRes";

export interface SessionRes{
    sessionId:string,
    fees:number,
    course:CourseRes,
    numberOfHours: number,
    sessionDate:string 
}

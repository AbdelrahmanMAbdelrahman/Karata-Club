import { BeltRankRes } from "../../BeltRank/Models/BeltRankRes";
import { CourseRes } from "../../Courses/Models/CourseRes";
import { MemberRes } from "../../Members/Models/MemberRes";

export interface BeltTestRes{
    BeltTestId:string,
     course:{
        courseId:string,
        courseName:string,
        fees:number,
        totalHours:number,
        numberOfSessions:number,
        active:boolean
    },
    member:MemberRes
}
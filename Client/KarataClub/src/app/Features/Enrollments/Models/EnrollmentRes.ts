import { Proiority } from "../../BeltRank/Models/Enums/Priority";
import { CourseFileRes } from "../../Courses/Models/CourseFileRes";
import { CourseRes } from "../../Courses/Models/CourseRes";
import { MemberRes } from "../../Members/Models/MemberRes";

export interface EnrollmentRes{
    enrollmentId:string,
    course:CourseRes ,
    enrollmentDate:string,
    endDate:string,
    member:MemberRes
}
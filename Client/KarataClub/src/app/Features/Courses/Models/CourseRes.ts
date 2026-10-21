import { BeltRankRes } from "../../BeltRanks/Models/BeltRankRes";
import { PersonRes } from "../../Instructors/Models/PersonRes";

export interface CourseRes{
    courseFileId:string,
    course:{
        courseId:string,
        courseName:string,
        fees:number,
        totalHours:number,
        numberOfSessions:number,
        active:boolean
    },
    uploadedFileId:PersonRes
}

   
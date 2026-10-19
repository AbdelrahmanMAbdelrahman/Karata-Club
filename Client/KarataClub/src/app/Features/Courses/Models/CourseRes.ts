import { BeltRankRes } from "../../BeltRanks/Models/BeltRankRes";
import { PersonRes } from "../../Instructors/Models/PersonRes";

export interface CourseRes{
    CourseFileId:string,
    course:{
        courseId:string,
        courseName:string,
        fees:number,
        totalHours:number,
        numberOfSessions:number
    },
    uploadedFileId:PersonRes
}

   
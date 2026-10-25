import { Proiority } from "../../BeltRank/Models/Enums/Priority";
import { PersonRes } from "../../Instructors/Models/PersonRes";
import { CourseRes } from "./CourseRes";

export interface CourseFileRes{
    courseFileId:string,
    course:CourseRes,
    uploadedFileId:string
}

   
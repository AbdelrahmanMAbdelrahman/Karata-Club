import { BeltRankRes } from "../../BeltRank/Models/BeltRankRes";
import { InstructorRes } from "../../Instructors/Models/InstructorRes";

import { MemberRes } from "../../Members/Models/MemberRes";

export interface BeltTestRes{
    beltTestId:string,
    instructor:InstructorRes,
    beltRank:BeltRankRes,
    member:MemberRes,
    reservationDate:string,
    testDate:string
    passed:boolean
}
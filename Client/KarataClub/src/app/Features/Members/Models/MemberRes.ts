import { BeltRankFileRes } from "../../BeltRank/Models/BeltRankFileRes";
import { BeltRankRes } from "../../BeltRank/Models/BeltRankRes";
import { PersonRes } from "../../Instructors/Models/PersonRes";

export interface MemberRes{
    memberId:string,
    active:boolean,
    beltRank:BeltRankRes,
    person:PersonRes
}
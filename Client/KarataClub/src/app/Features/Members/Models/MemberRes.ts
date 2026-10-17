import { BeltRankRes } from "../../BeltRanks/Models/BeltRankRes";
import { PersonRes } from "../../Instructors/Models/PersonRes";

export interface MemberRes{
    memberId:string,
    active:boolean,
    beltRank:BeltRankRes,
    person:PersonRes
}
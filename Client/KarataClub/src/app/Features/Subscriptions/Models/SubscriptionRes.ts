import { BeltRankRes } from "../../BeltRanks/Models/BeltRankRes";
import { PersonRes } from "../../Instructors/Models/PersonRes";
import { MemberRes } from "../../Members/Models/MemberRes";

export interface SubscriptionRes{
    id:string,
    fees:number,
    startDate:string,
    endDate:string,
    active:boolean,
    beltRank:BeltRankRes,
    member:MemberRes
}
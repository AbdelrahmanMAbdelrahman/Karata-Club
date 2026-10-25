import { BeltRankFileRes } from "../../BeltRank/Models/BeltRankFileRes";
import { MemberRes } from "../../Members/Models/MemberRes";

export interface SubscriptionRes{
    id:string,
    fees:number,
    startDate:string,
    endDate:string,
    active:boolean,
    beltRank:BeltRankFileRes,
    member:MemberRes
}
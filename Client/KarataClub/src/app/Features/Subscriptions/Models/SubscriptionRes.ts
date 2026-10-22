import { BeltRankRes } from "../../BeltRank/Models/BeltRankRes";
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
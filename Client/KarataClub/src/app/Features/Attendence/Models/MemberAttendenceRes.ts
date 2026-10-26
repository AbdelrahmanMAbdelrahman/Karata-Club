import { BeltRankRes } from "../../BeltRank/Models/BeltRankRes"
import { PaginatedList } from "../../Global/Models/PaginatedList"
import { MemberRes } from "../../Members/Models/MemberRes"

export interface MemberAttendenceRes{
memberAttendenceId:string,
member: MemberRes,
beltRank:BeltRankRes,
exist:boolean
}

 
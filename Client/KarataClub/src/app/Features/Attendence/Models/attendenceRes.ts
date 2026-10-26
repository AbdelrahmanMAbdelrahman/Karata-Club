import { PaginatedList } from "../../Global/Models/PaginatedList"
import { SessionRes } from "../../Sessions/Models/SessionRes"
import { MemberAttendenceRes } from "./MemberAttendenceRes"

export interface AttendenceRes{
    attendenceId:string,
    session:SessionRes,
    
     
}

 
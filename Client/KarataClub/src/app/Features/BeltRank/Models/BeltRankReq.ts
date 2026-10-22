import { Proiority } from "./Enums/Priority";

export interface BeltRankReq{
    rankName:string,
    testFees:number,
    priority:Proiority,
    image?:File
}
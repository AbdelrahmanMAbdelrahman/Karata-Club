
import { PersonRes } from "../../Instructors/Models/PersonRes";
import { Proiority } from "./Enums/Priority";

export interface BeltRankRes{
  beltRank:{
  id:string;
  rankName: string ;
  testFees: number ;
  priority: Proiority  ;}
  uploadedFileId:string
}

   
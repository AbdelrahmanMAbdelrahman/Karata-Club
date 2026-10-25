import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { BeltTestCreateComponent } from '../BeltTest-create-component/BeltTest-create-component';
import { MemberDetailComponent } from '../../../Members/Components/Member-detail-component/Member-detail-component';
import { CourseDetailComponent } from '../../../Courses/Components/Course-detail-component/Course-detail-component';

import { MemberRes } from '../../../Members/Models/MemberRes';
import { BeltTestRes } from '../../Models/BeltTestRes';
import { RouterLink } from '@angular/router';
import { CourseRes } from '../../../Courses/Models/CourseRes';
import { BeltRankDetailComponent } from '../../../BeltRank/Components/BeltRank-detail-component/BeltRank-detail-component';
import { BeltRankFileRes } from '../../../BeltRank/Models/BeltRankFileRes';
import { BeltRankRes } from '../../../BeltRank/Models/BeltRankRes';
import { InstructorDetailComponent } from '../../../Instructors/Components/instructor-detail-component/instructor-detail-component';


@Component({
  selector: 'app-BeltTest-detail-component',
  imports: [BeltTestCreateComponent, MemberDetailComponent, CourseDetailComponent, RouterLink, BeltRankDetailComponent, InstructorDetailComponent],
  templateUrl: './BeltTest-detail-component.html',
  styleUrl: './BeltTest-detail-component.css',
})
export class BeltTestDetailComponent implements OnChanges {
  Course?:CourseRes;
  @Input()BeltTestRes?:BeltTestRes;
  @Output()OnPassTest=new EventEmitter();
  beltRank?: BeltRankFileRes;
  
  ngOnChanges(changes: SimpleChanges): void {
    this.beltRank={
      beltRank:this.BeltTestRes?.beltRank!,
      uploadedFileId:"",
    }
    console.log(this.BeltTestRes?.beltRank);
  }
  PassBeltTest() {
   this.OnPassTest.emit();
  }
 
}

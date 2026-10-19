import { Component, OnInit } from '@angular/core';
import { CourseDetailComponent } from '../../Components/Course-detail-component/Course-detail-component';
import { Observable } from 'rxjs';
import { CourseRes } from '../../Models/CourseRes';
import { AsyncPipe } from '@angular/common';
import { CourseApiService } from '../../Services/CourseApiService';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-Course-detail-page',
  imports: [CourseDetailComponent, AsyncPipe, RouterLink],
  templateUrl: './Course-detail-page.html',
  styleUrl: './Course-detail-page.css',
})
export class CourseDetailPage implements OnInit {
  Course?:Observable<CourseRes>;
  /**
   *
   */
  constructor(private CourseService:CourseApiService,private route:ActivatedRoute) {
  
  }
  ngOnInit(): void {
    this.Course=this.CourseService.GetCourse(this.Id);  
  }
  get Id(){
    return this.route.snapshot.paramMap.get("id")??"";
  }
}

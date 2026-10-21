import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CourseReq } from '../../Models/CourseReq';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
 

@Component({
  selector: 'app-Course-create-component',
  imports: [RouterLink,ReactiveFormsModule],
  templateUrl: './Course-create-component.html',
  styleUrl: './Course-create-component.css',
})
export class CourseCreateComponent implements OnInit{
  @Output() OnSaveCourse=new EventEmitter<CourseReq>
  form?:FormGroup;
  Save() {
    let req=this.fillObject();
    this.OnSaveCourse.emit(req);
  }
  Clear() {
    this.form?.reset();
  }
  ngOnInit(): void {
    this.initForm();
  }
  fillObject():CourseReq{
    let req:CourseReq={
      courseName: this.form?.get('name')?.value,
      fees: this.form?.get('fees')?.value,
      numberOfHours: this.form?.get('hours')?.value,
      image: this.form?.get('image')?.value,
      numberOfSessions: this.form?.get('sessions')?.value
      
    }
    return req;
  }
  ClearImage(image: HTMLInputElement) {
    image.value="";
  this.form?.patchValue({image:null})
  }
  SelectImage(event: Event) {
    console.log("select image now")
    debugger;
  let input=event.target as HTMLInputElement;
  if(!input|| input?.files?.length===0)return;
  const image=input?.files![0];
  this.form?.get('image')?.setValue(image);
  }
initForm(){
  this.form=new FormGroup({
'name':new FormControl(null,Validators.required),
'fees':new FormControl(null,Validators.required),
'hours':new FormControl(null,Validators.required),
'image':new FormControl<File|null>(null),
'sessions':new FormControl(null,Validators.required)
  });
}
}

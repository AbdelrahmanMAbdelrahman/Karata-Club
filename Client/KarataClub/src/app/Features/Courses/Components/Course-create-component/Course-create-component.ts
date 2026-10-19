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
      name: this.form?.get('name')?.value,
      email: this.form?.get('email')?.value,
      phone: this.form?.get('phone')?.value,
      address: this.form?.get('address')?.value
    
    }
    return req;
  }
initForm(){
  this.form=new FormGroup({
'name':new FormControl(null,Validators.required),
'email':new FormControl(null,Validators.required),
'phone':new FormControl(null,Validators.required),
'address':new FormControl(null,Validators.required)
  });
}
}

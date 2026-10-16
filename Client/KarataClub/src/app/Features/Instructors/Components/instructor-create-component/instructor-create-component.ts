import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { RouterLink } from '@angular/router';
import { InstructorReq } from '../../Models/InstructorReq';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
 

@Component({
  selector: 'app-instructor-create-component',
  imports: [RouterLink,ReactiveFormsModule],
  templateUrl: './instructor-create-component.html',
  styleUrl: './instructor-create-component.css',
})
export class InstructorCreateComponent implements OnInit{
  @Output() OnSaveInstructor=new EventEmitter<InstructorReq>
  form?:FormGroup;
  Save() {
    let req=this.fillObject();
    this.OnSaveInstructor.emit(req);
  }
  Clear() {
    this.form?.reset();
  }
  ngOnInit(): void {
    this.initForm();
  }
  fillObject():InstructorReq{
    let req:InstructorReq={
      name: this.form?.get('name')?.value,
      email: this.form?.get('email')?.value,
      phone: this.form?.get('phone')?.value,
      address: this.form?.get('address')?.value,
      qualifications: this.form?.get('qualifications')?.value
    }
    return req;
  }
initForm(){
  this.form=new FormGroup({
'name':new FormControl(null,Validators.required),
'email':new FormControl(null,Validators.required),
'phone':new FormControl(null,Validators.required),
'address':new FormControl(null,Validators.required),
'qualifications':new FormControl(null,Validators.required),
  });
}
}

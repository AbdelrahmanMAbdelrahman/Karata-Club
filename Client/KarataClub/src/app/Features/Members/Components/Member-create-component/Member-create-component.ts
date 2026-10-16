import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { RouterLink } from '@angular/router';
import { MemberReq } from '../../Models/MemberReq';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
 

@Component({
  selector: 'app-Member-create-component',
  imports: [RouterLink,ReactiveFormsModule],
  templateUrl: './Member-create-component.html',
  styleUrl: './Member-create-component.css',
})
export class MemberCreateComponent implements OnInit{
  @Output() OnSaveMember=new EventEmitter<MemberReq>
  form?:FormGroup;
  Save() {
    let req=this.fillObject();
    this.OnSaveMember.emit(req);
  }
  Clear() {
    this.form?.reset();
  }
  ngOnInit(): void {
    this.initForm();
  }
  fillObject():MemberReq{
    let req:MemberReq={
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

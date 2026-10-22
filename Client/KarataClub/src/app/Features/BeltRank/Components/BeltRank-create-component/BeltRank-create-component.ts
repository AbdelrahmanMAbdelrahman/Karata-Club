import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { RouterLink } from '@angular/router';
import { BeltRankReq } from '../../Models/BeltRankReq';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
 

@Component({
  selector: 'app-BeltRank-create-component',
  imports: [RouterLink,ReactiveFormsModule],
  templateUrl: './BeltRank-create-component.html',
  styleUrl: './BeltRank-create-component.css',
})
export class BeltRankCreateComponent implements OnInit{
  @Output() OnSaveBeltRank=new EventEmitter<BeltRankReq>
  form?:FormGroup;
  Save() {
    let req=this.fillObject();
    this.OnSaveBeltRank.emit(req);
  }
  Clear() {
    this.form?.reset();
  }
  ngOnInit(): void {
    this.initForm();
  }
  fillObject():BeltRankReq{
    let req:BeltRankReq={
      rankName: this.form?.get('rankName')?.value,
      testFees: this.form?.get('testFees')?.value,
      image: this.form?.get('image')?.value,
      priority: this.form?.get('priority')?.value
      
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
'rankName':new FormControl(null,Validators.required),
'testFees':new FormControl(null,Validators.required),
'priority':new FormControl(null,Validators.required),
'image':new FormControl<File|null>(null),
  });
}
}

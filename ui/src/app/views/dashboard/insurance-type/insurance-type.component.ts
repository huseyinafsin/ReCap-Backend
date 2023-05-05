import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Guid } from 'guid-typescript';
import { ToastrService } from 'ngx-toastr';
import { SystemCreateDto } from 'src/app/models/SystemCreate';
import { SystemDto } from 'src/app/models/systemDto';
import { SystemService } from 'src/app/services/system.service';
import { SystemTable } from 'src/environments/environment';

@Component({
  selector: 'app-insurance-type',
  templateUrl: './insurance-type.component.html',
  styleUrls: ['./insurance-type.component.scss']
})
export class InsuranceTypeComponent {
  insuranceTypes:SystemDto[];
  filterText:string=""
  constructor(
    private systemService:SystemService,
    private toaster:ToastrService,
    private modalService: NgbModal
    ) {

  }
  ngOnInit(): void {

    this.getinsuranceTypes()
  }
  onSubmit(f:NgForm){
    let model:SystemCreateDto ={
      name:f.value.name
    }
    this.systemService.add(SystemTable.InsuranceType, model ).subscribe(res=>{
      if(res.success){
        this.toaster.success(res.message);
        this.getinsuranceTypes()
      }
      else
        this.toaster.error(res.message)
    })
  }


  getinsuranceTypes(){
    this.systemService.getAll(SystemTable.InsuranceType).subscribe(res=>{
      this.insuranceTypes =res.data;
    })
  }
  onUpdate(f:NgForm){
    let model:SystemDto={
      id: f.value.id,
      name: f.value.name
    }
    console.log(model)
    this.systemService.update(SystemTable.InsuranceType, model).subscribe(res=>{
      if(res.success){
        this.toaster.success(res.message);
        this.getinsuranceTypes()
      }
      else
        this.toaster.error(res.message)
    })
  }
  onDelete(id:Guid){
      this.systemService.delete(SystemTable.InsuranceType, id).subscribe(res=>{
        if(res.success){
          this.toaster.success(res.message);
          this.getinsuranceTypes()
        }
        else
          this.toaster.error(res.message)
      })
  }
  open(content:any) {
		this.modalService.open(content, { windowClass: 'custom-ngb-modal-window', backdropClass: 'custom-ngb-modal-backdrop' });
	}
  onSearch(e:any){
    this.filterText=e.value
    console.log(e)
  }
}

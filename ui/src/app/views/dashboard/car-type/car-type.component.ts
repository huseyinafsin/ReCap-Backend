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
  selector: 'app-car-type',
  templateUrl: './car-type.component.html',
  styleUrls: ['./car-type.component.scss']
})
export class CarTypeComponent {
  carTypes:SystemDto[];
  filterText:string=""
  constructor(
    private systemService:SystemService,
    private toaster:ToastrService,
    private modalService: NgbModal
    ) {

  }
  ngOnInit(): void {

    this.getcarTypes()
  }
  onSubmit(f:NgForm){
    let model:SystemCreateDto ={
      name:f.value.name
    }
    this.systemService.add(SystemTable.CarType, model ).subscribe(res=>{
      if(res.success){
        this.toaster.success(res.message);
        this.getcarTypes()
      }
      else
        this.toaster.error(res.message)
    })
  }


  getcarTypes(){
    this.systemService.getAll(SystemTable.CarType).subscribe(res=>{
      this.carTypes =res.data;
    })
  }
  onUpdate(f:NgForm){
    let model:SystemDto={
      id: f.value.id,
      name: f.value.name
    }
    console.log(model)
    this.systemService.update(SystemTable.CarType, model).subscribe(res=>{
      if(res.success){
        this.toaster.success(res.message);
        this.getcarTypes()
      }
      else
        this.toaster.error(res.message)
    })
  }
  onDelete(id:Guid){
      this.systemService.delete(SystemTable.CarType, id).subscribe(res=>{
        if(res.success){
          this.toaster.success(res.message);
          this.getcarTypes()
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

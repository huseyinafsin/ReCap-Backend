import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Guid } from 'guid-typescript';
import { ToastrService } from 'ngx-toastr';
import { SystemCreateDto } from 'src/app/models/SystemCreate';
import { SystemDto } from 'src/app/models/systemDto';
import {SystemService} from 'src/app/services/system.service'
import { SystemTable } from 'src/environments/environment';
@Component({
  selector: 'app-brand-list',
  templateUrl: './brand-list.component.html',
  styleUrls: ['./brand-list.component.scss']
})
export class BrandListComponent implements OnInit {
  brands:SystemDto[];
  editForm:FormGroup
  filterText:string=""
  constructor(
    private systemService:SystemService,
    private toaster:ToastrService,
    private modalService: NgbModal
    ) {

  }
  ngOnInit(): void {

    this.getBrands()
  }
  onSubmit(f:NgForm){
    let model:SystemCreateDto ={
      name:f.value.name
    }
    this.systemService.add(SystemTable.Brand,model ).subscribe(res=>{
      if(res.success){
        this.toaster.success(res.message);
        this.getBrands()
      }
      else
        this.toaster.error(res.message)
    })
  }


  getBrands(){
    this.systemService.getAll(SystemTable.Brand).subscribe(res=>{
      this.brands =res.data;
    })
  }
  onUpdate(f:NgForm){
    let model:SystemDto={
      id: f.value.id,
      name: f.value.name
    }
    console.log(model)
    this.systemService.update(SystemTable.Brand, model).subscribe(res=>{
      if(res.success){
        this.toaster.success(res.message);
        this.getBrands()
      }
      else
        this.toaster.error(res.message)
    })
  }
  onDelete(id:Guid){
      this.systemService.delete(SystemTable.Brand, id).subscribe(res=>{
        if(res.success){
          this.toaster.success(res.message);
          this.getBrands()
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

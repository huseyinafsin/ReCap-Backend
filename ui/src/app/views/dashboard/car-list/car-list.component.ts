import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Guid } from 'guid-typescript';
import { ToastrService } from 'ngx-toastr';
import { CarGridDto } from 'src/app/models/CarGridDto';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: ['./car-list.component.scss']
})
export class CarListComponent implements OnInit {
cars:CarGridDto[]
loaded: boolean;
page:number=1
pageSize=6
totalPage: number;
/**
 *
 */
constructor(private carService:CarService,
  private modalService: NgbModal,
  private toaster:ToastrService) {

}

ngOnInit(): void {
    this.getCars(this.page);
}

onDelete(id:Guid){
  this.carService.delete(id).subscribe(res=>{
    if(res.success)
      this.toaster.show(res.message)
    else
      this.toaster.error(res.message)
    this.getCars(this.page)
  })
}
getCars(page:number){
  if(page<= 0)
    page=1
  this.page=page
  this.carService.getPaged(this.page, this.pageSize).subscribe(res=>{
    if(res.data){
      this.loaded =true
      this.cars = res.data.carGridDtos;
      this.totalPage = res.data.count;
      console.log(this.totalPage)
    }
  })
}
open(content:any) {
  this.modalService.open(content, { windowClass: 'custom-ngb-modal-window', backdropClass: 'custom-ngb-modal-backdrop' });
}


getLoopItems() {
  return Array(this.totalPage).fill(0).map((x, i) => i);
}
}

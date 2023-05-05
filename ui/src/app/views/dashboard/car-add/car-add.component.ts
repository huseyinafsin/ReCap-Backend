import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Guid } from 'guid-typescript';
import { ToastrService } from 'ngx-toastr';
import { Car } from 'src/app/models/car';
import { SystemDto } from 'src/app/models/systemDto';
import { CarService } from 'src/app/services/car.service';
import { SystemService } from 'src/app/services/system.service';
import { SystemTable } from 'src/environments/environment';

@Component({
  selector: 'app-car-add',
  templateUrl: './car-add.component.html',
  styleUrls: ['./car-add.component.scss']
})
export class CarAddComponent implements OnInit {
  form:FormGroup
  colors: SystemDto[];
  brands: SystemDto[];
  carTypes: SystemDto[];
  gearCarTypes: SystemDto[];
  fuelTypes: SystemDto[];
  gearTypes: SystemDto[];
  constructor(private carService:CarService,
    private systemService:SystemService,
    private toaster:ToastrService) {}

  ngOnInit(): void {
    this.initForm()
    this.getColors();
    this.getBrands();
    this.getFuelTypes()
    this.getGearTypes();
    this.getCarTypes()
  }
   initForm() {
    this.form = new FormGroup({
      // id : new FormControl(""),
      carName : new FormControl(""),
      model : new FormControl(""),
      carTypeId : new FormControl(""),
      fuelTypeId : new FormControl(""),
      gearTypeId : new FormControl(""),
      brandId : new FormControl(""),
      colorId : new FormControl(""),
      // insertedUserId : new FormControl(""),
      minFindexScore : new FormControl(""),
      description: new FormControl(""),
    })

}

onSubmit(){
  const data = this.form.value;

  this.carService.add(data).subscribe(res=>{
    if(res.success){
      this.toaster.success(res.message);
    }
    else{
      this.toaster.error(res.message);
    }

  }
  )
}

getColors(){
  this.systemService.getAll(SystemTable.Color).subscribe(res=>{
   this.colors = res.data
  })
}
getBrands(){
  this.systemService.getAll(SystemTable.Brand).subscribe(res=>{
   this.brands = res.data
  })
}
getCarTypes(){
  this.systemService.getAll(SystemTable.CarType).subscribe(res=>{
   this.carTypes = res.data
  })
}
getFuelTypes(){
  this.systemService.getAll(SystemTable.FuelType).subscribe(res=>{
   this.fuelTypes = res.data
  })
}
getGearTypes(){
  this.systemService.getAll(SystemTable.GearType).subscribe(res=>{
   this.gearTypes = res.data
  })
}


}

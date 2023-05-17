import { Component } from '@angular/core';
import { Form, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Guid } from 'guid-typescript';
import { Gallery, GalleryItem, ImageItem, } from 'ng-gallery';
import { ToastrService } from 'ngx-toastr';
import { Car } from 'src/app/models/car';
import { SystemDto } from 'src/app/models/systemDto';
import { CarImageService } from 'src/app/services/car-image.service';
import { CarService } from 'src/app/services/car.service';
import { SystemService } from 'src/app/services/system.service';
import { SystemTable } from 'src/environments/environment';
import { CarImage } from 'src/app/models/carImage';

@Component({
  selector: 'app-car-edit',
  templateUrl: './car-edit.component.html',
  styleUrls: ['./car-edit.component.scss']
})
export class CarEditComponent {
  car:Car
  id:Guid
  disabled:boolean=true
  canceled:boolean=true
  form:FormGroup =this.fb.group({
    id : new FormControl(""),
    carName : new FormControl(""),
    model : new FormControl(""),
    carTypeId : new FormControl(""),
    fuelTypeId : new FormControl(""),
    gearTypeId : new FormControl(""),
    brandId : new FormControl(""),
    colorId : new FormControl(""),
    minFindexScore : new FormControl(""),
    insertedUserId: new FormControl(""),
    description: new FormControl(""),
  })
  colors: SystemDto[];
  brands: SystemDto[];
  carTypes: SystemDto[];
  gearCarTypes: SystemDto[];
  fuelTypes: SystemDto[];
  gearTypes: SystemDto[];
  images:CarImage[];

  constructor(private carService:CarService,
    public gallery: Gallery,
    private route:ActivatedRoute,
    private modalService: NgbModal,
    private fb: FormBuilder,
    private imageService:CarImageService,
    private systemService:SystemService,
    private toaster:ToastrService) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    })
    this.getCar()
    this.getImages()
    this.getColors();
    this.getBrands();
    this.getFuelTypes()
    this.getGearTypes();
    this.getCarTypes()

  }
  getCar() {
    this.carService.getCar(this.id).subscribe(res=>{
      this.car = res.data;
      this.initForm();
    })
  }

   initForm() {
    this.form = this.fb.group({
      id : [{value: this.car.id, disabled: false}],
      carName :[{value:this.car.carName, disabled: false}],
      model : [{value:this.car.model, disabled: false}],
      carTypeId : [{value: this.car.carTypeId, disabled: false}],
      fuelTypeId : [{value:this.car.fuelTypeId, disabled: false}],
      gearTypeId :[{value: this.car.gearTypeId, disabled: false}],
      brandId :[{value: this.car.brandId, disabled: false}],
      colorId : [{value: this.car.colorId, disabled: false}],
      insertedUserId : [{value: this.car.id, disabled: false}],
      minFindexScore :[{value: this.car.minFindexScore, disabled: false}],
      description:[{value: this.car.description, disabled: false}],
    })
console.log(this.car)

}

onSubmit(){
  const data = this.form.value;
    console.log("Data:")
    console.log(data)

  this.carService.update(data).subscribe(res=>{
    if(res.success){
      this.toaster.success(res.message);
    }
    else{
      this.toaster.error(res.message);
    }

  }
  )
}

onDelete(id:Guid){

}
onUpload(f:any){
  const file:File=f.files[0]
  console.log(file)
  this.imageService.upload(file, this.id).subscribe(res=>{
   console.log(res)
  })
}


getImages(){
  this.imageService.getImagesByCarId(this.id).subscribe(res=>{
   this.images = res.data
  })
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

open(content:any) {
  this.modalService.open(content, { windowClass: 'custom-ngb-modal-window', backdropClass: 'custom-ngb-modal-backdrop' });
}

onClear(){
  this.disabled=true;
}
onChange(f:any){
  if(f.value && f){
    this.disabled=false;
  }
  if(!f || f.value==""){
    this.canceled=true
  }
  else{
    this.canceled=false
  }
}

}

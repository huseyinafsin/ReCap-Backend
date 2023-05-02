import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Color } from 'src/app/models/color';
import { ColorDto } from 'src/app/models/colorDto';
import { ColorService } from 'src/app/services/color.service';
import {NgForm} from '@angular/forms';
import { Guid } from 'guid-typescript';
@Component({
  selector: 'app-color-list',
  templateUrl: './color-list.component.html',
  styleUrls: ['./color-list.component.scss']
})
export class ColorListComponent implements OnInit {
  isModalHidden :boolean=true
  colors:Color[] = []
  currentColor  = {} || null
  dataLoaded:boolean = false
  filterText:string=""
  @ViewChild('createModal') createModal: any;

  constructor(
    private colorService:ColorService    ) { }

  ngOnInit(): void
  {
    this.getColors();
  }

  getColors(){
    this.colorService.getColors().subscribe(response=>{
        this.colors = response.data;
        this.dataLoaded = true;
    });
  }
  onSubmit(f: NgForm) {
    let color:ColorDto={
      name: f.value.name,
    }
    console.log(f.value.name)
    this.colorService.add (color).subscribe( (data)=>{
      this.isModalHidden =true
    });
    this.isModalHidden =true
  }

  onDelete(id:Guid){
    this.colorService.delete(id).subscribe(response=>{
      if(response.message)
        this.getColors()
    })
  }

}

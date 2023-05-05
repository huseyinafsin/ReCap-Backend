import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import {SystemFilterPipe} from 'src/app/pipes/system-filter.pipe'
import {
  AvatarModule,
  ButtonGroupModule,
  ButtonModule,
  CardModule,
  FormModule,
  GridModule,
  NavModule,
  ProgressModule,
  TableModule,
  TabsModule,
} from '@coreui/angular';
import { IconModule } from '@coreui/icons-angular';
import { ChartjsModule } from '@coreui/angular-chartjs';
import { FormsModule }   from '@angular/forms';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import {MatDialogModule} from '@angular/material/dialog';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';

import { WidgetsModule } from '../widgets/widgets.module';
import { ColorListComponent } from './color-list/color-list.component';
import { BrandListComponent } from './brand-list/brand-list.component';
import { CarListComponent } from './car-list/car-list.component';
import { CarDetailComponent } from './car-detail/car-detail.component';
import { CarAddComponent } from './car-add/car-add.component';
import { CarEditComponent } from './car-edit/car-edit.component';
import { GearTypeComponent } from './gear-type/gear-type.component';
import { FuelTypeComponent } from './fuel-type/fuel-type.component';
import { CarTypeComponent } from './car-type/car-type.component';
import { InsuranceTypeComponent } from './insurance-type/insurance-type.component';
import { RentalListComponent } from './rental-list/rental-list.component';
import { RentalAddComponent } from './rental-add/rental-add.component';

@NgModule({
  imports: [
    DashboardRoutingModule,
    CardModule,
    NavModule,
    IconModule,
    TabsModule,
    CommonModule,
    GridModule,
    ProgressModule,
    ReactiveFormsModule,
    ButtonModule,
    FormModule,
    ButtonModule,
    ButtonGroupModule,
    ChartjsModule,
    AvatarModule,
    TableModule,
    WidgetsModule,
    MatDialogModule,
    MatIconModule,
    MatButtonModule,
    FormsModule,
    CardModule
  ],
  declarations: [
    DashboardComponent,
    ColorListComponent,
    BrandListComponent,
    CarListComponent,
    CarDetailComponent,
    CarAddComponent,
    CarEditComponent,
    GearTypeComponent,
    FuelTypeComponent,
    CarTypeComponent,
    InsuranceTypeComponent,
    RentalListComponent,
    SystemFilterPipe,
    RentalAddComponent]
})
export class DashboardModule {
}

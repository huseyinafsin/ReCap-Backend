import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserRoutingModule } from './user-routing.module';
import { CarComponent } from './car/car.component';
import { BrandComponent } from './brand/brand.component';
import { ColorComponent } from './color/color.component';
import { RentalComponent } from './rental/rental.component';
import { CarDetailComponent } from './car-detail/car-detail.component';
import { RentalAddComponent } from './rental-add/rental-add.component';
import { SearchComponent } from './car/search/search.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ProfileComponent } from './profile/profile.component';
import { CardComponent } from './rental-add/card/card.component';
import { PreOrderComponent } from './rental-add/pre-order/pre-order.component';
import { PaymentSuccessComponent } from './rental-add/payment-success/payment-success.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

// import { NgbAlertModule, NgbModule, NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { ColorFilterPipe } from '../pipes/color-filter.pipe';
import { BrandFilterPipe } from '../pipes/brand-filter.pipe';
import { CarFilterPipe } from '../pipes/car-filter.pipe';
import{MatIconModule} from '@angular/material/icon'
import { IconModule } from '@coreui/icons-angular';
import { ChartjsModule } from '@coreui/angular-chartjs';
import { CardModule } from '@coreui/angular';

@NgModule({
  declarations:[
    CarComponent,
    BrandComponent,
    ColorComponent,
    RentalComponent,
    CarDetailComponent,
    RentalAddComponent,
    SearchComponent,
    AboutComponent,
    ContactComponent,
    HomeComponent,
    RegisterComponent,
    ProfileComponent,
    CardComponent,
    PreOrderComponent,
    PaymentSuccessComponent,
                //pipes
                ColorFilterPipe,
                BrandFilterPipe,
                CarFilterPipe,


  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatIconModule,
    IconModule,
    ChartjsModule,
    CardModule
    // NgbPaginationModule,
    // NgbAlertModule,
    // NgbModule

  ]
})
export class UserModule { }

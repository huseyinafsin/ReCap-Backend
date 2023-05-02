import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { CarComponent } from './car/car.component';
import { ProfileComponent } from './profile/profile.component';
import { CarDetailComponent } from './car-detail/car-detail.component';
import { RentalAddComponent } from './rental-add/rental-add.component';
import { RentalComponent } from './rental/rental.component';
import { PreOrderComponent } from './rental-add/pre-order/pre-order.component';
import { RegisterComponent } from './register/register.component';
import { PaymentSuccessComponent } from './rental-add/payment-success/payment-success.component';


const routes: Routes = [
      {path:"",pathMatch:"full",component:HomeComponent},
      {path:"home",pathMatch:"full",component:HomeComponent},
      {path:"about",component:AboutComponent},
      {path:"contact",component:ContactComponent},
      {path:"car",component:CarComponent},
      {path:"profile",component:ProfileComponent},
      // {path:"brands",component:BrandListComponent},
      {path:"brand/:brandId",component:CarComponent},
      {path:"color/:colorId",component:CarComponent},
      {path:"car/details/:carId",component:CarDetailComponent},
      {path:"brand/:brandId/color/:colorId",component:CarComponent},
      {path:"rentals",component:RentalComponent},
      {path:"rentals/rent/:id",component: RentalAddComponent},
      {path:"rental/details/:id",component: PreOrderComponent},
      {path:"register",component: RegisterComponent},
      {path:"payment-success",component: PaymentSuccessComponent},

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }

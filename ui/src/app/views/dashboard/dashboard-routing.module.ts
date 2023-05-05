import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ColorListComponent } from './color-list/color-list.component';
import { DashboardComponent } from './dashboard.component';
import { BrandListComponent } from './brand-list/brand-list.component';
import { CarListComponent } from './car-list/car-list.component';
import { CarAddComponent } from './car-add/car-add.component';
import { CarEditComponent } from './car-edit/car-edit.component';
import { CarDetailComponent } from './car-detail/car-detail.component';
import { InsuranceTypeComponent } from './insurance-type/insurance-type.component';
import { CarTypeComponent } from './car-type/car-type.component';
import { FuelTypeComponent } from './fuel-type/fuel-type.component';
import { GearTypeComponent } from './gear-type/gear-type.component';

const routes: Routes = [
  {
    path: '',
    component:DashboardComponent
  },
  {
    path: 'colors',
    component:ColorListComponent
  },
  {
    path: 'brands',
    component:BrandListComponent
  },
  {
    path: 'geartype',
    component: GearTypeComponent
  }, {
    path: 'fueltype',
    component: FuelTypeComponent
  }, {
    path: 'cartype',
    component: CarTypeComponent
  }, {
    path: 'insurancetype',
    component: InsuranceTypeComponent
  },
  {
    path: 'cars',
    component:CarListComponent
  },
  {
    path: 'cars/detail/:id',
    component: CarDetailComponent
  },
  {
    path: 'cars/edit/:id',
    component: CarEditComponent
  },
  {
    path: 'cars/add',
    component:CarAddComponent
  },

  {
    path: 'dashboard',
    loadChildren: () =>
      import('../../views/dashboard/dashboard.module').then((m) => m.DashboardModule)
  },

  {
    path: 'theme',
    loadChildren: () =>
      import('../../views/theme/theme.module').then((m) => m.ThemeModule)
  },
  {
    path: 'base',
    loadChildren: () =>
      import('../../views/base/base.module').then((m) => m.BaseModule)
  },
  {
    path: 'buttons',
    loadChildren: () =>
      import('../../views/buttons/buttons.module').then((m) => m.ButtonsModule)
  },
  {
    path: 'forms',
    loadChildren: () =>
      import('../../views/forms/forms.module').then((m) => m.CoreUIFormsModule)
  },
  {
    path: 'charts',
    loadChildren: () =>
      import('../../views/charts/charts.module').then((m) => m.ChartsModule)
  },
  {
    path: 'icons',
    loadChildren: () =>
      import('../../views/icons/icons.module').then((m) => m.IconsModule)
  },
  {
    path: 'notifications',
    loadChildren: () =>
      import('../../views/notifications/notifications.module').then((m) => m.NotificationsModule)
  },
  {
    path: 'widgets',
    loadChildren: () =>
      import('../../views/widgets/widgets.module').then((m) => m.WidgetsModule)
  },
  {
    path: 'pages',
    loadChildren: () =>
      import('../../views/pages/pages.module').then((m) => m.PagesModule)
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule {
}

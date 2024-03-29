import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DefaultLayoutComponent, SiteLayoutComponent } from './containers';
import { Page404Component } from './views/pages/page404/page404.component';
import { Page500Component } from './views/pages/page500/page500.component';
import { LoginComponent } from './views/pages/login/login.component';
import { RegisterComponent } from './views/pages/register/register.component';
import { AboutComponent } from './views/user/about/about.component';
import { HomeComponent } from './views/user/home/home.component';
import { DashboardComponent } from './views/dashboard/dashboard.component';

const routes: Routes = [
  {
    path: '',
    component: SiteLayoutComponent,
    children:[
         {
        path: '',
        component: HomeComponent,
        data: {
          title: 'Home'
        },

      },
      {
        path: 'about',
        component: AboutComponent,
        data: {
          title: 'Register Page'
        }
      },
    ]
  },
  {
    path: 'dashboard',
    component: DefaultLayoutComponent,
    data: {
      title: 'Admin'
    },
    loadChildren: () =>
          import('./views/dashboard/dashboard.module').then((m) => m.DashboardModule)
    // children: [
    //   {
    //     path: '',
    //     component:DashboardComponent
    //   },
    //   {
    //     path: 'dashboard',
    //     loadChildren: () =>
    //       import('./views/dashboard/dashboard.module').then((m) => m.DashboardModule)
    //   },

    //   {
    //     path: 'theme',
    //     loadChildren: () =>
    //       import('./views/theme/theme.module').then((m) => m.ThemeModule)
    //   },
    //   {
    //     path: 'base',
    //     loadChildren: () =>
    //       import('./views/base/base.module').then((m) => m.BaseModule)
    //   },
    //   {
    //     path: 'buttons',
    //     loadChildren: () =>
    //       import('./views/buttons/buttons.module').then((m) => m.ButtonsModule)
    //   },
    //   {
    //     path: 'forms',
    //     loadChildren: () =>
    //       import('./views/forms/forms.module').then((m) => m.CoreUIFormsModule)
    //   },
    //   {
    //     path: 'charts',
    //     loadChildren: () =>
    //       import('./views/charts/charts.module').then((m) => m.ChartsModule)
    //   },
    //   {
    //     path: 'icons',
    //     loadChildren: () =>
    //       import('./views/icons/icons.module').then((m) => m.IconsModule)
    //   },
    //   {
    //     path: 'notifications',
    //     loadChildren: () =>
    //       import('./views/notifications/notifications.module').then((m) => m.NotificationsModule)
    //   },
    //   {
    //     path: 'widgets',
    //     loadChildren: () =>
    //       import('./views/widgets/widgets.module').then((m) => m.WidgetsModule)
    //   },
    //   {
    //     path: 'pages',
    //     loadChildren: () =>
    //       import('./views/pages/pages.module').then((m) => m.PagesModule)
    //   },
    // ]
  },
  {
    path: '404',
    component: Page404Component,
    data: {
      title: 'Page 404'
    }
  },
  {
    path: '500',
    component: Page500Component,
    data: {
      title: 'Page 500'
    }
  },
  {
    path: 'login',
    component: LoginComponent,
    data: {
      title: 'Login Page'
    }
  },
  {
    path: 'register',
    component: RegisterComponent,
    data: {
      title: 'Register Page'
    }
  },

  {path: '**', redirectTo: ''},

];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      scrollPositionRestoration: 'top',
      anchorScrolling: 'enabled',
      initialNavigation: 'enabledBlocking'
      // relativeLinkResolution: 'legacy'
    })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {
}

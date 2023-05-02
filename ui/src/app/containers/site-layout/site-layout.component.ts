import { Component } from '@angular/core';

import { navItems } from './_nav';

@Component({
  selector: 'site-dashboard',
  templateUrl: './site-layout.component.html',
  styleUrls:['./site-layout.component.scss','./site-layout.component.css']
})
export class SiteLayoutComponent {

  public navItems = navItems;

  public perfectScrollbarConfig = {
    suppressScrollX: true,
  };

  constructor() {}
}

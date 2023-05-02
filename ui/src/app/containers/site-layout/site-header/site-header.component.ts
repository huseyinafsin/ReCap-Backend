import { Component, Input } from '@angular/core';
import { navItems } from '../_nav';
import { ClassToggleService, HeaderComponent } from '@coreui/angular';

@Component({
  selector: 'app-site-header',
  templateUrl: './site-header.component.html',
  styleUrls:['./site-header.component.css']
})
export class SiteHeaderComponent extends HeaderComponent {
  public navItems = navItems;

  @Input() sidebarId: string = "sidebar";

  public newMessages = new Array(4)
  public newTasks = new Array(5)
  public newNotifications = new Array(5)

  constructor(private classToggler: ClassToggleService) {
    super();
  }
}


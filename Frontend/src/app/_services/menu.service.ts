import { Injectable } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { NavItem } from '../_models/nav';

@Injectable({
  providedIn: 'root'
})
export class MenuService {
  // TODO: Change menu items

  public main: NavItem[] = [];

  public components: NavItem[] = [
    {
      displayName: 'Dashboard',
      iconName: 'dashboard',
      route: '/dashboard'
    },
    {
      displayName: 'Approve Items',
      iconName: 'assignment_turned_in',
      route: '/approve-items'
    },
    {
      displayName: 'My Items',
      iconName: 'inbox',
      route: '/my-items'
    }

  ];

  public settings: NavItem[] = [
    {
      displayName: 'User Management',
      iconName: 'people',
      route: '/users'
    }
  ];

  public currentUrl = new BehaviorSubject<string>('');

  constructor(private router: Router) {
    this.router.events.subscribe((event) => {
      this.findMenuItem(event);
      setTimeout(() => {
        this.findMenuItem(event);
      }, 1000);
      if (event instanceof NavigationEnd) {
        this.currentUrl.next(event.urlAfterRedirects);
      }
    });
  }

  private findMenuItem(event: any) {
    let menuItem = [];
    const temp1 = this.main.filter((i) => i.route === event.url);
    const temp2 = this.components.filter((i) => i.route === event.url);
    const temp3 = this.settings.filter((i) => i.route === event.url);
    if (temp1.length > 0) {
      menuItem = temp1;
    } else if (temp2.length > 0) {
      menuItem = temp2;
    } else if (temp3.length > 0) {
      menuItem = temp3;
    } else {
      return;
    }
    if (menuItem[0].disabled) {
      this.router.navigate(['/']);
    }
  }
}

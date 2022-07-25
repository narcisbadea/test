import { BreakpointObserver } from '@angular/cdk/layout';
import { Component, OnInit } from '@angular/core';
import { MenuService } from '../_services/menu.service';
import { NavItem } from '../_models/nav';
import { MatDialog } from '@angular/material/dialog';
import { ProfileDialogComponent } from '../_dialogs/profile-dialog/profile-dialog.component';
import { Router } from '@angular/router';
import { UserResponseDto } from '../api/models';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {
  public isSmallScreen = false;

  main = this.menuService.main;
  components = this.menuService.components;
  settings = this.menuService.settings;

  mainLength = 0;
  componentsLength = 0;
  settingsLength = 0;

  constructor(
    breakpointObserver: BreakpointObserver,
    private menuService: MenuService,
    private dialog: MatDialog,
    private router: Router
  ) {
    this.isSmallScreen = breakpointObserver.isMatched('(min-width: 1000px)');
    breakpointObserver.observe('(min-width: 1000px)').subscribe((result) => {
      this.isSmallScreen = result.matches;
    });
  }

  ngOnInit(): void {
    let roles:  string[] =  JSON.parse(localStorage.getItem('roles')!);
    if(localStorage.getItem('token') === null){
      this.router.navigateByUrl('/login');
    }
    this.main.forEach((item) => {
      setTimeout(() => {
        if (!item.disabled) {
          this.mainLength++;
        }
      });
      this.checkCurrentUrl(item);
    });

    this.components.forEach((item) => {
      let roles:  string[] =  JSON.parse(localStorage.getItem('roles')!);
      setTimeout(() => {
        if(!(roles.indexOf('Admin') > -1) && item.displayName === 'Approve Items'){
          item.disabled = true;
        }
        if (!item.disabled) {
          this.componentsLength++;
        }
      });
      this.checkCurrentUrl(item);
    });

    this.settings.forEach((item) => {
      let roles:  string[] =  JSON.parse(localStorage.getItem('roles')!);
      setTimeout(() => {
        if(!(roles.indexOf('Admin') > -1) && item.displayName === 'User Management'){
          item.disabled = true;
        }
        if (!item.disabled) {
          this.settingsLength++;
        }
      });
      this.checkCurrentUrl(item);
    });
  }

  checkCurrentUrl(item: NavItem): void {
    this.menuService.currentUrl.subscribe((url: string) => {
      if (item.route && url) {
        item.expanded = url.indexOf(`${item.route}`) === 0;
      }
    });
  }

  closeNav(snav: any): void {
    if (!this.isSmallScreen) {
      snav.close();
    }
  }

  logout(): void {
    // TODO: Add logout function
    localStorage.clear();
    this.router.navigateByUrl('/login');
  }

  editProfile(): void {
    /************ DEMO CONTENT START ************/
    // TODO: Delete demo content
    let userLogged:  UserResponseDto =  JSON.parse(localStorage.getItem('user')!);
 

    const user = {
      id: userLogged.id,
      userName: userLogged.userName,
      email: userLogged.email,
      firstname: userLogged.firstName,
      lastname: userLogged.lastName,
    };
    /************ DEMO CONTENT END ************/
    // TODO: Add get user (e.g. from localStorage)
    this.dialog.open(ProfileDialogComponent, {
      data: user,
      width: '500px'
    });
  }
}

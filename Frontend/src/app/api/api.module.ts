/* tslint:disable */
/* eslint-disable */
import { NgModule, ModuleWithProviders, SkipSelf, Optional } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiConfiguration, ApiConfigurationParams } from './api-configuration';

import { AdminItemsService } from './services/admin-items.service';
import { AdminUserService } from './services/admin-user.service';
import { AuthService } from './services/auth.service';
import { BidsService } from './services/bids.service';
import { ClientItemService } from './services/client-item.service';
import { EmailService } from './services/email.service';
import { PicturesService } from './services/pictures.service';
import { UserManagementService } from './services/user-management.service';

/**
 * Module that provides all services and configuration.
 */
@NgModule({
  imports: [],
  exports: [],
  declarations: [],
  providers: [
    AdminItemsService,
    AdminUserService,
    AuthService,
    BidsService,
    ClientItemService,
    EmailService,
    PicturesService,
    UserManagementService,
    ApiConfiguration
  ],
})
export class ApiModule {
  static forRoot(params: ApiConfigurationParams): ModuleWithProviders<ApiModule> {
    return {
      ngModule: ApiModule,
      providers: [
        {
          provide: ApiConfiguration,
          useValue: params
        }
      ]
    }
  }

  constructor( 
    @Optional() @SkipSelf() parentModule: ApiModule,
    @Optional() http: HttpClient
  ) {
    if (parentModule) {
      throw new Error('ApiModule is already loaded. Import in your base AppModule only.');
    }
    if (!http) {
      throw new Error('You need to import the HttpClientModule in your AppModule! \n' +
      'See also https://github.com/angular/angular/issues/20575');
    }
  }
}

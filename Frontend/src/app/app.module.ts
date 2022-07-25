import { NgModule } from '@angular/core';

// MODULES
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MaterialModule } from './material.module';
import { AngularEditorModule } from '@kolkov/angular-editor';

// COMPONENTS
import { AppComponent } from './app.component';
import { MainComponent } from './main/main.component';
import { DashboardComponent } from './main/dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';
import { DeleteDialogComponent } from './_dialogs/delete-dialog/delete-dialog.component';
import { ProfileDialogComponent } from './_dialogs/profile-dialog/profile-dialog.component';
import { UsersEditorComponent } from './users/users-editor/users-editor.component';
import { BidComponent } from './main/dashboard/bid/bid.component';
import { MatFileUploadModule } from 'angular-material-fileupload';
import { ReactiveFormsModule } from '@angular/forms';
import { NewBidComponent } from './main/dashboard/new-bid/new-bid.component';
import { ItemApproveComponent } from './main/item-approve/item-approve.component';
import { ApproveComponent } from './main/item-approve/approve/approve.component';
import { BanDialogComponent } from './_dialogs/ban-dialog/ban-dialog.component';
import { AddRoleDialogComponent } from './_dialogs/add-role-dialog/add-role-dialog.component';

import { TokenInterceptor } from './interceptor/auth.interceptor';
import { UsersComponent } from './users/users.component';
import { RegisterComponent } from './register/register.component';
import { MyItemsComponent } from './main/my-items/my-items.component';
import { NgImageSliderModule } from 'ng-image-slider';


@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    DashboardComponent,
    LoginComponent,
    UsersComponent,
    UsersEditorComponent,
    DeleteDialogComponent,
    ProfileDialogComponent,
    ItemApproveComponent,
    NewBidComponent,
    BidComponent,
    ApproveComponent,
    BanDialogComponent,
    AddRoleDialogComponent,
    RegisterComponent,
    MyItemsComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    MaterialModule,
    AngularEditorModule,
    MatFileUploadModule,
    ReactiveFormsModule,
    NgImageSliderModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

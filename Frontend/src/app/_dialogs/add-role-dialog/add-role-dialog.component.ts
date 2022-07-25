import { Component, Inject, OnInit } from '@angular/core';
import { Users } from '../../_models/users';
import { SnackbarHelperService } from '../../_helpers/snackbar-helper.service';
import { Observable } from 'rxjs';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { UserResponseDto, UserRoleDto } from 'src/app/api/models';
import { UserManagementService } from 'src/app/api/services';

@Component({
  selector: 'app-add-role-dialog',
  templateUrl: './add-role-dialog.component.html',
  styleUrls: ['./add-role-dialog.component.scss']
})
export class AddRoleDialogComponent implements OnInit {
  public role: string = '';
  public roles: String[] = [];

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: UserResponseDto,
    private dialog: MatDialog,
    private snackbarHelper: SnackbarHelperService,
    private userManagerService: UserManagementService
  ) { }

  ngOnInit(): void {
    this.getRoles().subscribe((resp: string[] )=>{
      this.roles = resp;
      
    })
  }

  getRoles():Observable<string[]>{
    return this.userManagerService.apiUserManagementRolesGet$Json({userID: this.data.userName!});
  }

  public submit():void{
      let userRole: UserRoleDto = {
          id: this.data.id,
          roleName: this.role
      }
      this.userManagerService.apiUserManagementPost({body : userRole}).subscribe(
        () => {
          this.snackbarHelper.openSnackbar('Successfully added role!');
          location.reload();
          },
          (err: any) => {
            this.snackbarHelper.openSnackbar('Error adding role to user', 'bg-danger');
          }
      );
  }

}

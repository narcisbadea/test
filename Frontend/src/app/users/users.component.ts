import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Users } from '../_models/users';
import { MatTableDataSource } from '@angular/material/table';
import { SnackbarHelperService } from '../_helpers/snackbar-helper.service';
import { MatDialog } from '@angular/material/dialog';

import { AddRoleDialogComponent } from '../_dialogs/add-role-dialog/add-role-dialog.component';
import { UserResponseDto } from '../api/models';
import { UsersEditorComponent } from './users-editor/users-editor.component';
import { BanDialogComponent } from '../_dialogs/ban-dialog/ban-dialog.component';
import { AdminUserService, UserManagementService } from '../api/services';




@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort!: MatSort;

  // ADD YOUR MODEL HERE
  // TODO: Add model
  public users: UserResponseDto[] = [];
  public admin: Boolean = true;
  // NAME THE COLUMNS YOU WANT TO LIST IN THE TABLE
  // PLEASE CHECK ALSO THE HTML matColumnDef AND element.columnX
  // TODO: Change column names here and in html
  public displayedColumns = ['username', 'email', 'action'];

  public dataSource = new MatTableDataSource(this.users);

  constructor(private adminUserService: AdminUserService, private dialog: MatDialog, private snackbarHelper: SnackbarHelperService, private userManagemant: UserManagementService) {}

  ngOnInit(): void {
    let roles:  string[] =  JSON.parse(localStorage.getItem('roles')!);
    if(roles.indexOf('root') > -1){
      this.admin = false;
    }
    this.initData();
  }

  // GET DATA FROM SERVICE
  private initData(): void {
    // TODO: Add service to get all entries
    this.userManagemant.apiUserManagementGet$Json().subscribe((usersAPI: UserResponseDto[]) => {
      
      this.users = usersAPI;
      this.dataSource = new MatTableDataSource(this.users);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;    
    });
    
    
    /************ DEMO CONTENT END ************/
  }

  // CREATE ENTRY OPEN DIALOG
  public create() {
    const dialogRef = this.dialog.open(UsersEditorComponent, {
      width: '500px'
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.initData();
      }
    });
  }

  // EDIT ENTRY OPEN DIALOG
  public addrole(user: UserResponseDto) {
    
    const dialogRef = this.dialog.open(AddRoleDialogComponent, {
      data: user,
      width: '500px'
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.initData();
      }
    });
  }

  // DELETE ENTRY
  public ban(user: Users): void {
    const dialogRef = this.dialog.open(BanDialogComponent);
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {        
        this.adminUserService.apiAdminUserBanUserIdDelete$Json({id: user.id!}).subscribe(
        () => {
          this.snackbarHelper.openSnackbar('Successfully banned!');
          location.reload();
          },
          (err: any) => {
            this.snackbarHelper.openSnackbar('Error banning user', 'bg-danger');
          }
        );
        this.initData();
      }
    });
  }

  // DEFINE FILTER FOR SEARCH
  public applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}

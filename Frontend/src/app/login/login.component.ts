import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SnackbarHelperService } from '../_helpers/snackbar-helper.service';
import { Observable } from 'rxjs';
import { UserLoginDto } from '../api/models';
import { AuthService } from '../api/services';
import { UserLoginResponseDto } from '../api/models/user-login-response-dto';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  // ADD YOUR MODEL HERE
  // TODO: Add model
  public loginUser: UserLoginDto = {};

  constructor(private router: Router, private snackbarHelper: SnackbarHelperService, private Auth: AuthService) {}

  ngOnInit(): void {}

  // SUBMIT FUNCTION FOR FORM
  public login(): void {
    this.doLogin().subscribe(
      (resp: UserLoginResponseDto) => {
        // TODO: Store data you need
        localStorage.setItem('token', resp.token as string);
        localStorage.setItem('user', JSON.stringify(resp.userResponse));
        localStorage.setItem('roles', JSON.stringify(resp.roles));
        this.router.navigateByUrl('/dashboard');
      },
      (e: any) => {
        this.snackbarHelper.openSnackbar('Error logging in', 'bg-danger');
      }
    );
  }

  // CALL SERVICES FOR PUT OR POST
  private doLogin(): Observable<UserLoginResponseDto> {
    // TODO: Add service for login
    
     return this.Auth.apiAuthLoginPost$Json({body : this.loginUser});

  }

  public register():void{
    this.router.navigateByUrl('/register');
  }
}

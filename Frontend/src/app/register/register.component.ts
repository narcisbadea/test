import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { UserRegisterDto, UserResponseDto } from "../api/models";
import { AuthService } from "../api/services";
import { SnackbarHelperService } from "../_helpers/snackbar-helper.service";



@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
// ADD YOUR MODEL HERE
  // TODO: Add model

  public reqUSer: UserRegisterDto = {};

  constructor(private router: Router, private snackbarHelper: SnackbarHelperService, private Auth: AuthService) {}

  ngOnInit(): void {}

  // SUBMIT FUNCTION FOR FORM
  public register(): void {
    this.doRegister().subscribe(
      (resp: UserResponseDto) => {
        this.snackbarHelper.openSnackbar('Successfully added user!');
        this.router.navigateByUrl('/login');
      },
      (e: any) => {
        this.snackbarHelper.openSnackbar('Error sign up', 'bg-danger');
      }
    );
  }

  // CALL SERVICES FOR PUT OR POST
  private doRegister(): Observable<UserResponseDto> {
    return this.Auth.apiAuthRegisterPost$Json({body: this.reqUSer});
  }
}

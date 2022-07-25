import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class SnackbarHelperService {
  constructor(private snackBar: MatSnackBar) {}

  public openSnackbar(text: string, color = 'bg-success'): void {
    this.snackBar.open(text, '', {
      duration: 4000,
      panelClass: [color],
      horizontalPosition: 'end',
      verticalPosition: 'bottom'
    });
  }
}

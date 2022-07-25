import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { ItemResponseForClientDto } from 'src/app/api/models';
import { AdminItemsService, ClientItemService } from 'src/app/api/services';
import { SnackbarHelperService } from 'src/app/_helpers/snackbar-helper.service';


@Component({
  selector: 'app-approve',
  templateUrl: './approve.component.html',
  styleUrls: ['./approve.component.scss']
})
export class ApproveComponent implements OnInit {
  public imageIds: number[] = [];
  public itemResponse: ItemResponseForClientDto = {};
  public imagesLinks: string[] = [];
  
  constructor(
    @Inject(MAT_DIALOG_DATA) public itemID: number,
    private dialog: MatDialog,
    private snackbarHelper: SnackbarHelperService,
    private itemService: ClientItemService,
    private adminService: AdminItemsService
    ) {     }

  ngOnInit(): void {
    this.getImageIds();
    

    
  }

  getImageIds(): void{
    this.getItem().subscribe((res: ItemResponseForClientDto) =>
    {
      this.imageIds = res.gallery!;
      this.imageIds.forEach((value) => {
        this.imagesLinks.push('http://20.218.86.203:8000/api/Pictures/show/' + value);  
      })
    });
  }
  submit(){
    
    this.itemID;
    this.adminService.apiAdminItemsIdPut({id: this.itemID}).subscribe((res:any)=>{
      console.log(res);
      
      this.snackbarHelper.openSnackbar('Saved successfully');
      this.dialog.closeAll();
      location.reload();
      
    },
    (e: any) => {
      this.snackbarHelper.openSnackbar('Error upload entry', 'bg-danger');
      this.dialog.closeAll();
    });
      
  }

  getItem():Observable<ItemResponseForClientDto>{
    return this.itemService.apiClientItemGetItemByIdIdGet$Json({id: this.itemID as number});
  }

}

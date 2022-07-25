import { Component, Inject, Input, OnInit } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SnackbarHelperService } from 'src/app/_helpers/snackbar-helper.service';
import { Observable } from 'rxjs';
import { BidRequestDto, ItemResponseForClientDto } from 'src/app/api/models';
import { BidsService, ClientItemService, PicturesService } from 'src/app/api/services';


@Component({
  selector: 'app-new-bid',
  templateUrl: './new-bid.component.html',
  styleUrls: ['./new-bid.component.scss'],

})
export class NewBidComponent implements OnInit {
  public bidReq: BidRequestDto = {};
  public imageIds: number[] = [];
  public itemResponse: ItemResponseForClientDto = {};
  public imagesLinks: string[] = [];

  imageObject: Array<object> = [];

  
  constructor(
    @Inject(MAT_DIALOG_DATA) public itemID: number,
    private dialog: MatDialog,
    private snackbarHelper: SnackbarHelperService,
    private bidService: BidsService,
    private pictureService: PicturesService,
    private itemService: ClientItemService
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
      this.imagesLinks.forEach((imageLink) =>{
        this.imageObject.push({
          image: imageLink,
          thumbImage: imageLink,
          title: ''
        })
      })
    });
  }
  submit(){
    this.bidReq.itemId = this.itemID;
    this.bidService.apiBidsPostPost$Json({body: this.bidReq  }).subscribe((response: any) => {
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

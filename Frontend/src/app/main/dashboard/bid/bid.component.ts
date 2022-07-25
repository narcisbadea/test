import { Component, Inject, OnInit } from '@angular/core';
import { SnackbarHelperService } from '../../../_helpers/snackbar-helper.service';
import { Observable } from 'rxjs';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';

import { FormControl, FormGroup } from '@angular/forms';
import { ItemRequestDto, ItemResponseForClientDto, PictureRequestDto, PictureResponseDto } from 'src/app/api/models';
import { ClientItemService, PicturesService } from 'src/app/api/services';

@Component({
  selector: 'app-bid',
  templateUrl: './bid.component.html',
  styleUrls: ['./bid.component.scss']
})
export class BidComponent implements OnInit {
  public isEdit = false;

  // ADD YOUR MODEL HERE
  // TODO: Add model
  public item: ItemRequestDto = {};
  // Variable to store shortLink from api response
  public picture: PictureRequestDto = {};
  public PictureForm!: FormGroup;
  public responsePicture: number[] = [];

  constructor(
    // TODO: Add model
    @Inject(MAT_DIALOG_DATA) public data: ItemRequestDto,
    private dialog: MatDialog,
    private snackbarHelper: SnackbarHelperService,
    private itemService: ClientItemService,
    private pictureService: PicturesService
  ) {}

  ngOnInit(): void {
    this.PictureForm = new FormGroup({
      Description: new FormControl(null),
      TileImage: new FormControl(null)
    });
    this.isEdit = this.data !== null;
    this.item = this.isEdit ? this.data : {};
  }

  // SUBMIT FUNCTION FOR FORM
  public submit(): void {
    this.saveData().subscribe(
      () => {
        this.snackbarHelper.openSnackbar('Saved successfully');
        this.dialog.closeAll();
      },
      (e: any) => {
        this.snackbarHelper.openSnackbar('Error saving entry', 'bg-danger');
        this.dialog.closeAll();
      }
    );
    
    
  }
  // CALL SERVICES FOR PUT OR POST
  private saveData(): Observable<ItemRequestDto> {
    
    this.item.galleryIds = this.responsePicture;
    return this.itemService.apiClientItemAddItemPost$Json({body: this.item});
  }
  onSelectFile(fileInput: any) {
    this.picture.image = <Blob>fileInput.target.files[0];
  }
  private savePic(): Observable<PictureResponseDto>{
    return this.pictureService.apiPicturesPost$Json(
      {
        body: 
        {
        'Image': this.picture.image as Blob,
        'Description': this.picture.description as string
        }
      }
    );
  }
  onSubmit() {
    
    this.savePic().subscribe((result: any) =>
    {
      this.responsePicture.push(result.id);
      
      this.snackbarHelper.openSnackbar('Upload successfully');
    },
    (e: any) => {
      this.snackbarHelper.openSnackbar('Error upload entry', 'bg-danger');
      this.dialog.closeAll();
    })

    this.PictureForm.reset();
  }
}

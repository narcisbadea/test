import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ItemResponseDto, ItemResponseForClientDto } from 'src/app/api/models';
import { AdminItemsService } from 'src/app/api/services/admin-items.service';
import { ClientItemService } from 'src/app/api/services/client-item.service';
import { SnackbarHelperService } from 'src/app/_helpers/snackbar-helper.service';
import { BidComponent } from '../dashboard/bid/bid.component';
import { NewBidComponent } from '../dashboard/new-bid/new-bid.component';;
import { ApproveComponent } from './approve/approve.component';

@Component({
  selector: 'app-item-approve',
  templateUrl: './item-approve.component.html',
  styleUrls: ['./item-approve.component.scss']
})
export class ItemApproveComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort!: MatSort;

  // ADD YOUR MODEL HERE
  // TODO: Add model
  public auctions: ItemResponseDto[] = [];

  // NAME THE COLUMNS YOU WANT TO LIST IN THE TABLE
  // PLEASE CHECK ALSO THE HTML matColumnDef AND element.columnX
  // TODO: Change column names here and in html
  public displayedColumns = ['name', 'desc', 'endTime', 'price', 'action'];

  public items = new MatTableDataSource(this.auctions);

  public length: number = 0;

  constructor(private adminItem: AdminItemsService, private dialog: MatDialog, private snackbarHelper: SnackbarHelperService, private itemService: ClientItemService) {}

  ngOnInit(): void {
    this.adminItem.apiAdminItemsNumbersOfItemsGet$Json().subscribe((result: number) => {
      
      this.paginator.length = result;
      this.initData();
    })
  }

  // GET DATA FROM SERVICE
  private initData(): void {
    this.adminItem.apiAdminItemsUnlisteditemsNrGet$Json({nr: 1}).subscribe((itemsResponse: ItemResponseDto[])=>{
      this.auctions = itemsResponse;
      console.log(this.auctions);
      this.items = new MatTableDataSource(this.auctions);
      //this.items.paginator = this.paginator;
      this.items.sort = this.sort;
    })
  }

  // DEFINE FILTER FOR SEARCH
  public applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.items.filter = filterValue.trim().toLowerCase();

    if (this.items.paginator) {
      this.items.paginator.firstPage();
    }
  }
  public create() {
    const dialogRef = this.dialog.open(BidComponent, {
      width: '500px'
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.initData();
      }
    });

  }

   // EDIT ENTRY OPEN DIALOG
   public approve(itemID:number) {
    const dialogRef = this.dialog.open(ApproveComponent, {
      data: itemID,
      width: '500px'
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.initData();
      }
    });
  }
  nextpage(){
    this.adminItem.apiAdminItemsUnlisteditemsNrGet$Json({nr: (this.paginator.pageIndex + 1)}).subscribe((itemsResponse: ItemResponseDto[])=>{
      this.auctions = itemsResponse;
      
      this.items = new MatTableDataSource(this.auctions);
      this.items.sort = this.sort;
      
    })
  }
}

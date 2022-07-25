import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ItemResponseForClientDto } from 'src/app/api/models';
import { ClientItemService } from 'src/app/api/services/client-item.service';
import { SnackbarHelperService } from 'src/app/_helpers/snackbar-helper.service';


import { BidComponent } from './bid/bid.component';

import { NewBidComponent } from './new-bid/new-bid.component';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort!: MatSort;

  // ADD YOUR MODEL HERE
  // TODO: Add model
  public auctions: ItemResponseForClientDto[] = [];

  // NAME THE COLUMNS YOU WANT TO LIST IN THE TABLE
  // PLEASE CHECK ALSO THE HTML matColumnDef AND element.columnX
  // TODO: Change column names here and in html
  public displayedColumns = ['name', 'desc', 'initialPrice', 'endTime', 'lastBidUserFirstName', 'lastBidPrice', 'action'];

  public items = new MatTableDataSource(this.auctions);

  public length: number = 0;

  constructor(private dialog: MatDialog, private snackbarHelper: SnackbarHelperService, private itemService: ClientItemService) {}

  ngOnInit(): void {
    this.initData();
    this.itemService.apiClientItemNumberOfItemsGet$Json().subscribe((result: number) =>{
      this.paginator.length = result;
    })
    
    
  }

  // GET DATA FROM SERVICE
  private initData(): void {
    this.itemService.apiClientItemGetItemByPageNrGet$Json({nr:1}).subscribe((itemsResponse: ItemResponseForClientDto[])=>{
      this.auctions = itemsResponse;
      this.items = new MatTableDataSource(this.auctions);
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
   public bid(itemID:number) {
    const dialogRef = this.dialog.open(NewBidComponent, {
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
    
    this.itemService.apiClientItemGetItemByPageNrGet$Json({nr:(this.paginator.pageIndex + 1)}).subscribe((itemsResponse: ItemResponseForClientDto[])=>{
      this.auctions = itemsResponse;
      this.items = new MatTableDataSource(this.auctions);
      this.items.sort = this.sort;
      
    })
  }
}

import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { BookdataTableItem } from '../shared/book.model';
import { BookService } from '../shared/book.service';
import { ToastrService } from 'ngx-toastr'

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

  displayedColumns = [    
    'BookId',
    'Name',
    'Text',
    'PurchasePrice',
    'CheckOutUserName',
    'CheckOut',
    'CheckIn'
  ];

  books: BookdataTableItem[];
  dataSource: MatTableDataSource<BookdataTableItem>;

  constructor(private bookService: BookService, private toastr: ToastrService, private changeDetectorRefs: ChangeDetectorRef) {
  }

  ngOnInit() {
    this.dataSource = new MatTableDataSource();
    this.getBooks();
  }

  getBooks() {
    this.bookService.getBooks().subscribe((data: any) => {
      console.log(data);
      console.log('Books');
      this.books = data;
      this.dataSource = new MatTableDataSource<BookdataTableItem>(this.books);
      this.changeDetectorRefs.detectChanges(); 
    });
  }

  checkoutBook(BookId) {
    this.bookService.checkoutBook(BookId)
      .subscribe(
        (data: any) => {
        console.debug(data);  
        if (data == true) {
          this.getBooks();
          this.toastr.success('Book checked out successfully');
        }
        else
          this.toastr.error('Error in checking out book');
      });
  }

  checkinBook(BookId) {
    this.bookService.checkinBook(BookId)
      .subscribe(
        (data: any) => {
          console.debug(data);  
          if (data == true) {
          this.getBooks();
          this.toastr.success('Book checked in successfully');
        }
        else
          this.toastr.error('Error in checking in book');
      });
  }

  disableCheckOutButton(UserId) {
    return (UserId != 0);
  }

  disableCheckinButton(UserId) {
      return (UserId != 0) && (UserId == +localStorage.getItem('UserId'));
  }
}

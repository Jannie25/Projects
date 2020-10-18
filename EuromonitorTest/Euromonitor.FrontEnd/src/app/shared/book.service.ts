import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BookRequest } from './bookrequest.model';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  readonly rootUrl = 'https://localhost:44310';
  constructor(private http: HttpClient) { }

  getBooks() {
    return this.http.get(this.rootUrl + '/api/Book/getbooks');
  }

  checkoutBook(BookId) {
    const body: BookRequest = {
      BookId: BookId,
      CheckOutUserId: +localStorage.getItem('UserId'),
      CheckOutUserName: localStorage.getItem('UserName')
    }
    return this.http.post(this.rootUrl + '/api/Book/checkoutbook', body);
  }

  checkinBook(BookId) {
    const body: BookRequest = {
      BookId: BookId,
      CheckOutUserId: 0,
      CheckOutUserName: ''
    }
    return this.http.post(this.rootUrl + '/api/Book/checkinbook', body);
  }
}

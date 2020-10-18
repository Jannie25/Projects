import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { User } from './user.model';

@Injectable()
export class UserService {
  readonly rootUrl = 'https://localhost:44312';
  constructor(private http: HttpClient) { }

  registerUser(user: User) {
    const body: User = {
      Username: user.Username,
      Password: user.Password,
      Email: user.Email,
      FirstName: user.FirstName,
      LastName: user.LastName
    }
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    return this.http.post(this.rootUrl + '/api/User/register', body,{headers : reqHeader});
  }

  userAuthentication(userName, password) {
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    let params = new HttpParams();
    params = params.append('userName', encodeURIComponent(userName));
    params = params.append('password', encodeURIComponent(password));
    return this.http.get(this.rootUrl + '/api/User/authenticate', { headers: reqHeader, params: params});
  }
}

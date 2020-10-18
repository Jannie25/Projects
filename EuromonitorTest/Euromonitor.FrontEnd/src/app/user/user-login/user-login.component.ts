import { Component, OnInit } from '@angular/core';
import { UserService } from '../../shared/user.service';
import { Router } from '@angular/router';
import { UserLogin } from '../../shared/userlogin.model';
import { AuthenticationResponse } from 'src/app/shared/authenticateresponse.model';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {
  isLoginError : boolean = false;
  userlogin: UserLogin;
  authenticationresponse: AuthenticationResponse;

  constructor(private userService : UserService,private router : Router) { }

  ngOnInit() {
    this.userlogin = {
      Username: '',
      Password: ''
    }
  }
  
  OnSubmit(userName,password){
     this.userService.userAuthentication(userName,password).subscribe((data: any)  => {
        this.authenticationresponse = data;
        if (this.authenticationresponse != null) {
          localStorage.setItem('UserId',String(this.authenticationresponse.userId));
          localStorage.setItem('UserName',this.authenticationresponse.userName);
          localStorage.setItem('UserToken',this.authenticationresponse.userToken);
          this.router.navigate(['/home']);
        }
        else {
          this.isLoginError = true
        }
     }); 
  }
}

import { Routes } from '@angular/router'
import { HomeComponent } from './home/home.component';
import { UserComponent } from './user/user.component';
import { UserRegisterComponent } from './user/user-register/user-register.component';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { AuthGuard } from './auth/auth.guard';

export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent,canActivate:[AuthGuard] },
    {
        path: 'signup', component: UserComponent,
        children: [{ path: '', component: UserRegisterComponent }]
    },
    {
        path: 'login', component: UserComponent,
        children: [{ path: '', component: UserLoginComponent }]
    },
    { path : '', redirectTo:'/login', pathMatch : 'full'}  
];
import { Injectable } from '@angular/core';
import {environment} from '../../environments/environment';
import {BehaviorSubject} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {JwtHelperService} from '@auth0/angular-jwt';
import {Router} from '@angular/router';
import {ToastrService} from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = environment.apiUrl + 'auth/';
  token = new BehaviorSubject<string>(null);
  isloggedin = new BehaviorSubject<boolean>(null);
  username = new BehaviorSubject<string>(null);
  constructor(private http: HttpClient, private jwthelper: JwtHelperService, private router: Router, private tst: ToastrService) {
    this.token.next(localStorage.getItem('token'));
    if (!this.isExpired(localStorage.getItem('token'))) {
      this.isloggedin.next(true);
      this.username.next(this.jwthelper.decodeToken(this.token.value).unique_name);
    }
  }
  register(model: any){
    return this.http.post(this.baseUrl + 'register', model);
  }
  login(model: any){
    return this.http.post(this.baseUrl , model);
  }
  loggedin(token: string){
    this.token.next(token);
    this.username.next(this.jwthelper.decodeToken(token).unique_name);
    this.tst.success('Welcome ' + this.jwthelper.decodeToken(token).unique_name + '!!', 'Welcome');
    this.isloggedin.next(true);
    this.router.navigateByUrl('/');
  }
  isExpired(to: string){
    console.log('token is ' + to);
    return this.jwthelper.isTokenExpired(to);
  }
}

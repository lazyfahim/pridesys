import { Component, OnInit } from '@angular/core';
import {AuthService} from '../../_services/auth.service';
import {JwtHelperService} from '@auth0/angular-jwt';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  isloggedin: boolean;
  token: string;
  username:string;

  constructor(private  auth: AuthService, private helper: JwtHelperService) {
    this.auth.isloggedin.subscribe(val => this.isloggedin = val);
    this.auth.username.subscribe(val => this.username = val);
    console.log(this.username);
  }

  ngOnInit(): void {
  }

}

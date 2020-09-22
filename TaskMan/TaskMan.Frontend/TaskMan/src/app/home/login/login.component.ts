import { Component, OnInit } from '@angular/core';
import {UserRegisterModel} from '../../_models/Register';
import {AuthService} from '../../_services/auth.service';
import {ToastrService} from 'ngx-toastr';
import {JwtHelperService} from '@auth0/angular-jwt';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  model: UserRegisterModel;
  constructor(private authservice: AuthService,private toastservice:ToastrService,private helper: JwtHelperService) {
    this.model = new UserRegisterModel();
  }

  ngOnInit(): void {

  }
  login(loginForm: any) {
    console.log(this.model);
    if(this.model.username == null || this.model.password == null)
      this.toastservice.error("username and password cannot be null","error");
    else {
      this.authservice.login(this.model).subscribe(
        (res:any)=>{
          console.log(res);
          if(res.succeeded){
            localStorage.setItem('token',res.token);
            this.authservice.loggedin(res.token);
          }
        }, error => {
          console.log(error);
          this.toastservice.error(error.error,'error');
        }
      );
    }
  }

}

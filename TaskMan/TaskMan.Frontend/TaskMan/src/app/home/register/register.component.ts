import { Component, OnInit } from '@angular/core';
import {UserRegisterModel} from '../../_models/Register';
import {AuthService} from '../../_services/auth.service';
import {ToastrService} from 'ngx-toastr';
import {JwtHelperService} from '@auth0/angular-jwt';
import {Route, Router} from '@angular/router';
import {HttpErrorResponse} from '@angular/common/http';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  model: UserRegisterModel;
  constructor(private authservice: AuthService,private toastservice:ToastrService,private helper: JwtHelperService,private router:Router) {
    this.model = new UserRegisterModel();
  }

  ngOnInit(): void {
  }
  register(registerForm){
    if(this.model.password != this.model.confirmpassword){
      this.toastservice.error("Password and Confirm password should be matched",'Error!!!');
      return;
    }else{
      this.authservice.register(this.model).subscribe((res:any)=>{
        this.toastservice.success("User Created","Success");
        this.authservice.isloggedin.subscribe((val)=>{
          if(val == true)
            this.router.navigateByUrl('admin/users');
          else
            this.router.navigateByUrl('/login');
        });
      },(error:HttpErrorResponse) => {
        console.log(error.error.errors);
        if(error.error.errors == null){
          console.log(error);
          error.error.forEach((err)=>this.toastservice.error(err,"error"));
        }
        else{
          const validationErrorDicionary = JSON.parse(JSON.stringify(error.error.errors));
          for(var fieldName in validationErrorDicionary){
            if(validationErrorDicionary.hasOwnProperty(fieldName)){
              this.toastservice.error(validationErrorDicionary[fieldName],"error");
            }
          }
        }

      });
    }
  }
}

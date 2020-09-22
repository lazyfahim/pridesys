import { Component, OnInit } from '@angular/core';
import {Task} from '../../_models/task.model';
import {TaskService} from '../../_services/task.service';
import {ActivatedRoute, Router} from '@angular/router';
import {ToastrService} from 'ngx-toastr';
import {AuthService} from '../../_services/auth.service';

export interface User{
  id:number;
  userName:string;
  email:string;
  address:string;
  phoneNumber:string;
}
@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})

export class UsersComponent implements OnInit {

  users: User[];
  totalPage ;
  pagenumber = 1;
  constructor(private service: AuthService, private router: Router,private toastr: ToastrService,
              private route: ActivatedRoute) {
    console.log("inited");
    this.pagenumber =(this.route.snapshot.queryParams['pageNumber']==null?1:this.route.snapshot.queryParams['pageNumber']);
    console.log(this.pagenumber);
    this.loadPage(this.pagenumber);
  }

  ngOnInit(): void {

  }
  loadPage(page){
    console.log(page);
    this.router.navigate([], {
      queryParams: {
        'pageNumber': page
      }
    });
    this.service.getUsers(page).subscribe((res:any)=>{
      if(res.succeeded){
        console.log(res);
        this.users = res.users;
        this.totalPage = res.totaldisplay;
      }
    });
  }

}

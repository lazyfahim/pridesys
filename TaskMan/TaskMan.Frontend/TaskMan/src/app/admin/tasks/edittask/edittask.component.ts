import { Component, OnInit } from '@angular/core';
import {Observable} from 'rxjs';
import {Dropdownuser} from '../../../_models/dropdownuser.model';
import {TaskService} from '../../../_services/task.service';
import {Taskdetails} from '../../../_models/taskdetails.model';
import {ActivatedRoute, Router} from '@angular/router';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-edittask',
  templateUrl: './edittask.component.html',
  styleUrls: ['./edittask.component.scss']
})
export class EdittaskComponent implements OnInit {

  users: Observable<Dropdownuser[]>;
  task: Taskdetails;
  id: string;
  constructor(private taskservice:TaskService,private  route:ActivatedRoute,private toastr: ToastrService,private router:Router) {
    this.task = new Taskdetails();
    this.id = this.route.snapshot.paramMap.get('id');
    taskservice.getTask(this.id)
      .subscribe((res: Taskdetails) =>{
        this.task = res;
      });
    taskservice.getUsersDropDown().subscribe(
      (res:any) =>{
        if(res.succeeded){
          console.log(res.users);
          this.users = new Observable<Dropdownuser[]>(
            (observer) =>
              observer.next(res.users)
          );
        }
      }
    );
  }

  ngOnInit(): void {
  }
  submit(){
    this.taskservice.updateTask(this.task)
      .subscribe((res)=>{
        this.toastr.success("updated successfully","success");
          this.router.navigateByUrl('/admin/task');
        }
        ,error => {
        this.toastr.error(error.error,"Error!!!");
        }
      );
  }

}

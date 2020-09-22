import { Component, OnInit } from '@angular/core';
import {Observable} from 'rxjs';
import {Dropdownuser} from '../../../_models/dropdownuser.model';
import {TaskService} from '../../../_services/task.service';
import {Task} from '../../../_models/task.model';
import {ToastrService} from 'ngx-toastr';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-newtask',
  templateUrl: './newtask.component.html',
  styleUrls: ['./newtask.component.scss']
})
export class NewtaskComponent implements OnInit {

  users: Observable<Dropdownuser[]>;
  task: Task;
  constructor(private taskservice:TaskService,private toastr:ToastrService,private route: Router) {
    this.task = new Task();
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
    console.log(this.task);
    this.taskservice.postTask(this.task).subscribe(res => {
      this.toastr.success("created successfully");
      this.route.navigateByUrl('/admin/task');
    });
  }

}

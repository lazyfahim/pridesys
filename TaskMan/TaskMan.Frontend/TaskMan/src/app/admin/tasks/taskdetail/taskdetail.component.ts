import { Component, OnInit } from '@angular/core';
import {Taskdetails} from '../../../_models/taskdetails.model';
import {TaskService} from '../../../_services/task.service';
import {ToastrService} from 'ngx-toastr';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-taskdetail',
  templateUrl: './taskdetail.component.html',
  styleUrls: ['./taskdetail.component.scss']
})
export class TaskdetailComponent implements OnInit {

  task:Taskdetails;
  id:string;
  constructor(private service:TaskService,private toastr:ToastrService,private route:ActivatedRoute) {
    this.id = this.route.snapshot.paramMap.get('id');
    service.getTask(this.id).subscribe((res:any) => this.task = res,error => toastr.error(error.error,"Error happend!!!"));
  }

  ngOnInit(): void {
  }

}

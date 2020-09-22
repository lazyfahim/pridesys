import { Component, OnInit } from '@angular/core';
import {Task} from '../../../_models/task.model';
import {TaskService} from '../../../_services/task.service';
import {ActivatedRoute, Router} from '@angular/router';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-mytasks',
  templateUrl: './mytasks.component.html',
  styleUrls: ['./mytasks.component.scss']
})
export class MytasksComponent implements OnInit {

  tasks: Task[];
  totalPage ;
  pagenumber = 1;
  constructor(private service: TaskService, private router: Router,private toastr: ToastrService,
              private route: ActivatedRoute) {
    this.pagenumber =(this.route.snapshot.queryParams['pageNumber']==null?1:this.route.snapshot.queryParams['pageNumber']);
    this.loadPage(this.pagenumber);
  }

  ngOnInit(): void {
  }
  delete(id){
    this.service.deleteTask(id).subscribe(res => {
        this.toastr.success("deleted successfully","success!!!");
        this.loadPage(this.pagenumber);
      },
      error =>this.toastr.error(error.error,"error!!!") );
  }
  loadPage(page:number){
    this.router.navigate([], {
      queryParams: {
        'pageNumber': page
      }
    });
    this.service.getAssignedTasks(page).subscribe((res:any)=>{
      if(res.succeeded){
        console.log(res.tasks);
        this.tasks = res.tasks;
        this.totalPage = res.display;
        console.log(this.tasks);
      }
    });
  }
}

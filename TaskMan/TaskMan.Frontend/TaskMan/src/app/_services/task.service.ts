import { Injectable } from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Task} from '../_models/task.model';
import {Taskdetails} from '../_models/taskdetails.model';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  constructor(private http:HttpClient) { }
  baseurl = environment.apiUrl+'task/';
  getUsersDropDown(){
    return this.http.get(this.baseurl+'users');
  }
  postTask(task:Task){
    return this.http.post(this.baseurl+"create",task);
  }
  getOwnedTasks(page:number){
    return this.http.get(this.baseurl+"created/?page="+page);
  }
  getAssignedTasks(page:number){
    return this.http.get(this.baseurl+"assigned/?page="+page);
  }
  getTask(id){
    return this.http.get(this.baseurl+id);
  }
  deleteTask(id:number){
    return this.http.delete(this.baseurl+id);
  }
  updateTask(task: Taskdetails){
    return this.http.put(this.baseurl,task);
  }
}

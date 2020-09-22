import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {NewtaskComponent} from './tasks/newtask/newtask.component';
import {TasksComponent} from './tasks/tasks.component';
import {EdittaskComponent} from './tasks/edittask/edittask.component';
import {AdminComponent} from './admin/admin.component';
import {MytasksComponent} from './tasks/mytasks/mytasks.component';
import {TaskdetailComponent} from './tasks/taskdetail/taskdetail.component';
import {UsersComponent} from './users/users.component';

const routes: Routes = [
  {
    path: '',
    children: [
      { path: '', component:AdminComponent},
      { path:'users',component:UsersComponent},
      {path: 'task', children: [
          { path: '', component: TasksComponent },
          { path: 'details/:id',component:TaskdetailComponent},
          { path: 'new' , component: NewtaskComponent},
          { path: 'edit/:id', component: EdittaskComponent},
          { path: 'my', component: MytasksComponent}
        ]}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }

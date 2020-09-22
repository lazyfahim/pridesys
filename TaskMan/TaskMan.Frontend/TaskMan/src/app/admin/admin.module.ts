import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { TasksComponent } from './tasks/tasks.component';
import { NewtaskComponent } from './tasks/newtask/newtask.component';
import {CKEditorModule} from 'ckeditor4-angular';
import {HTTP_INTERCEPTORS} from '@angular/common/http';
import {TokenInterceptor} from '../_interceptors/token.interceptor';
import {FormsModule} from '@angular/forms';
import {NgbPaginationModule} from '@ng-bootstrap/ng-bootstrap';
import { EdittaskComponent } from './tasks/edittask/edittask.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { AdminComponent } from './admin/admin.component';
import { MytasksComponent } from './tasks/mytasks/mytasks.component';
import { TaskdetailComponent } from './tasks/taskdetail/taskdetail.component';
import {EscapeHtmlPipe} from '../pipes/keep-html.pipe';
import { UsersComponent } from './users/users.component';


@NgModule({
  // tslint:disable-next-line:max-line-length
  declarations: [TasksComponent, NewtaskComponent, EdittaskComponent, AdminComponent, MytasksComponent, TaskdetailComponent, EscapeHtmlPipe, UsersComponent],
  imports: [
    CommonModule,
    AdminRoutingModule,
    CKEditorModule,
    FormsModule,
    NgbPaginationModule
  ],
  providers:[
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    }
  ]
})
export class AdminModule { }

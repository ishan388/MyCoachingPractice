import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginandregisterComponent } from './loginandregister/loginandregister.component';
import { ManageteacherdetailsComponent } from './teacherops/manageteacherdetails/manageteacherdetails.component';
import { ManagestudentdetailsComponent } from './studentops/managestudentdetails/managestudentdetails.component';
import { TeacherdashboardComponent } from './teacherops/teacherdashboard/teacherdashboard.component';
import { StudentdashboardComponent } from './studentops/studentdashboard/studentdashboard.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginandregisterComponent,
    ManageteacherdetailsComponent,
    TeacherdashboardComponent,
    StudentdashboardComponent,
    ManagestudentdetailsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

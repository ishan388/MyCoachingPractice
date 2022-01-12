import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginandregisterComponent } from './loginandregister/loginandregister.component';
import { ManagestudentdetailsComponent } from './studentops/managestudentdetails/managestudentdetails.component';
import { StudentdashboardComponent } from './studentops/studentdashboard/studentdashboard.component';
import { ManageteacherdetailsComponent } from './teacherops/manageteacherdetails/manageteacherdetails.component';
import { TeacherdashboardComponent } from './teacherops/teacherdashboard/teacherdashboard.component';

const routes: Routes = [
  {
    path: '', redirectTo: 'login', pathMatch: 'full'
  },
  {
    path: 'login', component: LoginandregisterComponent
  },
  {
    path: 'manageteacherdetails', component: ManageteacherdetailsComponent
  },
  {
    path: 'teacherdashboard', component: TeacherdashboardComponent
  },
  {
    path: 'managestudentdetails', component: ManagestudentdetailsComponent
  },
  {
    path: 'studentdashboard', component: StudentdashboardComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

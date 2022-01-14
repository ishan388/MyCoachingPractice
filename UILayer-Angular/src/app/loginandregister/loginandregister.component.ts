import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Response } from '../viewmodels/response.model';
import { LoginandregisterService } from './loginandregister.service';

@Component({
  selector: 'app-loginandregister',
  templateUrl: './loginandregister.component.html',
  styleUrls: ['./loginandregister.component.css']
})
export class LoginandregisterComponent implements OnInit {

  constructor(public service: LoginandregisterService, private router: Router) { }

  ngOnInit(): void {
  }

  registerOnClick() {
    this.service.registerStudent().subscribe(
      (res: any) => {
        this.service.registerResponse.message = res.message;
        this.service.registerResponse.isSuccess = res.isSuccess;
        this.service.clearRegisterForm();
        setTimeout(() => {
          this.service.registerResponse = new Response();
        }, 4000);
      },
      err => {
        console.log(err);
      }
    )
  }

  loginOnClick() {
    this.service.login().subscribe(
      (res: any) => {
        debugger;
        if (!res.isSuccess) {
          this.service.loginResponse.message = res.message;
          this.service.loginResponse.isSuccess = res.isSuccess;
        }
        else {
          this.service.clearLoginForm();
          if (res.data.roleId == 2)
            this.router.navigate(['studentdashboard']);
          else
            this.router.navigate(['teacherdashboard']);
        }
      },
      err => {
        console.log(err);
      }
    )
  }

}

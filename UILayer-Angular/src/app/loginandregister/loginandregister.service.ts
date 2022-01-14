import { Injectable } from '@angular/core';
import { UsersVM } from '../viewmodels/usersvm.model';
import { Response } from '../viewmodels/response.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginandregisterService {

  readonly apiUrl: string = 'https://localhost:7231/api/';
  constructor(private http: HttpClient) { }

  registerFormData: UsersVM = new UsersVM();
  registerResponse: Response = new Response();
  loginResponse: Response = new Response();
  loginFormData: UsersVM = new UsersVM();

  registerStudent() {
    return this.http.post(this.apiUrl + 'Users', this.registerFormData);
  }

  login() {
    debugger;
    console.log(this.loginFormData);
    return this.http.post(this.apiUrl + 'Users/Login', this.loginFormData);
  }

  clearRegisterForm() {
    this.registerFormData = new UsersVM();
  }

  clearLoginForm() {
    this.loginFormData = new UsersVM();
    this.loginResponse = new Response();
  }

}

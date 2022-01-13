import { Injectable } from '@angular/core';
import { UsersVM } from '../viewmodels/usersvm.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginandregisterService {

  readonly apiUrl: string = 'https://localhost:7231/api/';
  constructor(private http: HttpClient) { }

  formData: UsersVM = new UsersVM();

  registerStudent() {
    console.log(this.formData);
    return this.http.post(this.apiUrl + 'Users', this.formData);
  }

  clearForm() {
    this.formData = new UsersVM();
  }

}

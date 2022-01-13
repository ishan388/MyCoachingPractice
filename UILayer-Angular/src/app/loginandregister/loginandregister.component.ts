import { Component, OnInit } from '@angular/core';
import { LoginandregisterService } from './loginandregister.service';

@Component({
  selector: 'app-loginandregister',
  templateUrl: './loginandregister.component.html',
  styleUrls: ['./loginandregister.component.css']
})
export class LoginandregisterComponent implements OnInit {

  constructor(public service: LoginandregisterService) { }

  ngOnInit(): void {
  }

  registerOnClick() {
    this.service.registerStudent().subscribe(
      (res: any) => {
        console.log(res);
        alert(res.message);
        this.service.clearForm();
      },
      err => {
        console.log(err);
      }
    )
  }

}

import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login-register-page',
  templateUrl: './login-register-page.component.html',
  styleUrls: [],
})
export class LoginRegisterPageComponent implements OnInit {
  emailProperty: string = '';

  constructor() { }

  ngOnInit(): void {
  }

  public login(): void{
    localStorage.setItem('userInfo', JSON.stringify({ name: 'Mike', token: 'asdfasdf'}) );
  }

  changeProperty(): void {
    this.emailProperty = "la cambie :)";
  }
}

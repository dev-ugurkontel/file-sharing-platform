import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/_models';
import { AuthenticationService } from 'src/app/_services';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm : FormGroup;
  returnUrl : string;

  constructor(
    private fb : FormBuilder,
    private route: ActivatedRoute,
    private router : Router,
    private _auth : AuthenticationService
  ) {}

  ngOnInit(): void {
    this.createForm();
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  get f(){
    return this.loginForm.value;
  }

  createForm() {
    this.loginForm = this.fb.group({
      userName : [ 'user1', [Validators.required] ],
      password : [ '123456', [Validators.required] ]
    })
  }

  async submit() {
    const { userName, password } = this.f;
    const user : User = await this._auth.logIn(userName, password).toPromise();
    this.router.navigate(['/home']);
  }
  
}
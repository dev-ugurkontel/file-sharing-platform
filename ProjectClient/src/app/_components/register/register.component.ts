import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/_models';
import { AuthenticationService } from 'src/app/_services';

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

    registerForm : FormGroup;
    
    constructor(
        private fb : FormBuilder,
        private route: ActivatedRoute,
        private router : Router,
        private _auth : AuthenticationService
    ) {}

    ngOnInit(): void {
        this.createForm();
    }

    get f () {
        return this.registerForm.value;
    }

    createForm() {
        this.registerForm = this.fb.group({
            userName : ['', [Validators.required]],
            password : ['', [Validators.required]]
        })
    }

    async submit(){
        const {userName, password} = this.f;
        const user : User = await this._auth.signUp(userName, password).toPromise();
        this.router.navigate(['/home']);
    }
    
}
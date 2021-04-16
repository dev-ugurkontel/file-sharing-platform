import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { map } from "rxjs/operators";
import { User } from "../../_models";
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  public userSubject: BehaviorSubject<User>;

  constructor(private http: HttpClient) {
    this.userSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('user')));
  }

  public get userValue(): User {
    return this.userSubject.value;
  }

  // login
  logIn(userName: string, password: string) {
    const url: string = `${environment.apiUrl}auth/login`;
    const body: any = { userName: userName, password: password };
    return this.http.post<any>(url, body)
      .pipe(map(res => {
        const user: User = {
          uid: res.userId, 
          userName: res.userName,
          token: res.token, 
          refreshToken: res.refreshToken
        };
        this.userSubject.next(user);
        localStorage.setItem('user', JSON.stringify(user));
        return user;
      }));
  }

  // register
  signUp(userName: string, password: string) {
    const url: string = `${environment.apiUrl}auth/register`;
    const body: any = { userName: userName, password: password };
    return this.http.post<any>(url, body)
      .pipe(map(res => {
        const user: User = {
          uid: res.userId, 
          userName: res.userName, 
          token: res.token, 
          refreshToken: res.refreshToken
        };
        this.userSubject.next(user);
        localStorage.setItem('user', JSON.stringify(user));
        return user;
      }));
  }

  // refreshToken
  refreshToken() {
    const url: string = `${environment.apiUrl}auth/RefreshToken`;

    const body: any = {
      token : this.userValue.token
    };

    return this.http.post<any>(url, body)
      .pipe(map((token) => {
        const user: User = {
          uid: this.userValue.uid,
          userName: this.userValue.userName,
          token: token.token,
          refreshToken: this.userValue.refreshToken
        }
        this.userSubject.next(user);
        localStorage.setItem('user', JSON.stringify(user));
        return user;
      }));
  }

  // logout
  logout() {
    const url: string = `${environment.apiUrl}auth/token/${this.userValue.refreshToken}`;
    let options = {
      headers: new HttpHeaders().set('Content-Type', 'application/json')
    }
    this.http.delete<any>(url, options).subscribe();
      localStorage.removeItem('user');
      this.userSubject.next(null);    
  }

}
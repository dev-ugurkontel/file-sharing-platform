import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from "../../_models";
import { AuthenticationService } from 'src/app/_services';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GetService {

  public userSubject: BehaviorSubject<User>;

  constructor(
    private http: HttpClient,
    private authenticationService: AuthenticationService
  ) { 
    this.userSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('user')));
  }

  public get userValue(): User {
    return this.userSubject.value;
  }

  getAllFiles(){
    let currentUser = this.authenticationService.userValue;

    const url : string = `${environment.apiUrl}users/${currentUser.uid}/files`;

    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('Authorization', `Bearer ${currentUser.token}`)

    return this.http.get<any>(url, { headers }).toPromise(); 
  }

  getAllUsers(){
    let currentUser = this.authenticationService.userValue;

    const url : string = `${environment.apiUrl}users`;

    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('Authorization', `Bearer ${currentUser.token}`);

    const params = new HttpParams().set('userId', `${currentUser.uid}`);

    return this.http.get<any>(url, { headers, params }).toPromise(); 
  }
  
}

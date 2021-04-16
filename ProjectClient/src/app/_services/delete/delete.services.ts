import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AuthenticationService } from 'src/app/_services';

@Injectable({
  providedIn: 'root'
})
export class DeleteService {

  constructor(
    private http: HttpClient,
    private authenticationService: AuthenticationService
  ) { }s

  delete(id: number){
    let currentUser = this.authenticationService.userValue;

    const url : string = `${environment.apiUrl}files/${id}`;    

    let options = {
      headers : new HttpHeaders() .set('Content-Type', 'application/json')
                                  .set('Authorization', `Bearer ${currentUser.token}`)
    }
    
    return this.http.delete<any[]>(url, options).toPromise();
  }
  
}

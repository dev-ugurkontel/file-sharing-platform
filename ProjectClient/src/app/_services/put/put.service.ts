import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthenticationService } from 'src/app/_services';

@Injectable({
  providedIn: 'root'
})
export class PutService {

  constructor(
    private http: HttpClient,
    private authenticationService: AuthenticationService,
  ) { }

  update(id: number, description: string): Observable<HttpEvent<any>> {
    let currentUser = this.authenticationService.userValue;

    const formData: FormData = new FormData();

    formData.append('description', description);
    
    const req = new HttpRequest('PUT', `${environment.apiUrl}files/${id}`, formData, {
      reportProgress: true,
      responseType: 'json'
    });
    

    return this.http.request(req);
  }
  
}

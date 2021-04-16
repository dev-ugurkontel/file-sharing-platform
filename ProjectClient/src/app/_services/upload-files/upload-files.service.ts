import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthenticationService } from 'src/app/_services';

@Injectable({
  providedIn: 'root'
})
export class UploadFilesService {

  constructor(
    private http: HttpClient,
    private authenticationService : AuthenticationService,
  ) { }

  upload(file: File, usersIds: any[], fileName: string, description: string, shareState: number): Observable<HttpEvent<any>> {
    let currentUser = this.authenticationService.userValue;

    const formData: FormData = new FormData();

    if (!shareState) {
      usersIds = [];
      shareState = 0;
    } else if (shareState && usersIds.length == 0)
      shareState = 1;
      else if (shareState && usersIds.length > 0)
      shareState = 2;

    formData.append('file', file);
    formData.append('fileName', fileName);
    formData.append('description', description);
    formData.append('shareState', `${shareState}`);
    formData.append('userId', `${currentUser.uid}`);
    formData.append('UsersIds', JSON.stringify(usersIds));
    
    const req = new HttpRequest('POST', `${environment.apiUrl}files`, formData, {
      reportProgress: true,
      responseType: 'json'
    });

    return this.http.request(req);
  }

  getFiles(): Observable<any> {
    return this.http.get(`${environment.apiUrl}files`);
  }
}
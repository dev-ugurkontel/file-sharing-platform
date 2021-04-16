import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Get, Delete, Put } from 'src/app/_models';
import { AuthenticationService, GetService, UploadFilesService, DeleteService, PutService } from 'src/app/_services';
import { Observable } from 'rxjs';
import { HttpEventType, HttpResponse } from '@angular/common/http';
import { FormGroup, FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { FileSaverService } from 'ngx-filesaver';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  usersForm: FormGroup;
  sharedState: boolean = false;
  fileName: string = '';
  description: string = '';
  users : any[] = [];
  gets : Get[];
  delete: Delete[];
  put: Put[];
  selectedFiles?: FileList;
  progressInfos: any[] = [];
  message: string[] = [];  
  fileInfos?: Observable<any>;  
  userId : string = this._auth.userValue.uid;

  constructor(
    private router : Router,
    private _auth : AuthenticationService,
    private _get : GetService,
    private _delete : DeleteService,
    private _put : PutService,
    private uploadService: UploadFilesService,
    private fb: FormBuilder,
    private _httpClient: HttpClient,
    private _FileSaverService: FileSaverService
  ) 
  { }

  ngOnInit(): void {
    this.getAllFiles();    
    this.getAllUsers();
    this.usersForm = this.fb.group({
      selectedUsersIds: []
    });
  }

  selectAll() {
    this.usersForm.get('selectedUsersIds').patchValue(this.users.map(x => x.id));
  }

  unselectAll() {
    this.usersForm.get('selectedUsersIds').patchValue([]);
  }

  checkMime(mime: string) {
    const videoMimes = ['video/x-flv', 'video/mp4', 'application/x-mpegURL', 'video/MP2T', 'video/3gpp', 'video/quicktime', 'video/x-msvideo', 'video/x-ms-wmv'];
    const imgMimes = ['image/bmp', 'image/gif', 'image/jpeg', 'image/svg+xml', 'image/tiff', 'image/png', 'image/webp'];
    if (videoMimes.includes(mime.toLowerCase()))
      return 1;
    else if (imgMimes.includes(mime.toLowerCase()))
      return 2;
    return 0;
  }

  toggleCheckAll(values: any) {
    if (values.currentTarget.checked)
      this.selectAll();
    else
      this.unselectAll();
  }

  toggleRadioAll(values: any) {
    if(!this.sharedState)
      this.unselectAll();
  }

  async getAllFiles() {
    this.gets = await this._get.getAllFiles();
  }

  async getAllUsers() {
    this.users = await this._get.getAllUsers();
  }

  logout() {
    this._auth.logout();
    this.router.navigate(['/login']);
  }

  selectFiles(event): void {
    this.message = [];
    this.progressInfos = [];
    this.selectedFiles = event.target.files;
  }

  deleteFile(id: number): void {
    this._delete.delete(id);
    setTimeout(() => {
      this.getAllFiles();    
    }, 250);    
  }

  editDescription(id: number, description: string) {
    this._put.update(id, (<HTMLInputElement>document.getElementById(description)).value).subscribe((event: any) => {
      if (event instanceof HttpResponse) {
        alert("updated successfully");
      }
    },
    (err: any) => {
      alert("update failed");
    });
  }

  uploadFiles(): void {
    if (this.fileName.length > 0) {
      if (this.fileName.length <= 50) {
        if (this.description.length <= 500) {
          this.message = [];    
          if (this.selectedFiles) {
            for (let i = 0; i < this.selectedFiles.length; i++) {
              this.upload(i, this.selectedFiles[i]);
            }
          }
        } else
            alert("The description can be up to 500 characters long");
      } else
          alert("The file name can be up to 50 characters long");
    } else
        alert("Enter a filename");
  }

  upload(idx: number, file: File): void {
    this.progressInfos[idx] = { value: 0, fileName: file.name };
    let item = [];
    if (this.sharedState && this.usersForm.value.selectedUsersIds) {
      for (let i = 0; i < this.usersForm.value.selectedUsersIds.length; i++) {
        item.push({
          id: this.usersForm.value.selectedUsersIds[i]
        })
      }
    }
    
    if (file) {
      this.uploadService.upload(file, item, this.fileName, this.description, this.sharedState ? 1 : 0).subscribe(
        (event: any) => {
          if (event.type === HttpEventType.UploadProgress) {
            this.progressInfos[idx].value = Math.round(100 * event.loaded / event.total);
          } else if (event instanceof HttpResponse) {
            const msg = 'Uploaded the file successfully: ' + file.name;
            this.message.push(msg);
            this.ngOnInit();
          }
        },
        (err: any) => {
          this.progressInfos[idx].value = 0;
          const msg = 'Could not upload the file: ' + file.name;
          this.message.push(msg);
        });
    }    
  }

  onDown(filePath: string, fileDownloadName: string) {
    this._httpClient.get(`${environment.apiBaseUrl}${filePath}`, {
        observe: 'response',
        responseType: 'blob'
      }).subscribe(res => {
        this._FileSaverService.save(res.body, fileDownloadName);
      });
      return;
  }
  
}
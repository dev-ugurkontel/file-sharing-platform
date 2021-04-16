import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Post } from "../../_models";
import { AuthenticationService } from 'src/app/_services';

@Injectable({
  providedIn: 'root'
})
export class PostService { }
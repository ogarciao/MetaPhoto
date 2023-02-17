import { HttpClient, HttpErrorResponse, HttpParams, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Photo } from '../dtos/photo';
import { environment } from '../environment/environment';

@Injectable({
  providedIn: 'root'
})
export class PhotosService {
  private readonly apiRoot = environment.apiRoot;

  constructor(private http: HttpClient) { }

  getPhotos(title?: string, albumTitle?: string, email?:string, limit?: number, offset?: number): Observable<HttpResponse<Photo[]>> {
    let params = new HttpParams();
    params = title ? params.append('title', title) : params;
    params = albumTitle ? params.append('albumTitle', albumTitle) : params;
    params = email ? params.append('email', email) : params;
    params = limit ? params.append('limit', limit) : params;
    params = offset ? params.append('offset', offset) : params;

    return this.http.get<Photo[]>(`${this.apiRoot}/photos`, {
      observe: "response",
      params: params
    });
  }
}

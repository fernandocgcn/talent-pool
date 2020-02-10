import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { BaseService } from './base.service';
import { Developer } from '../models/developer';
import { Availability } from '../models/availability';

@Injectable({
  providedIn: 'root'
})
export class DeveloperService extends BaseService {

  constructor(private httpClient: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {
    super();
    this.baseUrl += 'developer/';
  }

  public getAll(): Observable<Developer[]> {
    return (
      this.httpClient.get<Developer[]>
        (this.baseUrl, super.httpOptions)
        .pipe(catchError(super.handleError))
    );
  }

  public get(developer: Developer): Observable<any> {
    return (
      this.httpClient.get<any>
        (this.baseUrl + 'id/' + developer.developerId, super.httpOptions)
        .pipe(catchError(super.handleError))
    );
  }

  public save(developerDto: any): Observable<number> {
    return (
      this.httpClient.post<number>
        (this.baseUrl, developerDto, super.httpOptions)
        .pipe(catchError(super.handleError))
    );
  }

  public delete(id: number): Observable<number> {
    return (
      this.httpClient.delete<number>
        (this.baseUrl + id, super.httpOptions)
        .pipe(catchError(super.handleError))
    );
  }

}

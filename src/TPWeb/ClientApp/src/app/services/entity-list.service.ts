import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { BaseService } from './base.service';
import { Availability } from '../models/availability';
import { WorkingTime } from '../models/working-time';

@Injectable({
  providedIn: 'root'
})
export class EntityListService extends BaseService {

  constructor(private httpClient: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {
    super();
    this.baseUrl += 'entitylist/';
  }

  public getAvailabilities(): Observable<Availability[]> {
    return (
      this.httpClient.get<Availability[]>
        (this.baseUrl + 'availabilities', super.httpOptions)
        .pipe(catchError(super.handleError))
    );
  }

  public getWorkingTimes(): Observable<WorkingTime[]> {
    return (
      this.httpClient.get<WorkingTime[]>
        (this.baseUrl + 'workingtimes', super.httpOptions)
        .pipe(catchError(super.handleError))
    );
  }

}

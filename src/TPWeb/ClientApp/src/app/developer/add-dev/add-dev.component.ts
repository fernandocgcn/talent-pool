import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Developer } from '../../view-models/developer';

@Component({
  selector: 'app-add-dev',
  templateUrl: '../developer.component.html',
  styleUrls: ['../developer.component.css']
})
export class AddDevComponent {
  public developer: Developer = new Developer;
  public errors: string[];

  constructor(private httpClient: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  save(): void {
    this.errors = [];
    this.httpClient.post(this.baseUrl + 'developer', this.developer)
      .toPromise()
      .then(result => console.log(result))
      .catch(httpError => this.errorsHandle(httpError.error.errors));
  }

  private errorsHandle(httpErrors: any): void {
    for (const httpError in httpErrors) {
      this.errors.push(httpErrors[httpError][0]);
    }
    this.errors = this.errors.reverse();
  }
}

import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Developer } from '../../view-models/developer';

@Component({
  selector: 'app-frm-dev',
  templateUrl: './frm-dev.component.html',
  styleUrls: ['./frm-dev.component.css']
})
export class FrmDevComponent {
  public developer: Developer;
  public messages: string[];

  constructor(private httpClient: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private router: Router) {
    const nav = this.router.getCurrentNavigation();
    this.developer = nav.extras.state.developer;
  }

  save(): void {
    this.messages = [];
    this.httpClient.post(this.baseUrl + 'developer', this.developer)
      .toPromise()
      .then(result => this.messages.push('Operação realizada com sucesso!'))
      .catch(httpError => this.errorsHandle(httpError.error.errors));
  }

  private errorsHandle(httpErrors: any): void {
    for (const httpError in httpErrors) {
      this.messages.push(httpErrors[httpError][0]);
    }
    this.messages = this.messages.reverse();
  }
}

import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Developer } from '../../view-models/developer';

@Component({
  selector: 'app-lst-dev',
  templateUrl: './lst-dev.component.html',
  styleUrls: ['./lst-dev.component.css']
})
export class LstDevComponent implements OnInit {
  public developers: Developer[];

  constructor(private httpClient: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private router: Router) { }

  ngOnInit(): void {
    this.httpClient.get(this.baseUrl + 'developer')
      .toPromise()
      .then((result: Developer[]) => this.developers = result)
      .catch(httpError => console.error(httpError));
  }

  add(): void {
    this.router.navigate(['add-dev']);
  }
}

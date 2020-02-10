import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Developer } from '../../models/developer';
import { DeveloperService } from '../../services/developer.service';
import { EntityListService } from '../../services/entity-list.service';
import { Availability } from '../../models/availability';
import { WorkingTime } from '../../models/working-time';

@Component({
  selector: 'lst-dev',
  templateUrl: './lst-dev.component.html'
})
export class LstDevComponent implements OnInit {
  public developers: Developer[];

  private availabilities: Availability[];
  private workingTimes: WorkingTime[];

  constructor(private router: Router,
              private developerService: DeveloperService,
              private entityListService: EntityListService) { }

  public ngOnInit(): void {
    this.developerService.getAll()
      .subscribe(
        result => this.developers = result,
        errorMessage => alert(errorMessage)
    );
    this.entityListService.getAvailabilities()
      .subscribe(
        result => this.availabilities = result,
        errorMessage => alert(errorMessage)
    );
    this.entityListService.getWorkingTimes()
      .subscribe(
        result => this.workingTimes = result,
        errorMessage => alert(errorMessage)
    );
  }

  public delete(dev: Developer): void {
    if (confirm(`Você realmente deseja excluir o Desenvolvedor '${dev.name}'?`)) {
      this.developerService.delete(dev.developerId)
        .subscribe(
          () => {
            this.developers.splice(this.developers.indexOf(dev), 1);
            alert(`Desenvolvedor '${dev.name}' excluído com sucesso!`);
          },
          errorMessage => alert(errorMessage)
        );
    }
  }

  public add(): void {
    this.router.navigate(['frm-dev'],
      {
        state: {
          developer: {} as Developer,
          devAvailabilities: new Array<Availability>(),
          devWorkingTimes: new Array<WorkingTime>(),
          availabilities: this.availabilities,
          workingTimes: this.workingTimes,
        }
      });
  }

  public update(developer: Developer): void {
    this.developerService.get(developer)
      .toPromise()
      .then(developerDto =>
      {
        this.router.navigate(['frm-dev'],
          {
            state: {
              developer,
              devAvailabilities: developerDto.availabilities,
              devWorkingTimes: developerDto.workingTimes,
              availabilities: this.availabilities,
              workingTimes: this.workingTimes,
            }
          })
      })
      .catch(errorMessage => alert(errorMessage));
  }
}

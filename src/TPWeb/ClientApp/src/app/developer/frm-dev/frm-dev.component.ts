import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { Developer } from '../../models/developer';
import { Availability } from '../../models/availability';
import { DeveloperService } from '../../services/developer.service';
import { CheckboxItem, ValidateRequiredCheckBox, GetCheckBoxValues } from '../../shared/checkbox-group/checkbox-group.component';
import { WorkingTime } from '../../models/working-time';

@Component({
  selector: 'frm-dev',
  templateUrl: './frm-dev.component.html'
})
export class FrmDevComponent implements OnInit {
  private readonly developer: Developer;

  public availabilities: Availability[];
  public get availabilityItems(): CheckboxItem[] {
    return this.availabilities.map(a => new CheckboxItem(a, a.description));
  }
  public devAvailabilities: Availability[];

  public workingTimes: WorkingTime[];
  public get workingTimeItems(): CheckboxItem[] {
    return this.workingTimes.map(wt => new CheckboxItem(wt, wt.description));
  }
  public devWorkingTimes: WorkingTime[];

  public form: FormGroup;

  constructor(private router: Router,
              private formBuilder: FormBuilder,
              private developerService: DeveloperService) {
    const navigation = this.router.getCurrentNavigation();

    this.developer = navigation.extras.state.developer;
    this.devAvailabilities = navigation.extras.state.devAvailabilities;
    this.devWorkingTimes = navigation.extras.state.devWorkingTimes;
    this.availabilities = navigation.extras.state.availabilities;
    this.workingTimes = navigation.extras.state.workingTimes;
  }

  public ngOnInit(): void {
    this.form = this.formBuilder.group({
      name: [this.developer.name, Validators.required],
      email: [this.developer.email, [Validators.required, Validators.email]],
      city: [this.developer.city, Validators.required],
      state: [this.developer.state, Validators.required],
      skype: [this.developer.skype, Validators.required],
      whatsapp: [this.developer.whatsapp, Validators.required],
      salary: [this.developer.salary, [Validators.required, Validators.pattern('^[0-9]+(\.[0-9]{1,2})?$')]],
      linkedIn: [this.developer.linkedIn],
      portfolio: [this.developer.portfolio],
      extraKnowledge: [this.developer.extraKnowledge],
      crudLink: [this.developer.crudLink],
      availabilities: new FormArray([], ValidateRequiredCheckBox()),
      workingTimes: new FormArray([], ValidateRequiredCheckBox())
    });
  }

  public onSubmit(): void {
    if (this.form.valid) {

      this.form.value.developerId = this.developer.developerId;
      this.developerService.save({ developer: this.form.value,
        availabilities: GetCheckBoxValues(this.form.get('availabilities')),
        workingTimes: GetCheckBoxValues(this.form.get('workingTimes'))
        })
        .subscribe(() => {
          alert('Operação realizada com sucesso!');
          this.router.navigate(['']);
        },
          errorMessage => alert(errorMessage)
        );

    } else {

      Object.keys(this.form.controls).forEach(controlName => {
        this.form.get(controlName).markAllAsTouched();
      });

    }
  }

  public onReset(): void {
    this.form.reset();
  }

  public invalid(control): boolean {
    return !this.form.get(control).valid
      && this.form.get(control).touched;
  }
}

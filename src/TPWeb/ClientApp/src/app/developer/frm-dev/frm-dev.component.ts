import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl } from '@angular/forms';
import { Availability } from '../../models/availability';
import { DeveloperService } from '../../services/developer.service';
import { WorkingTime } from '../../models/working-time';
import { Knowledge } from '../../models/knowledge';
import { ERateKey, ERate } from '../../models/e-rate';
import { CheckboxItem, ValidateRequiredCheckBox, GetCheckBoxValues } from '../../shared/checkbox-group/checkbox-group.component';

@Component({
  selector: 'frm-dev',
  templateUrl: './frm-dev.component.html',
  styleUrls: ['./frm-dev.component.css']
})
export class FrmDevComponent implements OnInit {
  public readonly developerDto: any;

  public form: FormGroup;

  private readonly availabilities: Availability[];
  public get availabilityItems(): CheckboxItem[] {
    return this.availabilities.map(a => new CheckboxItem(a, a.description));
  }

  private readonly workingTimes: WorkingTime[];
  public get workingTimeItems(): CheckboxItem[] {
    return this.workingTimes.map(wt => new CheckboxItem(wt, wt.description));
  }

  public readonly knowledges: Knowledge[];
  public readonly rateItems: any[] =
    Object.keys(ERate).map
      (r => ({ label: ERate[r], key: ERateKey[r] }));

  public currentTab: number = 1;

  constructor(private router: Router,
              private formBuilder: FormBuilder,
              private developerService: DeveloperService) {
    const navigation = this.router.getCurrentNavigation();
    this.developerDto = navigation.extras.state.developerDto;
    this.availabilities = navigation.extras.state.availabilities;
    this.workingTimes = navigation.extras.state.workingTimes;
    this.knowledges = navigation.extras.state.knowledges;
  }

  public ngOnInit(): void {
    this.form = this.formBuilder.group({
      1: this.formBuilder.group({
        name: [this.developerDto.developer.name, Validators.required],
        email: [this.developerDto.developer.email, [Validators.required, Validators.email]],
        city: [this.developerDto.developer.city, Validators.required],
        state: [this.developerDto.developer.state, Validators.required],
        skype: [this.developerDto.developer.skype, Validators.required],
        whatsapp: [this.developerDto.developer.whatsapp, Validators.required],
        linkedIn: [this.developerDto.developer.linkedIn],
        portfolio: [this.developerDto.developer.portfolio]
      }),
      2: this.formBuilder.group({
        availabilities: this.formBuilder.array([], ValidateRequiredCheckBox()),
        workingTimes: this.formBuilder.array([], ValidateRequiredCheckBox()),
        salary: [this.developerDto.developer.salary, [Validators.required, Validators.pattern('^[0-9]+(\.[0-9]{1,2})?$')]]
      }),
      3: this.formBuilder.group({
        knowledges: this.formBuilder.array([]),
        extraKnowledge: [this.developerDto.developer.extraKnowledge]
      })
    });
    this.loadKnowledges();
  }

  public onSubmit(): void {
    if (this.form.valid) {
      
      this.form.controls[1].value.developerId = this.developerDto.developer.developerId;
      this.form.controls[1].value.salary = this.form.controls[2].value.salary;
      this.form.controls[1].value.extraKnowledge = this.form.controls[3].value.extraKnowledge;
      this.developerService.save({
        developer: this.form.controls[1].value,
        availabilities: GetCheckBoxValues((<FormGroup>this.form.controls[2]).controls.availabilities),
        workingTimes: GetCheckBoxValues((<FormGroup>this.form.controls[2]).controls.workingTimes),
          knowledgeDtos: this.knowledgeDtos
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
    const formGroup = this.form.controls[this.currentTab] as FormGroup;
    formGroup.reset();
  }

  public invalid(control: FormControl): boolean {
    return !control.valid && control.touched;
  }

  public moveTab(index: number): void {
    window.scrollTo(0, 0);
    const formGroup = this.form.controls[this.currentTab] as FormGroup;
    if (index > 0 && formGroup.invalid) {
      Object.keys(formGroup.controls).forEach(controlName => {
        formGroup.controls[controlName].markAllAsTouched();
      });
    }
    else
      this.currentTab += index;
  }

  private get knowledgeDtos(): any[] {
    const knowledgeDtos = [];
    const knowledges = (<FormGroup>this.form.controls[3])
      .controls.knowledges as FormArray;
    let i = 0;
    for (const formGroup of knowledges.controls) {
      const control = (<FormGroup>formGroup)
        .controls['ratesRadio'] as FormControl;
      knowledgeDtos.push
        ({ knowledge: this.knowledges[i++], rate: control.value });
    }
    return knowledgeDtos;
  }

  private loadKnowledges(): void {
    this.knowledges.forEach(knowledge => {
      const knowledges = (<FormGroup>this.form.controls[3])
        .controls.knowledges as FormArray;
      const dto = (<Array<any>>this.developerDto.knowledgeDtos)
        .find(dto => dto.knowledge.knowledgeId == knowledge.knowledgeId);
      const rate = dto ? dto.rate : null;
      knowledges.push(this.formBuilder.group
        ({ ratesRadio: [rate, Validators.required] }));
    });
  }

}

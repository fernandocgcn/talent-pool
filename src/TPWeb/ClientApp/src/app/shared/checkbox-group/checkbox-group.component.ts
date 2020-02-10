import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormArray, AbstractControl, ValidatorFn } from '@angular/forms';
import { ExtFormControl } from '../forms';

@Component({
  selector: 'checkbox-group',
  templateUrl: './checkbox-group.component.html'
})
export class CheckboxGroupComponent implements OnInit {

  @Input() public options: CheckboxItem[];
  @Input() public selectedValues: any[];
  @Input() public controlName: string;
  @Input() public cbFormGroup: FormGroup;

  public get items(): FormArray {
    return this.cbFormGroup.get(this.controlName) as FormArray;
  }

  public ngOnInit(): void {
    if (this.items.length === 0) {
      this.options.forEach(option => {
        const control = new ExtFormControl(
          this.selectedValues &&
            this.inArray(this.selectedValues, option.value),
          option.value
        );
        this.items.push(control);
      });
    }
  }

  private inArray(array: any[], value: any): boolean {
    arrayLoop:
    for (const arrayValue of array) {
      const arrayValueProps = Object.getOwnPropertyNames(arrayValue);
      const valueProps = Object.getOwnPropertyNames(value);

      if (arrayValueProps.length !== valueProps.length) {
        continue;
      }

      for (const arrayValueProp of arrayValueProps) {
        if (arrayValue[arrayValueProp] !== value[arrayValueProp]) {
          continue arrayLoop;
        }
      }

      return true;
    }
    return false;
  }
}

export class CheckboxItem {
  constructor(public value: any,
    public label: string,
    public checked: boolean = false) { }
}

export function GetCheckBoxValues(control: AbstractControl): any[] {
  const formArray = control as FormArray;
  const formControl = formArray.controls as ExtFormControl[];
  return formControl
    .filter(control => control.value)
    .map(control => control.data);
}

export function ValidateRequiredCheckBox(min: number = 1): ValidatorFn {
  return (formArray: FormArray) => {
    const formControl = formArray.controls as ExtFormControl[];
    if (formControl.filter(control => control.value).length < min) {
      return { validRequiredCheckBox: true };
    }
    return null;
  }
}


import { FormControl } from "@angular/forms";

export class ExtFormControl extends FormControl {
  constructor(value: any,
              public data: any,
              validatorOrOpts?: any,
              asyncValidator?: any) {
    super(value, validatorOrOpts, asyncValidator);
  }
}

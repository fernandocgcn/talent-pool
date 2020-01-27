import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FrmDevComponent } from './frm-dev.component';

describe('FrmDevComponent', () => {
  let component: FrmDevComponent;
  let fixture: ComponentFixture<FrmDevComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FrmDevComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FrmDevComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

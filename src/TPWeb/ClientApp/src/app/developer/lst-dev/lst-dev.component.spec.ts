import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LstDevComponent } from './lst-dev.component';

describe('LstDevComponent', () => {
  let component: LstDevComponent;
  let fixture: ComponentFixture<LstDevComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LstDevComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LstDevComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

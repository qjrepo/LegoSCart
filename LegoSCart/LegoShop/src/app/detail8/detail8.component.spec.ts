import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Detail8Component } from './detail8.component';

describe('Detail8Component', () => {
  let component: Detail8Component;
  let fixture: ComponentFixture<Detail8Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Detail8Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Detail8Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Detail7Component } from './detail7.component';

describe('Detail7Component', () => {
  let component: Detail7Component;
  let fixture: ComponentFixture<Detail7Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Detail7Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Detail7Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

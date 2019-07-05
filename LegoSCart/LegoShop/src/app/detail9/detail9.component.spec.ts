import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Detail9Component } from './detail9.component';

describe('Detail9Component', () => {
  let component: Detail9Component;
  let fixture: ComponentFixture<Detail9Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Detail9Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Detail9Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

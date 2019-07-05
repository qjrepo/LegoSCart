import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddpaypageComponent } from './addpaypage.component';

describe('AddpaypageComponent', () => {
  let component: AddpaypageComponent;
  let fixture: ComponentFixture<AddpaypageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddpaypageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddpaypageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

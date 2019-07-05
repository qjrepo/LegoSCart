import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LegoshopComponent } from './legoshop.component';

describe('LegoshopComponent', () => {
  let component: LegoshopComponent;
  let fixture: ComponentFixture<LegoshopComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LegoshopComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LegoshopComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

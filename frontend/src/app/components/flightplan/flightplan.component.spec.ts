import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightplanComponent } from './flightplan.component';

describe('FlightplanComponent', () => {
  let component: FlightplanComponent;
  let fixture: ComponentFixture<FlightplanComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FlightplanComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FlightplanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

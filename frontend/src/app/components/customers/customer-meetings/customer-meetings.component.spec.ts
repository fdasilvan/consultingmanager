import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerMeetingsComponent } from './customer-meetings.component';

describe('CustomerMeetingsComponent', () => {
  let component: CustomerMeetingsComponent;
  let fixture: ComponentFixture<CustomerMeetingsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CustomerMeetingsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomerMeetingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

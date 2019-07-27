import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProcessRegistrationComponent } from './process-registration.component';

describe('ProcessRegistrationComponent', () => {
  let component: ProcessRegistrationComponent;
  let fixture: ComponentFixture<ProcessRegistrationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProcessRegistrationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProcessRegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

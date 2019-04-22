import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VerticalTimelineComponent } from './vertical-timeline.component';

describe('VerticalTimelineComponent', () => {
  let component: VerticalTimelineComponent;
  let fixture: ComponentFixture<VerticalTimelineComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VerticalTimelineComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VerticalTimelineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomersListComponent } from './customers.component';

describe('CustomersComponent', () => {
    let component: CustomersListComponent;
    let fixture: ComponentFixture<CustomersListComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [CustomersListComponent]
        })
            .compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(CustomersListComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});

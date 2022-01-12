import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagestudentdetailsComponent } from './managestudentdetails.component';

describe('ManagestudentdetailsComponent', () => {
  let component: ManagestudentdetailsComponent;
  let fixture: ComponentFixture<ManagestudentdetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManagestudentdetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManagestudentdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

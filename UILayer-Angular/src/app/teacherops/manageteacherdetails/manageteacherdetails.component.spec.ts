import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageteacherdetailsComponent } from './manageteacherdetails.component';

describe('ManageteacherdetailsComponent', () => {
  let component: ManageteacherdetailsComponent;
  let fixture: ComponentFixture<ManageteacherdetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManageteacherdetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageteacherdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

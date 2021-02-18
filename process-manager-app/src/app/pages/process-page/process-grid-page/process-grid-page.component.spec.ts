import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProcessGridPageComponent } from './process-grid-page.component';

describe('ProcessGridPageComponent', () => {
  let component: ProcessGridPageComponent;
  let fixture: ComponentFixture<ProcessGridPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProcessGridPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProcessGridPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

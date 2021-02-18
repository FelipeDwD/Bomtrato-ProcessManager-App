import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProcessFormPageComponent } from './process-form-page.component';

describe('ProcessFormPageComponent', () => {
  let component: ProcessFormPageComponent;
  let fixture: ComponentFixture<ProcessFormPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProcessFormPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProcessFormPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProcessMenuPageComponent } from './process-menu-page.component';

describe('ProcessMenuPageComponent', () => {
  let component: ProcessMenuPageComponent;
  let fixture: ComponentFixture<ProcessMenuPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProcessMenuPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProcessMenuPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

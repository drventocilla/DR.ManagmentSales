import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SistemaHeaderComponent } from './sistema-header.component';

describe('SistemaHeaderComponent', () => {
  let component: SistemaHeaderComponent;
  let fixture: ComponentFixture<SistemaHeaderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SistemaHeaderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SistemaHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

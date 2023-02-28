import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaAsesorComponent } from './lista-asesor.component';

describe('ListaAsesorComponent', () => {
  let component: ListaAsesorComponent;
  let fixture: ComponentFixture<ListaAsesorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListaAsesorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaAsesorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentType } from '@angular/cdk/portal';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-sistema-header',
  templateUrl: './sistema-header.component.html',
  styleUrls: ['./sistema-header.component.css']
})
export class SistemaHeaderComponent implements OnInit {

  @Input() title = 'Aqui va el título de la cabecera';
  @Input() icon: any;
  @Input() dialogMode: boolean = true;
  @Input() component: ComponentType<any>;
  @Output() closeDialog: EventEmitter<boolean> = new EventEmitter<boolean>();


  constructor() {
  }
  ngOnInit() {
  }

  public closeWindow() {
    this.closeDialog.emit(true);
  }

}

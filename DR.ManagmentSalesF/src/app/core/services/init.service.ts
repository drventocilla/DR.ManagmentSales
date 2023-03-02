import { Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { CryptoService } from './crypto.service';
import { LocalStorageService } from './local-storage.service';

import { SubSink } from 'subsink';
import { RepositoryService } from './repository.service';

@Injectable({
  providedIn: 'root'
})
export class InitService {

  subs: SubSink = new SubSink;


  constructor(
    private repository: RepositoryService,
    
    
  ) {
    
    
  }

  private construirRuta(ruta: string): string {


    return ruta!= ""? `api/Init/${ruta}` : `api/Init`;
  }

  public initDB() {
    
    return this.repository.getData(this.construirRuta(''));


  }
}

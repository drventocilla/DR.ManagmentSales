import { HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { RepositoryService } from "src/app/core/services/repository.service";
import { Asesor } from "../models/asesor.model";


@Injectable()
  export class AsesorService {
  
    constructor(private repository: RepositoryService) {
          
    }
  
    private construirRuta(ruta: string): string {
        return `api/asesor/${ruta}`;
    }
  
    public getAll() {
        
        return this.repository.getData(this.construirRuta('getAll'));
    }
  
    public find(id :string) {
        
        let httpParams = new HttpParams().append("id" , id);
        return this.repository.getData(this.construirRuta('find'),httpParams);
    }
  
    public delete(id :string) {
        
        let httpParams = new HttpParams().append("id" , id);
        return this.repository.delete(this.construirRuta('delete'), httpParams);
    }

    public save(asesor :Asesor) {
        
        return this.repository.create(this.construirRuta('save'), asesor);
    }
   
  }
  
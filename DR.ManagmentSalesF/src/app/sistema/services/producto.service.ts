import { HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { RepositoryService } from "src/app/core/services/repository.service";
import { Producto } from "../models/producto.model";

@Injectable()
  export class ProductoService {
  
    constructor(private repository: RepositoryService) {
          
    }
  
    private construirRuta(ruta: string): string {
        return `api/producto/${ruta}`;
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

    public save(producto :Producto) {
        console.log('producto', producto);
        return this.repository.create(this.construirRuta('save'), producto);
    }
   
  }
  
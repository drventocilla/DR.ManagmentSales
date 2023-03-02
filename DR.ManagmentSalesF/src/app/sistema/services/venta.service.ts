import { HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { RepositoryService } from "src/app/core/services/repository.service";

@Injectable()
  export class VentaService {
  
    constructor(private repository: RepositoryService) {
          
    }
  
    private construirRuta(ruta: string): string {
        return `api/venta/${ruta}`;
    }
  
    
    public report(fechaInicial : string , fechaFinal : string) {
        
            console.log('fechaInicial',fechaInicial);
            console.log('fechaFinal' ,fechaFinal);
            
        let httpParams = new HttpParams().append("fechaInicial",fechaInicial).append("fechaFinal",fechaFinal);

        return this.repository.getData(this.construirRuta('report'), httpParams);
    }
   
  }
  
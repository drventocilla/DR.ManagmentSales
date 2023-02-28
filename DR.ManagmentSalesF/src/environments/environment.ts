import { Environment } from "./enviroment-model";


export const environment : Environment = {
  production: true,
  urlAddress: 'http://localhost:5002',
};

//#region url WS Busqueda Empresa
export const environmentBP :Environment =  {
  production: true,
  urlAddress: 'https://dniruc.apisperu.com',
};


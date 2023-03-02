# DR.ManagmentSales

Esta aplicación fue implementada en los frameworks .Net Core 6 API en BackEnd y Angular V12 para FrontEnd que se detalla a continuación.

BackEnd (.Net Core 6 Web API )

•	La arquitectura del proyecto está basada en Domain Driven Desing.
  https://medium.com/modern-software-architecture/modern-software-architecture-1-domain-driven-design-f06fad8695f9
•	Se está usando patrones de diseño Builder , Repository ,  diseño UnitOfWork.
•	Se ha implementado Swagger para la documentación de los API.

FrontEnd (Angular V12 )

•	Se ha aplicado concepto de lazy Loading y modularización.
  https://angular.io/guide/lazy-loading-ngmodules
  
•	Se ha utilizado los patrones observador  e inyección de dependecias propias del 
  Framework.

•	Se instaló la librería DevExpress para la ayuda de en la generación de tablas y  
  reportes gráficos.


Funcionalidades requeridas:
1.  Creación de API
      ![image](https://user-images.githubusercontent.com/66335401/222520771-61c7e46a-b938-4e42-a97c-532bbdb5bbf8.png)

2. In Memory DataBase
   •  Creado en el archivo ApplicationExtension.cs

      ![image](https://user-images.githubusercontent.com/66335401/222520920-68535502-89dd-4603-92e7-5aea246400ed.png)

3. Utilizar Github para apreciar el desarrollo

  •  En el presente repositorio se observa el proceso de desarrollo

4. Implementar nivel de seguridad API (Token JWT)

  •  Configuración del servicio:

     Se envidencia en el archivo  ServicesExtensions.cs
     ![image](https://user-images.githubusercontent.com/66335401/222521237-83a158a7-f9a7-4d89-a450-b64a8b3d3122.png)

  •  Creación del TOKEN Claims , Expiracion y Firma
  
     Se envidencia en el archivo  TokenService.cs
     ![image](https://user-images.githubusercontent.com/66335401/222521574-e23e1274-48a0-4f1e-a433-6b414e3773db.png)

5. Implementar un FrontEnd con angular
   •  El FrontEnd esta corriendo en el puerto 4200 y consume la API que esta corriendo en   
      5002, se envidencia en el archivo environment.ts
    
      ![image](https://user-images.githubusercontent.com/66335401/222522529-3ada8e7f-c5b9-47e2-9e9d-8039839d65a9.png)

   •  Para iniciar sesión se usa el login admin y contraseña por defecto 123456789

6. Desplegar el API en Contenedores Docker

  •  En proceso de configuración.



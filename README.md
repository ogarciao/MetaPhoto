# MetaPhoto
MetaPhoto solution for Relish

# Repo Content
This repo contains to main folders:
- MetaPhoto: is a .Net Core project for the REST API which has the enrichment endpoint.
- meta-photo: is an Angular application which consumes the .Net Core API.

# Building the applications
## MetaPhoto API
### Visual Studio
- Open the solution and execute the MetaPhoto project:
<p align="center">
  <img src="https://user-images.githubusercontent.com/98901974/219536653-ea3a528c-da8a-4672-960d-5c3973067518.png" alt="VS Run"/>
</p>
- After the API is built, a browser window will be open:
<p align="center">
  <img src="https://user-images.githubusercontent.com/98901974/219538376-98df42c8-953b-478c-9dbd-1ecb9165c034.png" alt="API browser window"/>
</p>

- The HTTPS port needs to be configured on the Angular app environment configuration for the application to find the service (This is explained on the Angular app section)

### Visual Studio Code
Official .Net Core documentation: https://code.visualstudio.com/docs/languages/dotnet
- Open the "MetaPhoto/MetaPhoto" folder which contains the API files.
- In the terminal type
```
dotnet run
```
- The terminal will start building the API.
- When the terminal finishes building the solution, it'll show the HTTP and HTTPS ports where it's listening.
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7062
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5095
```
> ℹ️ The HTTPS port needs to be configured on the Angular app environment configuration for the application to find the service (This is explained on the Angular app section)

## meta-photo Angular app
### Visual Studio Code
> ℹ️ Note: Only the **Photos** section is part of this MVP.
- Open the meta-photo folder, which contains the Angular app files.
- Open the file
```
src\app\environment\environment.ts
```
- Set the HTTPS port designed to the API to the apiRoot property
``` ts
export const environment = {
    production: false,
    apiRoot: 'https://localhost:7062/api'
}
```
- In the terminal type
```
npm install
```
- The node_modules for the application will be installed
- To build the application, type in the terminal
``` powershell
ng serve --open
```
- The applicatio will be built and opened in a browser window
<p align="center">
  <img src="https://user-images.githubusercontent.com/98901974/219539771-1b350c7a-e32e-418d-90d1-fb948a96b17a.png" alt="Home"/>
</p>
<p align="center">
  <img src="https://user-images.githubusercontent.com/98901974/219539954-0ebcb6b2-b442-4836-83ce-7bbd24723237.png" alt="Photos"/>
</p>
<p align="center">
  <img src="https://user-images.githubusercontent.com/98901974/219539980-1b420ab0-8565-4038-b7c0-9f13f8f2160c.png" alt="Photo dialog"/>
</p>


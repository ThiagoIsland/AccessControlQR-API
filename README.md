# AccessControlQRCode API

## Description

AccessControlQRCode-API it's RESTful API responsable for all the back-end features, doing the system management using QR Codes. This API allows the Register users and visitors, generate the code for QR Code, and to validate visitors access.

The Front-End for this applcation resides in this repository: [Front-End](https://github.com/ThiagoIsland/AccessControlQR-Web)
## Technologies Used

Language: C#

Framework (Back-End): .NET 8

Database: Microsoft SQL Server

Autentication: JWT


Installation

1. Clone the repository:
```bash
git clone https://github.com/seu-usuario/AccessControlQRCode.git
cd AccessControlQRCode
```

2. Database configurations

Create a SQL Server Database and update the ConnectionString in appsettings.json

```bash
"ConnectionStrings": {
  "DefaultConnection": "Server=SEU_SERVIDOR;Database=AccessControl;User Id=SEU_USUARIO;Password=SUA_SENHA;"
}
```
3. Migrations
   
```bash
dotnet ef database update
```
4. Run the API
   
```bash
dotnet run
```

## Endpoints

**-> Auth**

Login

POST /api/Auth/login

Request Body:

```bash
{
  "username": "admin",
  "password": "123456"
}
```
Response:
```bash
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```
**-> Users**

Register users (Admin/Operators)

POST /api/users/register

Request Body:
```bash
{
  "username": "string",
  "email": "user@example.com",
  "password": "string",
  "role": "operator"
}
```

Response:
```bash
{
  "id": 1,
  "username": "string",
  "role": "operator"
}
```
**-> Visitors**

Registrar Visitors

POST /api/visitors/register

Request Body:
```bash
{
  "name": "string",
  "email": "user@example.com",
  "phone": "string",
  "status": "string"
}
```
Response:
```bash
{
 Message: "Visitor sucessfully registered",
VisitorId: 1
}
```

POST /api/Visitor/generate

GET /api/Visitor/validateAccess

GET /api/Visitor/get

## JWT Auth

Para acessar endpoints protegidos, envie o token JWT no cabeçalho da requisição:

Exemplo:

curl -H "Authorization: Bearer SEU_TOKEN_AQUI" http://localhost:5000/api/visitors


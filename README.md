Cadastro de Usuários com Autenticação JWT - .NET 8 API
Este projeto é uma API RESTful desenvolvida em .NET 8, utilizando Dapper para acesso a dados, implementando um CRUD completo de usuários com autenticação via JSON Web Token (JWT).

🎯 Funcionalidades
✅ Cadastro de novos usuários (com senha criptografada usando BCrypt)
✅ Login de usuário com geração de token JWT
✅ Listagem de usuários cadastrados
✅ Consulta de usuário por ID
✅ Atualização de dados do usuário
✅ Exclusão de usuários
✅ Código organizado em Controllers, Services, Repositories e Models (FormModel, ResponseModel)
✅ Conexão ao banco de dados via ConnectionString direta
✅ Projeto ideal para estudo de APIs REST em .NET 8

💻 Tecnologias Utilizadas
.NET 8

Dapper

SQL Server

BCrypt.Net

JWT Bearer Authentication

🗂️ Estrutura do Projeto
diff
Copiar
Editar
- Controllers
- Models (User, FormModels, ResponseModels)
- Services
- Repositories
- Program.cs
- appsettings.json

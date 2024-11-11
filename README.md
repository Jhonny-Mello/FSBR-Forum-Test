# Projeto FSBR: React + ASP.NET Core 8

## Tecnologias Utilizadas

### Backend
- **ASP.NET Core 8**: Framework para a constru��o da API RESTful.
- **Entity Framework Core**: ORM para o acesso ao banco de dados.
- **ASP.NET Identity**: Gerenciamento de usu�rios e autentica��o.
- **LocalDB**: Banco de dados local para desenvolvimento (SQL Server).
  
### Frontend
- **React**: Biblioteca para constru��o da interface de usu�rio.
- **TypeScript**: Superset do JavaScript que adiciona tipagem est�tica.
- **Ant Design (antd)**: Biblioteca de componentes UI para React.
- **Redux Toolkit (RTK Query)**: Gerenciamento de estado e chamadas API.
- **react-router-dom**: Roteamento no frontend.

---

## Pr�-Requisitos

### Backend (ASP.NET Core 8)

Antes de rodar o backend, voc� precisar� ter os seguintes pr�-requisitos instalados:

- **.NET SDK 8.0** ou superior: [Instalar .NET 8](https://dotnet.microsoft.com/download/dotnet/8.0).
- **SQL Server LocalDB**: Usado para armazenamento de dados local durante o desenvolvimento.

### Frontend (React)

Para rodar o frontend, voc� precisar� ter as seguintes ferramentas instaladas:

- **Node.js** (vers�o 14 ou superior): [Instalar Node.js](https://nodejs.org/)
- **Yarn** ou **npm**: Para gerenciamento de pacotes.

---

## Configura��o do Backend (ASP.NET Core 8)

### Passo 2: Configurar o Banco de Dados

1. **Criar o banco de dados LocalDB**:
   O projeto usa o LocalDB para o banco de dados durante o desenvolvimento. Certifique-se de que o **SQL Server LocalDB** esteja instalado.

2. **Aplicar Migrations**:
   Execute o seguinte comando para aplicar as migrations no banco de dados:

   ```bash
   dotnet ef database update
   ```

   Isso criar� o banco de dados local e as tabelas necess�rias.

### Passo 3: Executar o Backend

Execute o backend usando o comando:

```bash
dotnet run
```

A API estar� dispon�vel por padr�o em `http://localhost:7281`.

---

## Configura��o do Frontend (React)

### Passo 2: Instalar as Depend�ncias

Instale as depend�ncias do projeto utilizando o **npm** ou **yarn**:

Com **npm**:

```bash
npm install
```

Com **yarn**:

```bash
yarn install
```

### Passo 3: Executar o Frontend

Para rodar a aplica��o React no ambiente de desenvolvimento, execute:

Com **npm**:

```bash
npm start
```

Com **yarn**:

```bash
yarn start
```

Isso abrir� a aplica��o no seu navegador na URL `http://localhost:3000`.

---
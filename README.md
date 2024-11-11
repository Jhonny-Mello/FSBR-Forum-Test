# Projeto FSBR: React + ASP.NET Core 8

## Tecnologias Utilizadas

### Backend
- **ASP.NET Core 8**: Framework para a construção da API RESTful.
- **Entity Framework Core**: ORM para o acesso ao banco de dados.
- **ASP.NET Identity**: Gerenciamento de usuários e autenticação.
- **LocalDB**: Banco de dados local para desenvolvimento (SQL Server).
  
### Frontend
- **React**: Biblioteca para construção da interface de usuário.
- **TypeScript**: Superset do JavaScript que adiciona tipagem estática.
- **Ant Design (antd)**: Biblioteca de componentes UI para React.
- **Redux Toolkit (RTK Query)**: Gerenciamento de estado e chamadas API.
- **react-router-dom**: Roteamento no frontend.

---

## Pré-Requisitos

### Backend (ASP.NET Core 8)

Antes de rodar o backend, você precisará ter os seguintes pré-requisitos instalados:

- **.NET SDK 8.0** ou superior: [Instalar .NET 8](https://dotnet.microsoft.com/download/dotnet/8.0).
- **SQL Server LocalDB**: Usado para armazenamento de dados local durante o desenvolvimento.

### Frontend (React)

Para rodar o frontend, você precisará ter as seguintes ferramentas instaladas:

- **Node.js** (versão 14 ou superior): [Instalar Node.js](https://nodejs.org/)
- **Yarn** ou **npm**: Para gerenciamento de pacotes.

---

## Configuração do Backend (ASP.NET Core 8)

### Passo 2: Configurar o Banco de Dados

1. **Criar o banco de dados LocalDB**:
   O projeto usa o LocalDB para o banco de dados durante o desenvolvimento. Certifique-se de que o **SQL Server LocalDB** esteja instalado.

2. **Aplicar Migrations**:
   Execute o seguinte comando para aplicar as migrations no banco de dados:

   ```bash
   dotnet ef database update
   ```

   Isso criará o banco de dados local e as tabelas necessárias.

### Passo 3: Executar o Backend

Execute o backend usando o comando:

```bash
dotnet run
```

A API estará disponível por padrão em `http://localhost:7281`.

---

## Configuração do Frontend (React)

### Passo 2: Instalar as Dependências

Instale as dependências do projeto utilizando o **npm** ou **yarn**:

Com **npm**:

```bash
npm install
```

Com **yarn**:

```bash
yarn install
```

### Passo 3: Executar o Frontend

Para rodar a aplicação React no ambiente de desenvolvimento, execute:

Com **npm**:

```bash
npm start
```

Com **yarn**:

```bash
yarn start
```

Isso abrirá a aplicação no seu navegador na URL `http://localhost:3000`.

---
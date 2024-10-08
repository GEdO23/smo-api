# Projeto SMO API

Este projeto é uma API para gerenciar produtos utilizando ASP.NET Core e MongoDB.

## Tecnologias Utilizadas

- **C#**
- **ASP.NET Core**
- **MongoDB**
- **Moq** (para testes unitários)
- **Xunit** (para testes unitários)

## Estrutura do Projeto

- `Domain`: Contém as interfaces e modelos de domínio.
- `Data`: Contém a implementação dos repositórios.
- `Controllers`: Contém os controladores da API.
- `Tests`: Contém os testes unitários.

## Configuração

### Pré-requisitos

- .NET 6.0 SDK ou superior
- MongoDB

### Instalação

1. Clone o repositório:

    ```sh
    git clone https://github.com/seu-usuario/smo-api.git
    ```

2. Navegue até o diretório do projeto:

    ```sh
    cd smo-api
    ```

3. Restaure as dependências do projeto:

    ```sh
    dotnet restore
    ```

4. Execute o projeto:

    ```sh
    dotnet run
    ```

## Endpoints

### Produtos

- **GET /api/produto**: Retorna a lista de produtos.
- **GET /api/produto/{id}**: Retorna um produto específico pelo ID.
- **POST /api/produto**: Cria um novo produto.
- **PUT /api/produto/{id}**: Atualiza um produto existente pelo ID.
- **DELETE /api/produto/{id}**: Deleta um produto pelo ID.

## Testes

Para executar os testes, utilize o comando:

```sh
dotnet test
```

## Contribuição

1. Faça um fork do projeto.
2. Crie uma branch para sua feature (`git checkout -b feature/nova-feature`).
3. Commit suas mudanças (`git commit -am 'Adiciona nova feature'`).
4. Faça o push para a branch (`git push origin feature/nova-feature`).
5. Crie um novo Pull Request.

## Licença

Este projeto está licenciado sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.

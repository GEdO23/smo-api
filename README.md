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

- [Docker](https://www.docker.com/)

### Como executar o projeto com Docker

Siga as instruções abaixo para executar o container:

#### 1. Clone o repositório:

```sh
git clone https://github.com/GEdO23/smo-api.git
cd smo-api
```

#### 2. Construir a imagem

```sh
docker build -t smo-api .
```
Este comando irá:
- Construir a imagem a partir do Dockerfile (`-t smo-api`)
- Utilizar o contexto do diretório atual (onde está o Dockerfile)
- Nomear a imagem como `smo-api`

#### 3. Execute o comando abaixo para criar o container:

```sh
docker run -p 8080:8080 smo-api
```
Este comando irá:
- Criar um container a partir da imagem `smo-api`
- Mapear a porta 8080 do container para a porta 8080 do host
- Iniciar o container

####  4. Acessar a API 
Acesse a URL http://localhost:8080/api/produto no seu navegador.

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

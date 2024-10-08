using Domain.Interfaces.Data;
using Domain.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using smo_api.Controllers;
using Xunit;

namespace Tests;

public class ProdutoControllerTests
{
    private readonly ProdutoController _controller;
    private readonly Mock<IProdutoRepository> _mockRepo;

    public ProdutoControllerTests()
    {
        _mockRepo = new Mock<IProdutoRepository>();
        _controller = new ProdutoController(_mockRepo.Object);
    }

    [Fact]
    public async Task Get_ReturnsOkResult_WithListOfProdutos()
    {
        // Arrange
        var produtos = new List<ProdutoModel> {
            new() { Id = "teste_1", Nome = "Teste", Preco = 10.0, Estoque = 1 }
        };
        _mockRepo.Setup(repo => repo.GetProdutosAsync()).ReturnsAsync(produtos);

        // Act
        var result = await _controller.Get();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<ProdutoModel>>(okResult.Value);
        Assert.Single(returnValue);
    }

    [Fact]
    public async Task GetById_ReturnsOkResult_WhenProdutoExists()
    {
        // Arrange
        const string id = "1";
        var produto = new ProdutoModel { Id = id, Nome = "Produto", Preco = 10.0, Estoque = 1 };
        _mockRepo.Setup(repo => repo.GetProdutoByIdAsync(id)).ReturnsAsync(produto);

        // Act
        var result = await _controller.Get(id);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<ProdutoModel>(okResult.Value);
        Assert.Equal(produto.Id, returnValue.Id);
    }

    [Fact]
    public async Task GetById_ReturnsNotFoundResult_WhenProdutoDoesNotExist()
    {
        // Arrange
        const string id = "1";
        _mockRepo.Setup(repo => repo.GetProdutoByIdAsync(id)).ReturnsAsync((ProdutoModel)null!);

        // Act
        var result = await _controller.Get(id);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Post_ReturnsCreatedAtAction_WhenProdutoIsCreated()
    {
        // Arrange
        var produto = new ProdutoModel { Id = "1", Nome = "Produto", Preco = 10.0, Estoque = 1 };

        // Act
        var result = await _controller.Post(produto);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnValue = Assert.IsType<ProdutoModel>(createdAtActionResult.Value);
        Assert.Equal(produto.Id, returnValue.Id);
    }

    [Fact]
    public async Task Put_ReturnsNoContentResult_WhenProdutoIsUpdated()
    {
        // Arrange
        const string id = "1";
        var produto = new ProdutoModel { Id = id, Nome = "Produto Antigo ", Preco = 10.0, Estoque = 1 };
        _mockRepo.Setup(repo => repo.GetProdutoByIdAsync(id)).ReturnsAsync(produto);

        // Act
        var produtoAtualizado = new ProdutoModel { Id = id, Nome = "Produto Atualizado", Preco = 20.0, Estoque = 2 };
        var result = await _controller.Put(id, produtoAtualizado);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task Put_ReturnsNotFoundResult_WhenProdutoDoesNotExist()
    {
        // Arrange
        const string id = "1";
        var produto = new ProdutoModel { Id = id, Nome = "Produto", Preco = 10.0, Estoque = 1 };
        _mockRepo.Setup(repo => repo.GetProdutoByIdAsync(id)).ReturnsAsync((ProdutoModel)null!);

        // Act
        var result = await _controller.Put(id, produto);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Delete_ReturnsNoContentResult_WhenProdutoIsDeleted()
    {
        // Arrange
        const string id = "1";
        var produto = new ProdutoModel { Id = id, Nome = "Produto", Preco = 10.0, Estoque = 1 };
        _mockRepo.Setup(repo => repo.GetProdutoByIdAsync(id)).ReturnsAsync(produto);
        _mockRepo.Setup(repo => repo.DeleteProdutoAsync(id)).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.Delete(id);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task Delete_ReturnsNotFoundResult_WhenProdutoDoesNotExist()
    {
        // Arrange
        const string id = "1";
        _mockRepo.Setup(repo => repo.GetProdutoByIdAsync(id)).ReturnsAsync((ProdutoModel)null!);

        // Act
        var result = await _controller.Delete(id);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
}
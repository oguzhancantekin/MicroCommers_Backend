using MediatR;
using MicroCommerce.Application.DTOs;
using MicroCommerce.Application.Features.Products.Commands.CreateProduct;
using MicroCommerce.Application.Features.Products.Queries.GetAllProducts;
using MicroCommerce.WebAPI.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace MicroCommerce.WebAPI.Controllers;

/// <summary>
/// RESTful API controller for Product operations.
/// Uses MediatR to dispatch commands and queries following CQRS pattern.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Retrieves all products.
    /// </summary>
    /// <returns>List of products</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<ProductDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetAll()
    {
        var products = await _mediator.Send(new GetAllProductsQuery());
        return Ok(products);
    }

    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="command">Product creation data</param>
    /// <returns>The ID of the created product</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<Guid> Create([FromBody] CreateProductCommand command)
    {
        var productId = await _mediator.Send(command);
        return productId;
    }
}


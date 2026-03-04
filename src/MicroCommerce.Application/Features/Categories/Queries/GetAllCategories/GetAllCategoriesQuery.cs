using MediatR;
using MicroCommerce.Application.DTOs;

namespace MicroCommerce.Application.Features.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQuery : IRequest<IReadOnlyList<CategoryDto>>
{
}

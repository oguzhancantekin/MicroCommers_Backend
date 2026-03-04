using MicroCommerce.Application.DTOs;

namespace MicroCommerce.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<AuthResponseDto> RegisterAsync(RegisterDto request);
    Task<AuthResponseDto> LoginAsync(LoginDto request);
}

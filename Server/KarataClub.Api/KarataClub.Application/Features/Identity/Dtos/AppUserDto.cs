using Microsoft.Extensions.Diagnostics.Metrics.Configuration;
using System.Security.Claims;

namespace KarataClub.Application.Features.Identity.Dtos;

public sealed record AppUserDto(string Id,string Name,string Email,string Phone,
    IList<string>Role,IList<Claim>Claims);

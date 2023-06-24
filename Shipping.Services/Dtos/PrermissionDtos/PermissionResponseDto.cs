﻿using System.Security.Claims;

namespace Shipping.Services.Dtos;

public  class PermissionResponseDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public ICollection<Claim> Claims { get; set; } = new HashSet<Claim>();
}
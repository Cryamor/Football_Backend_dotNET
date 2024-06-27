using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Football_Backend_dotNET.Utils;

public class JwtUtils
{
    private readonly string _signKey;
    private readonly long _expire;
    private readonly ILogger<JwtUtils> _logger;

    public JwtUtils(IConfiguration configuration, ILogger<JwtUtils> logger)
    {
        _signKey = configuration["Jwt:Token:SignKey"];
        _expire = long.Parse(configuration["Jwt:Token:Expire"]);
        _logger = logger;
    }

    // Generate JWT token and return
    public string CreateJwt(Dictionary<string, object> claims)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_signKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(),
            Expires = DateTime.UtcNow.AddMilliseconds(_expire),
            SigningCredentials = credentials
        };

        foreach (var claim in claims)
        {
            tokenDescriptor.Subject.AddClaim(new Claim(claim.Key, claim.Value.ToString()));
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}


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

    public long? GetUserIdFromToken(HttpRequest request)
    {
        // 从请求头中获取传递的JWT令牌
        string authorizationHeader = request.Headers["Authorization"].FirstOrDefault();

        // 验证 Authorization 请求头是否包含 JWT 令牌
        if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer"))
        {
            Console.WriteLine("未提供有效的JWT");
            return null;
        }

        string jwtToken = authorizationHeader.Substring("Bearer ".Length).Trim();

        // 验证并解析JWT令牌
        var handler = new JwtSecurityTokenHandler();
        var tokenS = handler.ReadJwtToken(jwtToken);

        // 获取JWT令牌中的claims信息
        var idClaim = tokenS.Claims.FirstOrDefault(claim => claim.Type == "id");

        if (idClaim != null && long.TryParse(idClaim.Value, out long userId))
        {
            return userId;
        }

        return null;
    }
}


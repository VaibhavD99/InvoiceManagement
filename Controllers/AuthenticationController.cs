﻿// AuthController Enhancements
using Microsoft.AspNetCore.Mvc;
using InvoiceManagement.Services;
using InvoiceManagement.Models;

namespace InvoiceManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenService _jwtTokenService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(JwtTokenService jwtTokenService, ILogger<AuthController> logger)
        {
            _jwtTokenService = jwtTokenService;
            _logger = logger;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid login attempt with invalid model state.");
                return BadRequest(ModelState);
            }

            // Replace with actual user validation logic (e.g., check database)
            if (loginRequest.Username == "admin" && loginRequest.Password == "password")
            {
                var token = _jwtTokenService.GenerateToken("admin", "Admin");
                _logger.LogInformation("User {Username} logged in successfully.", loginRequest.Username);
                return Ok(new { Token = token });
            }

            _logger.LogWarning("Failed login attempt for username: {Username}", loginRequest.Username);
            return Unauthorized("Invalid username or password");
        }
    }
}
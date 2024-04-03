using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
	private readonly DataContext _context;

	public UsersController(DataContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<ActionResult<AppUser>> Get()
	{
		return Ok(await _context.Users.ToArrayAsync());
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(int id)
	{
		return Ok(await _context.Users.FirstOrDefaultAsync(e => e.Id == id));
	}
}


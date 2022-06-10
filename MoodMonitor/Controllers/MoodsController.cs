using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoodMonitor.Data;
using MoodMonitor.Models;
using System.Security.Claims;

namespace MoodMonitor.Controllers; 

public class MoodsController : Controller {
	private readonly ILogger<MoodsController> _logger;
	private readonly ApplicationDbContext _context;

	public MoodsController(ILogger<MoodsController> logger, ApplicationDbContext context) {
		_logger = logger;
		_context = context;
	}
	
	[Authorize]
	public IActionResult Add() {
		ViewData["User"] = User.FindFirstValue(ClaimTypes.NameIdentifier);
		return View();
	}
	
	[Authorize]
	public async Task<IActionResult> Overview() {
		var allData = await _context.Moods.Where(m => m.UserID == HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)).ToListAsync();
		ViewData["Dates"] = allData.Select(m => m.CreatedAt).ToArray();
		ViewData["Happiness"] = allData.Select(m => m.Happiness).ToArray();
		ViewData["Sadness"] = allData.Select(m => m.Sadness).ToArray();
		ViewData["Fear"] = allData.Select(m => m.Fear).ToArray();
		ViewData["Anger"] = allData.Select(m => m.Anger).ToArray();
		ViewData["Stress"] = allData.Select(m => m.Stress).ToArray();
		ViewData["Emptiness"] = allData.Select(m => m.Emptiness).ToArray();
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Post(MoodModel model, CancellationToken token) {
		if (!ModelState.IsValid || _context.Moods == null || model == null) {
			return View("Add");
		}

		model.ID = _context.Moods.Count(m => m.UserID == model.UserID) + 1;
		_context.Moods.Add(model);
		await _context.SaveChangesAsync();

		return Redirect("/Home");
	}
}
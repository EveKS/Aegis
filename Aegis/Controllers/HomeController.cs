using Aegis.Datas;
using Aegis.Models;
using Aegis.Services.Html;
using Aegis.Services.Telegram;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aegis.Controllers
{
  [Route("api/[controller]")]
  public class HomeController : Controller
  {
    private const string NO_CATEGORY = "No category";

    private ApplicationContext _context;

    private readonly ITelegramService _telegramService;

    private readonly UserManager<User> _userManager;

    public HomeController(UserManager<User> userManager,
      ITelegramService telegramService,
      ApplicationContext context)
    {
      this._userManager = userManager;

      this._context = context;

      this._telegramService = telegramService;
    }

    // POST api/home/get-categorys
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPost("get-categorys")]
    public async Task<IActionResult> GetCategorys()
    {
      try
      {
        var userName = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

        if (string.IsNullOrWhiteSpace(userName))
        {
          return Unauthorized();
        }

        if (await _userManager.FindByNameAsync(userName) == null)
        {
          return Unauthorized();
        }

        var categorys = await this._context.Companys
          .Select(company => company.CategoryName)
          .Distinct()
          .ToListAsync();

        return Ok(categorys);
      }
      catch (Exception ex)
      {
        await this._telegramService.SendMessageExceptionAsync(ex);

        return BadRequest();
      }
    }

    // POST api/home/get-subcategorys
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPost("get-subcategorys")]
    public async Task<IActionResult> GetSubCategorys([FromBody]string Category)
    {
      try
      {
        if (string.IsNullOrWhiteSpace(Category)) return BadRequest();

        var userName = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

        if (string.IsNullOrWhiteSpace(userName))
        {
          return Unauthorized();
        }

        if (await _userManager.FindByNameAsync(userName) == null)
        {
          return Unauthorized();
        }

        var subCategorys = (await this._context.Companys
          .Where(company => company.CategoryName == Category)
          .Select(company => company.Category)
          .Distinct()
          .ToListAsync())
          .Select(sCategorys => string.IsNullOrWhiteSpace(sCategorys) ? NO_CATEGORY : sCategorys);

        return Ok(subCategorys);
      }
      catch (Exception ex)
      {
        await this._telegramService.SendMessageExceptionAsync(ex);

        return BadRequest();
      }
    }

    // POST api/home/get-emails
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPost("get-emails")]
    public async Task<IActionResult> GetEmails([FromBody]GetEmails getEmails)
    {
      try
      {
        if (string.IsNullOrWhiteSpace(getEmails.Category) || string.IsNullOrWhiteSpace(getEmails.SubCategory)) return BadRequest();

        if (getEmails.SubCategory == NO_CATEGORY) getEmails.SubCategory = string.Empty;

        var userName = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

        if (string.IsNullOrWhiteSpace(userName))
        {
          return Unauthorized();
        }

        if (await _userManager.FindByNameAsync(userName) == null)
        {
          return Unauthorized();
        }

        var subCategorys = await this._context.Companys
          .Where(company => company.CategoryName == getEmails.Category && company.Category == getEmails.SubCategory)
          .Select(company => company.Email)
          .Distinct()
          .Take(100)
          .ToListAsync();

        return Ok(subCategorys.Where(email => email != string.Empty));
      }
      catch (Exception ex)
      {
        await this._telegramService.SendMessageExceptionAsync(ex);

        return BadRequest();
      }
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheCallCenter.Data;

namespace TheCallCenter.Controllers
{
  [ApiController]
  [Route("api/calls")]
  public class CallsController : Controller
  {
    private readonly CallCenterContext _ctx;

    public CallsController(CallCenterContext ctx)
    {
      _ctx = ctx;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var calls = await _ctx.Calls.ToListAsync();

      return Ok(calls);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        var call = await _ctx.Calls.Where(c => c.Id == id).FirstOrDefaultAsync();
        if (call == null) return BadRequest();

        _ctx.Remove(call);
        if (await _ctx.SaveChangesAsync() > 0)
        {
          return Ok(new { success = true });
        }
        else
        {
          return BadRequest("Database Error");
        }
      }
      catch
      {
        return StatusCode(500);
      }
    }
  }
}

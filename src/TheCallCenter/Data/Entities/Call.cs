using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCallCenter.Data.Entities
{
    public class Call
    {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Problem { get; set; }
    public DateTime CallTime { get; set; } = DateTime.UtcNow;
    public bool Answered { get; set; } = false;
    public DateTime AnswerTime { get; set; } = DateTime.MinValue;
  }
}

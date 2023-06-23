using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCallCenter.Data.Entities
{
    public class Call
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Problem { get; set; } = null!;

        public DateTime CallTime { get; set; } = DateTime.UtcNow;

        public bool Answered { get; set; } = false;

        public DateTime AnswerTime { get; set; } = DateTime.MinValue;
      }
}

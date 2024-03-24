using PersonalCollection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCollection.Application.Models.Dto
{
    public class LikeDto
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? Author { get; set; }
        public int ItemId { get; set; }
    }
}

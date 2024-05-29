using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplicationTracker.Models.Dtos
{
    public class UpdateApplicationDto
    {
        public required string Company { get; set; }
        public string? Position { get; set; }
        public required DateOnly Deadline { get; set; }
        public bool? Applied { get; set; }
    }
}
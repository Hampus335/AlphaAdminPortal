﻿using Data.Entities;

namespace Data.DTOs
{
    public class ProjectDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; } = null!;
        public string ClientName { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Budget { get; set; }
    }
}

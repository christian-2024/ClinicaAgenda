using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinAgenda.src.Application.DTOs.Specialty
{
    public class SpecialtyDTO
    {
        public int id { get; set; }

        public required string Name { get; set; }

        public int ScheduleDuration { get; set; }
    }
}
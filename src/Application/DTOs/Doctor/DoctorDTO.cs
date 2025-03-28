using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinAgenda.src.Application.DTOs.Doctor
{
    public class DoctorDTO
    {
        public int id { get; set;}
        public required string Name { get; set; }

        public required int SpecialtyId { get; set; }

        public required int StatusId { get; set; }
    }
}
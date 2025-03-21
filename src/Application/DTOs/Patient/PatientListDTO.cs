using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinAgenda.src.Application.DTOs.Patient
namespace ClinAgenda.src.Application.DTOs.Status
{
    public class PatientListDTO
    {
        public required string Name { get; set; }

        public required string PhoneNumber { get; set; }

        public required string DocumentNumber { get; set; }

        public required StatusDTO Status { get; set; }

        public required string Birthdateday { get; set; } 
    }
}
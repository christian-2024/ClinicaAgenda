using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinAgenda.src.Application.DTOs.Status;

namespace ClinAgenda.src.Application.DTOs.Doctor
{
    public class DoctorListReturnDTO
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required int specialityId { get; set; }
        public required StatusDTO Status { get; set; }
    }
}
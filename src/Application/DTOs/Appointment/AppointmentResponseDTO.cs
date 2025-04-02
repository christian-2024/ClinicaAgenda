using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinAgenda.src.Application.DTOs.Appointment
{
    public class AppointmentResponseDTO
    {
        public int total {get; set;}

        public List<AppointmentListReturnDTO> items { get; set;}
    }
}
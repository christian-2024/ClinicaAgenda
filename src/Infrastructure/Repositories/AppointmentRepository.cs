using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinAgenda.src.Application.DTOs.Appointment;
using ClinAgenda.src.Core.Interfaces;
using Dapper;
using MySql.Data.MySqlClient;

namespace ClinAgenda.src.Infrastructure.Repositories
{
    public class AppointmentRepository : IApplicationBuilder
    {
        private readonly MySqlConnection _connection;
    

        public AppointmentRepository(MySqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<(int total, IEnumerable<AppointmentDTO> appointment)> GetAppointmentAsync(string? patientName, string? doctorName, int? specialtyId, int itemsPerPage, int page)
        {
            var queryBase = new StringBuilder(@"
            FROM Appointment A
            INNER JOIN PATIENT P ON P.ID = A.PATIENTID
            INNER JOIN DOCTOR D ON D.ID = A.DOCTORID
            INNER JOIN SPECIALTY S ON S.ID = A.SPECIALTYID");

            var parameters = new DynamicParameters();

            if(!string.IsNullOrEmpty(patientName))
            {
                queryBase.Append(" AND P.NAME LIKE @Name");
                parameters.Add("Name", $"%{patientName}%");   
            }

            if (!string.IsNullOrEmpty(doctorName))
            {
                queryBase.Append(" AND D.NAME LIKE @DoctorName");
                parameters.Add("DoctorName",$"%{doctorName}%");
            }
            
            if (specialtyId.HasValue)
            {
                queryBase.Append(" AND S.ID = @SpecialtyId");
                parameters.Add("SpecialtyId", specialtyId.Value);
            }

            var countQuery = $"SELECT COUNT(DISTINCT A.ID) {queryBase}";
            int total = await _connection.ExecuteScalarAsync<int>(countQuery, parameters);

            var dataQuery = $@"
            SELECT 
            A.ID,
            P.NAME AS PATIENTNAME,
            P.DOCUMENTNUMBER AS PATIENTDOCUMENT,
            D.NAME AS DOCTORNAME,
            S.ID AS SPECIALTYID,
            S.NAME AS SPECIALTYNAME,
            S.SCHEDULEDURATION AS SCHEDULEDURATION,
            A.APPOINTMENTDATE AS APPOINTMENTDATE
            {queryBase}
            ORDER BY A.ID
            LIMIT @Limit OFFSET @offset";

            parameters.Add("Limit", itemsPerPage);
            parameters.Add("OffSet", (page - 1) * itemsPerPage);

                
        }
    } 
}
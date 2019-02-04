using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Interfaces
{
    public interface IPatientRepository
    {
        Patient GetPatient(int PatientId);
    }
}

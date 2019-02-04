using RestApi.Interfaces;
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApi.Repository
{
    public class PatientRepository : IPatientRepository
    {
        #region Constractor
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly IDatabaseContext _databaseContext = null;
        public PatientRepository(IDatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method to get patient details along with episodes associated with the patient
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public Patient GetPatient(int patientId)
        {
            var patient = new Patient();
            try
            {
                patient = _databaseContext.Patients.Where(P => P.PatientId == patientId).FirstOrDefault();
                if (patient != null)
                {
                    patient.Episodes = _databaseContext.Episodes.Where(E => E.PatientId == patientId).ToList();
                }
            }
            catch (Exception ex)
            {
                logger.Trace($"StackTrace: {ex.StackTrace}");
                logger.Error($"Exception Message: {ex.Message}");
            }
            return patient;
        }
        #endregion
    }
}
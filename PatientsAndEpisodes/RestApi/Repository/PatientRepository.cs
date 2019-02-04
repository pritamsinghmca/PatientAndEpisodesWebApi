using RestApi.Interfaces;
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApi.Repository
{
    /// <summary>
    /// PatientRepository class.
    /// It's a concrete class which implements IPatientRepository interface.
    /// its a repository which provids functionality against patient entity.
    /// </summary>
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
        /// Method to get patient record along with episodes associated with the patient
        /// based on patientId.
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public Patient GetPatient(int patientId)
        {
            var patient = new Patient();
            try
            {
                
                // Load the blog related to a given post

                patient = _databaseContext.Patients
                                            .AsQueryable()
                                            .Where(P => P.PatientId == patientId)
                                            .FirstOrDefault();
                if (patient != null)
                {
                    patient.Episodes = _databaseContext.Episodes
                                                        .AsQueryable()
                                                        .Where(E => E.PatientId == patientId)
                                                        .ToList();
                }
                else { patient = new Patient(); patient.PatientId = patientId; }
            }
            catch (Exception ex)
            {
                logger.Trace($"StackTrace: {ex.StackTrace}");
                logger.Error($"Exception : {ex.Message}");
            }
            return patient;
        }
        #endregion
    }
}
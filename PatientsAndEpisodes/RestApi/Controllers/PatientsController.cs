using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestApi.Interfaces;
using RestApi.Models;

namespace RestApi.Controllers
{
    public class PatientsController : ApiController
    {
        #region Constractor and Variables
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly IPatientRepository _patientRepository = null;
        public PatientsController(IPatientRepository patientRepository)
        {
            this._patientRepository = patientRepository;
        }
        #endregion

        #region API Action Methods
        /// <summary>
        /// Retuens patient detils along with episodes associated with patient
        /// based on passed patientId
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        [HttpGet]
        public Patient Get(int patientId)
        {
            try
            {
                return _patientRepository.GetPatient(patientId);
            }
            catch (Exception ex)
            {
                logger.Trace($"StackTrace: {ex.StackTrace}");
                logger.Error($"Exception : {ex.Message}");
            }
            return null;
        }
        #endregion
    }
}

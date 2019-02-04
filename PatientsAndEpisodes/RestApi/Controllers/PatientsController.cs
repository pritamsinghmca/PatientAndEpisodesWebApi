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
        private readonly IDatabaseContext _databaseContext = new InMemoryPatientContext();
        public PatientsController(IPatientRepository patientRepository)
        {
            this._patientRepository = patientRepository;
            //this._databaseContext = databaseContext;

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
            var patientDetials = new Patient();
            try
            {
                if (patientId > 0)
                {
                    patientDetials = _patientRepository.GetPatient(patientId);
                }
            }
            catch (Exception ex)
            {
                logger.Trace($"StackTrace: {ex.StackTrace}");
                logger.Error($"Exception Message: {ex.Message}");
            }

            return patientDetials;
        }
        //[HttpGet]
        //public HttpResponseMessage Get(int patientId)
        //{
        //    HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
        //    try
        //    {
        //        if (patientId > 0)
        //        {
        //            var patient = _patientRepository.GetPatient(patientId);
        //            if (patient == null) { httpResponseMessage = Request.CreateResponse(HttpStatusCode.NotFound, "Patient Not Found"); }
        //            else { httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, patient); }
        //        }
        //        else
        //        {
        //            httpResponseMessage = Request.CreateResponse(HttpStatusCode.BadRequest, "Bad Request");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Trace($"StackTrace: {ex.StackTrace}");
        //        logger.Error($"Exception Message: {ex.Message}");
        //        httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured while executing patient api");
        //    }

        //    return httpResponseMessage;
        //}
        #endregion
    }
}

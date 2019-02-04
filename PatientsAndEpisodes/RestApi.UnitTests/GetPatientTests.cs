using NUnit.Framework;
using RestApi.Controllers;
using RestApi.Interfaces;
using RestApi.Models;
using RestApi.Repository;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace RestApi.UnitTests
{
    /// <summary>
    /// GetPatientTests Class.
    /// The class is created to put and test all the test case associated with Patient.
    /// </summary>
    [TestFixture]
    public class GetPatientTests
    {
        #region Constractor and Variables
        private readonly IPatientRepository patientRepository = null;
        public GetPatientTests()
        {
            this.patientRepository = new PatientRepository(new PatientContext());
        }
        #endregion

        #region Test Methods

        /// <summary>
        /// GetPatient_GettingPatientBasedOnPatientIdTest_ReturnPatientRecord Method.
        /// Based on the patientid getting and checking correct pattient.
        /// But We are not checking patient's episodes.
        /// If patient's episodes needs to be checked, we can create a new test case for the same.
        /// </summary>
        [Test]
        public void GetPatient_GettingPatientBasedOnPatientIdTest_ReturnPatientRecord()
        {
            //ARRANGE
            int patientId = 1;
            var patientsController = new PatientsController(patientRepository);
            var expectedPatient = new Patient()
            {
                DateOfBirth = new DateTime(1972, 10, 27),
                FirstName = "Millicent",
                PatientId = 1,
                LastName = "Hammond",
                NhsNumber = "1111111111"
            };

            //ACT
            var actualPatient = patientsController.Get(patientId);

            //ASSERT
            Assert.That(expectedPatient.DateOfBirth, Is.EqualTo(actualPatient.DateOfBirth));
            Assert.That(expectedPatient.FirstName, Is.EqualTo(actualPatient.FirstName));
            Assert.That(expectedPatient.LastName, Is.EqualTo(actualPatient.LastName));
            Assert.That(expectedPatient.PatientId, Is.EqualTo(actualPatient.PatientId));
            Assert.That(expectedPatient.NhsNumber, Is.EqualTo(actualPatient.NhsNumber));
        }

        /// <summary>
        /// GetPatient_CheckingNullTest_ReturnPatientRecord Test Method.
        /// Checking null patient record based on patientId.
        /// </summary>
        [Test]
        public void GetPatient_CheckingNullTest_ReturnPatientRecord()
        {
            //ARRANGE
            int patientId = 5;
            var patientsController = new PatientsController(patientRepository);

            //ACT
            var actualPatient = patientsController.Get(patientId);

            //ASSERT
            Assert.That(actualPatient.NhsNumber, Is.Null);
            Assert.That(actualPatient.FirstName, Is.Null);
            Assert.That(actualPatient.LastName, Is.Null);
            Assert.That(actualPatient.Episodes, Is.Null);
        }
       
        #endregion
    }
}
using NUnit.Framework;
using RestApi.Controllers;
using RestApi.Interfaces;
using RestApi.Models;
using RestApi.Repository;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace RestApi.UnitTests
{
    /// <summary>
    /// GetPatientTests Class.
    /// 
    /// </summary>
    [TestFixture]
    public class GetPatientTests
    {
        #region Constractor and Variables
        private readonly IPatientRepository _patientRepository = null;
        private  PatientsController _patientsController = null;
        public GetPatientTests()
        {
            this._patientRepository = new PatientRepository(new PatientContext());
        }
        #endregion
        
        [Test]
        public void GetPatient_GettingPatient_ReturnPatient()
        {
            //Arrange
            int patientId = 1;
            _patientsController = new PatientsController(_patientRepository);
            // _patientsController.Request = new HttpRequestMessage();
            //_patientsController.Configuration = new HttpConfiguration();

            //Act
            var patientDetials = _patientsController.Get(patientId);

            //assert
            Assert.IsNotNull(patientDetials);
            Assert.AreEqual(patientId, patientDetials.PatientId);
        }

        [Test]
        public void PutItem_ShouldReturnStatusCode()

        {
            //var v = StatusCodeResult;
            //var controller = new ItemController(new TestUnitTestMockingConext());

            //var item = GetDemoItem();

            //var result = controller.PutItem(item.ID, item) as StatusCodeResult;

            //Assert.IsNotNull(result);

            //Assert.IsInstanceOfType(result, typeof(StatusCodeResult));

            //Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);

        }

        ////ARRANGE
        //// var expected = new List<Employee>(1) {
        //// new Employee() { Id = 1, Email = "email", Name = "name", Phone = "123" }
        ////};
        //int patientId = 1;
        //Mock<IPatientRepository> mockRepository = new Mock<IPatientRepository>();
        //mockRepository.Setup(x => x.GetPatient(patientId));//.Returns(() => expected);
        //var controller = new PatientsController(mockRepository.Object);
        //controller.Request = new HttpRequestMessage()
        //{
        //    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
        //};

        ////ACT
        //var response = controller.Get(patientId);

        ////ASSERT
        //Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        ////var actual = response.Content.ReadAsAsync<List<Employee>>().Result;
        ////Assert.AreEqual(expected.Count, actual.Count);
        ////Assert.AreNotEqual(null, response.Content);
    }
}
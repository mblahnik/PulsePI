using PulsePI.Models;
using Xunit;
using System;
using Moq;
using PulsePI.DataContracts;
using FluentAssertions;
using PulsePI.Controllers;
using PulsePI.Service;
using PulsePI.Service.ServiceInterfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PulsePI.MessageContracts;



namespace PulseTest.ControllerTest{

      public class HeartRateRecordController {

        private Mock<IHeartRateRecordService> mockHeartRateRecordService = new Mock<IHeartRateRecordService>();

        [Fact]
        public void HeartRateRecordController_RecordHeartRate_Test()
        {
            //arrange 
            var mockController = new HeartRateRecordController();
             var heartRateRecordData = new HeartRateRecordData()
            {
                username = "Susan",
                type = "Running",
                startTime = 983409823704981,
                endTime = 8304983209483200,
                bpmLow = 50.0,
                bpmHigh = 150.0,
                bpmAvg = 100.0
            };

            //act 
            var result = mockHeartRateRecordService.Object.RecordHeartRate(heartRateRecordData);

            //assert
            Assert.True(result.IsCompletedSuccessfully);
        }
      

      }

}
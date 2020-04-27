using System;
using Moq;
using PulsePI.DataContracts;
using FluentAssertions;
using PulsePI.Service.ServiceInterfaces;
using Xunit;

namespace PulseTest.ServiceTests
{
    public class HeartRateRecordServiceTests
    {
        private Mock<IHeartRateRecordService> mockHeartRateRecordService = new Mock<IHeartRateRecordService>();

        [Fact]
        public void HeartRateRecordService_RecordHeartRate_Test()
        {
            //arrange 
            var heartRateRecordData = new HeartRateRecordData()
            {

                username = "Username",
                type = "Exercise",
                startTime = 983409823704981,
                endTime = 8304983209483200,
                bpmLow = 50.0,
                bpmHigh = 150.0,
                bpmAvg = 100.0

            };

            //act 
            var response = mockHeartRateRecordService.Object.RecordHeartRate(heartRateRecordData);

            //assert
            Assert.True(response.IsCompletedSuccessfully);
            mockHeartRateRecordService.Verify();
        }
[Fact]
        public void HeartRateRecordService_GetAllHeartRateData_Test()
        {
            //arrange 
            var heartRateRecordData = new UsernameData()
            {
                username = "wolfmuffin",
            };

            //act 
            var response = mockHeartRateRecordService.Object.GetAllHeartRateData(heartRateRecordData);

            //assert
            Assert.True(response.IsCompletedSuccessfully);
            mockHeartRateRecordService.Verify();
        }

        [Fact]
        public void HeartRateRecordService_GetRestingHeartRateHistory_Test()
        {
            //arrange 
            var heartRateRecordData = new UsernameData()
            {
                username = "tomato17",
            };

            //act 
            var response = mockHeartRateRecordService.Object.GetRestingHeartRateHistory(heartRateRecordData);

            //assert
            Assert.True(response.IsCompletedSuccessfully);
            mockHeartRateRecordService.Verify();
        }


[Fact]
        public void HeartRateRecordService_GetExerciseHeartRateHistory_Test()
        {
            //arrange 
            var heartRateRecordData = new UsernameData()
            {
                username = "catfish",
            };

            //act 
            var response = mockHeartRateRecordService.Object.GetExerciseHeartRateHistory(heartRateRecordData);

            //assert
            Assert.True(response.IsCompletedSuccessfully);
            mockHeartRateRecordService.Verify();
        }


[Fact]
        public void HeartRateRecordService_GetRestingRates_Test()
        {
            //arrange 
            var heartRateRecordData = new UsernameData()
            {
                username = "batman",
            };

            //act 
            var response = mockHeartRateRecordService.Object.GetRestingRates(heartRateRecordData);

            //assert
            Assert.True(response.IsCompletedSuccessfully);
            mockHeartRateRecordService.Verify();
        }
    }

}

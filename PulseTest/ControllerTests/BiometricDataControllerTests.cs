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

      public class BiometricDataControllerTests {

        private Mock<IBiometricService> mockBiometricService = new Mock<IBiometricService>();

        [Fact]
        public void BiometricService_CreateBiometric_Test()
        {
            //arrange 
                var biometricData = new BiometricData()
            {
                username = "jack",
                height = "6.0",
                weight = "152",
                sex = "M",
             dob = "1995/04/23"
            };
            //act 
            var result = mockBiometricService.Object.CreateBiometric(biometricData);

            //assert
            Assert.True(result.IsCompletedSuccessfully);
        }

        [Fact]
        public void BiometricService_GetIntensities_Test()
        {
            //arrange 
                var biometricData = new UsernameData()
            {
                username = "yikes",
            };
            //act 
            var result = mockBiometricService.Object.GetIntensities(biometricData);

            //assert
            Assert.True(result.IsCompletedSuccessfully);
        }
      
[Fact]
        public void BiometricService_GetBiometricData_Test()
        {
            //arrange 
                var biometricData = new UsernameData()
            {
                username = "newone",
            };
            //act 
            var result = mockBiometricService.Object.GetBiometricData(biometricData);

            //assert
            Assert.True(result.IsCompletedSuccessfully);
        }
      
      [Fact]
        public void BiometricService_GetHRBounds_Test()
        {
            //arrange 
                var biometricData = new UsernameData()
            {
                username = "newone2",
            };
            //act 
            var result = mockBiometricService.Object.GetHRBounds(biometricData);

            //assert
            Assert.True(result.IsCompletedSuccessfully);
        }

         [Fact]
        public void BiometricService_GetRanges_Test()
        {
            //arrange 
                var biometricData = new UsernameData()
            {
                username = "newone3",
            };
            //act 
            var result = mockBiometricService.Object.GetRanges(biometricData);

            //assert
            Assert.True(result.IsCompletedSuccessfully);
        }

      }

}
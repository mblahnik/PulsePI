using System;
using Moq;
using PulsePI.DataContracts;
using FluentAssertions;
using PulsePI.Service.ServiceInterfaces;
using Xunit;

namespace PulseTest.ServiceTests
{
    public class BiometricServiceTests
    {
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
            var response = mockBiometricService.Object.CreateBiometric(biometricData);

            //assert
            Assert.True(response.IsCompletedSuccessfully);
            mockBiometricService.Verify();
        }
[Fact]
 public void BiometricService_GetIntensities_Test()
        {
            //arrange 
            var IntensitiesData = new UsernameData()
            {
                username = "mock123",
            };

            //act 
            var response = mockBiometricService.Object.GetIntensities(IntensitiesData);

            //assert
            Assert.True(response.IsCompletedSuccessfully);
            mockBiometricService.Verify();
        }

        [Fact]
 public void BiometricService_GetBiometricData_Test()
        {
            //arrange 
            var BiometricData = new UsernameData()
            {
                username = "test",
            };

            //act 
            var response = mockBiometricService.Object.GetBiometricData(BiometricData);

            //assert
            Assert.True(response.IsCompletedSuccessfully);
            mockBiometricService.Verify();
        }

         [Fact]
 public void BiometricService_GetHRBounds_Test()
        {
            //arrange 
            var BiometricData = new UsernameData()
            {
                username = "sally",
            };

            //act 
            var response = mockBiometricService.Object.GetHRBounds(BiometricData);

            //assert
            Assert.True(response.IsCompletedSuccessfully);
            mockBiometricService.Verify();
        }

        [Fact]
 public void BiometricService_GetRanges_Test()
        {
            //arrange 
            var BiometricData = new UsernameData()
            {
                username = "potato",
            };

            //act 
            var response = mockBiometricService.Object.GetRanges(BiometricData);

            //assert
            Assert.True(response.IsCompletedSuccessfully);
            mockBiometricService.Verify();
        }
        

    }

}

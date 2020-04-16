using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PulsePI.DataAccess.DaoInterfaces;
using PulsePI.DataContracts;
using PulsePI.Exceptions;
using PulsePI.MessageContracts;
using PulsePI.Models;
using PulsePI.Service.ServiceInterfaces;

namespace PulsePI.Service
{
    public class BiometricService : IBiometricService
    {
        IBiometricDataDao _bio;
        IHeartRateRecordDao _heart;

        public BiometricService(IBiometricDataDao b, IHeartRateRecordDao h)
        {
            _bio = b;
            _heart = h;
        }
        public async Task CreateBiometric(BiometricData cbd)
        {
            var biometric = new Biometric()
            {
                height = cbd.height,
                weight = cbd.weight,
                Date = ConvertToDateTime(cbd.Date),
                sex = cbd.sex,
                //dob = ConvertToDateTime(cbd.dob),
            };
            try
            {
                await _bio.CreateBiometricData(biometric);
            }
            catch (Exception e)
            {
                throw new CustomException("Error at creating biometric service" + e);
            }

        }

        public async Task<GetExerciseIntensityMsg> GetIntensities(UsernameData data)
        {
            List<GetExerciseHeartRateMsg> records = null;
            Biometric bio = null;

            try
            {
                records = await _heart.GetExerciseHeartRateHistory(data);
                bio = await _bio.GetMostRecentRecord(data);
            }
            catch (Exception e)
            {
                throw new CustomException("Error getting HR data in service" + e);
            }

            return CalculateIntensities(records, bio);
        }

        private GetExerciseIntensityMsg CalculateIntensities(List<GetExerciseHeartRateMsg> list, Biometric bio)
        {
            string time;
            //Needs to come from bio eventually 
            int age = 28;
            double avgBmp;
            double intensity;
            GetExerciseIntensityMsg message = new GetExerciseIntensityMsg();
            message.Dates = new List<string>();
            message.Percentages = new List<double>();
            int i = 0;

            List<PersonalIntensities> personalIntensities = GetPersonalIntensities(age);

            foreach (GetExerciseHeartRateMsg msg in list)
            {
                time = msg.startTime;
                avgBmp = msg.bpmAvg;
                intensity = GetClosestIntensity(avgBmp, personalIntensities);
                message.Dates.Add(time);
                message.Percentages.Add(intensity);
                ++i;
            }
            return message;
        }

        private List<PersonalIntensities> GetPersonalIntensities(int age)
        {
            List<PersonalIntensities> list = new List<PersonalIntensities>();
            int i = 10;
            int target = 150 - age;
            while(i <= 100)
            {
                var pi = new PersonalIntensities();
                pi.intensity = i;
                pi.heartRate = target * ((double)i / 100.0);
                i += 10;
                list.Add(pi);
            }
            return list;
        }

        private double GetClosestIntensity(double bpm, List<PersonalIntensities> intensities)
        {
            double closestBpm = 0;
            double closestInt = 0;

            foreach(PersonalIntensities pi in intensities)
            {
                double closestDiff = Math.Abs(bpm - closestBpm);
                double thisDiff = Math.Abs(bpm - pi.heartRate);
                if(thisDiff <= closestDiff)
                {
                    closestBpm = pi.heartRate;
                    closestInt = pi.intensity;
                }
            }
            return closestInt;
        }

        private DateTime ConvertToDateTime(long unixDate)
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return start.AddMilliseconds(unixDate).ToLocalTime();
        }

        public class PersonalIntensities
        {
            public double intensity { get; set; }
            public double heartRate { get; set; } 
        }

    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
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
                height = double.Parse(cbd.height),
                weight = double.Parse(cbd.weight),
                Date = DateTime.Now,
                sex = char.Parse(cbd.sex),
                dob = DateTime.Parse(cbd.dob),
            };

            try
            {
                await _bio.CreateBiometricData(biometric, cbd.username);
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

            int age = CalculateAge(bio.dob);
            return CalculateIntensities(records, age);
        }

        public async Task<GetBiometricDataMsg> GetBiometricData(UsernameData data)
        {
            GetBiometricDataMsg msg = new GetBiometricDataMsg();
            Biometric b = null;
            try
            {
                b = await _bio.GetBiometricData(data);
            }
            catch(Exception e)
            {
                throw new CustomException("Error getting biometrics in service" + e);
            }
            msg.height = b.height.ToString();
            msg.weight = b.weight.ToString();
            msg.sex = b.sex.ToString();
            msg.dob = b.dob.ToShortDateString();
            return msg;

        }

        public async Task<GetHRBoundsMsg> GetHRBounds(UsernameData data)
        {
            GetHRBoundsMsg msg = new GetHRBoundsMsg();
            Biometric bio = null;
            try
            {
                bio = await _bio.GetMostRecentRecord(data);
            }
            catch (Exception e)
            {
                throw new CustomException("Error getting HR data in service" + e);
            }

            int age = CalculateAge(bio.dob);
            msg.maxHR = 220 - age;
            msg.heartRateReserve = msg.maxHR - 70;
            double seventy = msg.heartRateReserve * 0.7 + 70;
            double eightFive = msg.heartRateReserve * 0.85 + 70;
            msg.targetHR = Math.Round((seventy + eightFive) / 2, 0);
            return msg;

        }

        public async Task<GetRangesMsg> GetRanges(UsernameData data)
        {
            GetRangesMsg msg = new GetRangesMsg();
            Biometric bio = null;
            try
            {
                bio = await _bio.GetMostRecentRecord(data);
            }
            catch (Exception e)
            {
                throw new CustomException("Error getting HR data in service" + e);
            }
            int age = CalculateAge(bio.dob);
            int maxHR = 220 - age;
            int heartRateReserve = maxHR - 70;

            msg.fiftyPerc = Math.Round(heartRateReserve * 0.5 + 70, 0);
            msg.sixtyPerc = Math.Round(heartRateReserve * 0.6 + 70, 0);
            msg.seventyPerc = Math.Round(heartRateReserve * 0.7 + 70, 0);
            msg.eightyPerc = Math.Round(heartRateReserve * 0.8 + 70, 0);
            msg.ninetyPerc = Math.Round(heartRateReserve * 0.9 + 70, 0);
            msg.hundPerc = Math.Round(heartRateReserve * 1.0 + 70, 0);
            return msg;
        }

        private int CalculateAge(DateTime dob)
        {
            var today = DateTime.Today;
            return today.Year - dob.Year;
        }

        private GetExerciseIntensityMsg CalculateIntensities(List<GetExerciseHeartRateMsg> list, int age)
        {
            string time;
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
                pi.heartRate = target * ((double)i / 100.0) + 70;
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
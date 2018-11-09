using System;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using Calendar.Data;
using Calendar.Data.Infrastructure;
using Calendar.Data.Repositories;
using Calendar.ViewModel;
using FakeItEasy;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Calendar.Service.Tests
{
    [TestClass]
    public class ReservationServiceTest
    {
        
        [TestCase(8)]
        [TestCase(1)]
        public void WhenCheckingPreReservation_ThenReturnTrue(int howmanyPeoples)
        {
            var preReservation = new PreReservationViewModel
            {
                FromWhatTime=new TimeSpan(12,0,0),
                ToWhatTime= new TimeSpan(13, 30, 0),
                HowManyPeoples=howmanyPeoples,
                ReservationDate=new DateTime(2018,9,19)
            };

            IServiceReservation service = new ReservationService();
            var check = service.CheckPreReservation(preReservation);
            Assert.IsTrue(check);
        }
     
        [TestCase(9)]
        [TestCase(34)]
        public void WhenCheckingPreReservation_ThenReturnFalse(int howmanyPeoples)
        {
            var preReservation = new PreReservationViewModel
            {
                FromWhatTime = new TimeSpan(12, 0, 0),
                ToWhatTime = new TimeSpan(13, 30, 0),
                HowManyPeoples = howmanyPeoples,
                ReservationDate = new DateTime(2018, 9, 19)
            };

            IServiceReservation service = new ReservationService();
            var check = service.CheckPreReservation(preReservation);
            Assert.IsFalse(check);
        }

        [TestCase(6)]
        public void WhenCheckingPreReservation_ThenReturnTwotables(int howmanyPeoples)
        {
            var preReservation = new PreReservationViewModel
            {
                FromWhatTime = new TimeSpan(12, 0, 0),
                ToWhatTime = new TimeSpan(13, 30, 0),
                HowManyPeoples = howmanyPeoples,
                ReservationDate = new DateTime(2018, 9, 19)
            };

            IServiceReservation service = new ReservationService();
            var check = service.GetAvailable(preReservation);
        }









    }
}

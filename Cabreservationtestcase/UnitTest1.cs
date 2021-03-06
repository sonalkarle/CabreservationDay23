using NUnit.Framework;
using Cabreservation;
using System.Collections.Generic;
namespace TDDCabServiceTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGeneratorNormalRide;
        RideRepository rideRepository;
        [SetUp]
        public void Setup()
        {
            invoiceGeneratorNormalRide = new InvoiceGenerator(InvoiceGenerator.ServiceType.NORMAL_RIDE);
            rideRepository = new RideRepository();
        }
        /// <summary>
        /// UC1:Calculate the normal ride fare
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <param name="output"></param>
        [Test]
        [TestCase(5, 3)]
        
        public void GivenTimeAndDistance_calculateFare(double distance, double time)
        {
            Ride ride = new Ride(distance, time);
            int expected = 53;
            Assert.AreEqual(expected, invoiceGeneratorNormalRide.TotalFareForSingleRidereturn(ride));
        }
        //TC1.1 :Check for invalid distance
        [Test]
        public void GivenInvalidDistance_ThrowException()
        {
            Ride ride = new Ride(-1, 1);
            InvoiceGeneratorException invoiceGeneratorException = Assert.Throws<InvoiceGeneratorException>(() => invoiceGeneratorNormalRide.TotalFareForSingleRidereturn(ride));
            Assert.AreEqual(invoiceGeneratorException.type, InvoiceGeneratorException.ExceptionType.INVALID_DISTANCE);
        }
        //TC1.2: Check for invalid time
        [Test]
        public void GivenInvalidTime_ThrowException()
        {
            Ride ride = new Ride(1, -1);
            InvoiceGeneratorException invoiceGeneratorException2 = Assert.Throws<InvoiceGeneratorException>(() => invoiceGeneratorNormalRide.TotalFareForSingleRidereturn(ride));
            Assert.AreEqual(invoiceGeneratorException2.type, InvoiceGeneratorException.ExceptionType.INVALID_TIME);
        }
        /// <summary>
        /// UC2:Checking for multiple rides and aggregate fare
        /// UC3:Enhanced the fare by finding average fare,totalfare,number of rides
        /// </summary>
        [Test]
        public void GivenListOfRides_GenerateInvoice()
        {
            Ride ride1 = new Ride(2, 2);
            Ride ride2 = new Ride(2, 1);
            
            List<Ride> rides = new List<Ride>();
            rides.Add(ride1);
            rides.Add(ride2);
           
            Assert.AreEqual(43.0d, invoiceGeneratorNormalRide.TotalFareForMultipleRidesreturn(rides));
            Assert.AreEqual(21.5d, invoiceGeneratorNormalRide.averagePerRide);
            Assert.AreEqual(2, invoiceGeneratorNormalRide.numOfRides);
        }
       
    }
}
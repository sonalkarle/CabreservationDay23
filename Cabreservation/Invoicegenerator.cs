using System;
using System.Collections.Generic;
using System.Text;

namespace Cabreservation
{
    public class InvoiceGenerator
    {
        public enum ServiceType
        { NORMAL_RIDE, PREMIUM_RIDE }
        readonly int pricePerKilometer;
        readonly int pricePerMinute;
        readonly int minimumFare;
        public double totalFare;
        public int numOfRides;
        public double averagePerRide;
        private double numbOfRides;

        public InvoiceGenerator(ServiceType type)
        {
            if (type == ServiceType.NORMAL_RIDE)
            {
                this.pricePerKilometer = 10;
                this.pricePerMinute = 1;
                this.minimumFare = 5;
            }
            else if (type == ServiceType.PREMIUM_RIDE)
            {
                this.pricePerKilometer = 15;
                this.pricePerMinute = 2;
                this.minimumFare = 20;
            }
            totalFare = 0;
            numOfRides = 0;
        }
       
        
        public double TotalFareForSingleRidereturn(Ride ride)
        {


            if (ride.distance < 0)
            {
                throw new InvoiceGeneratorException(InvoiceGeneratorException.ExceptionType.INVALID_DISTANCE, "Invalid distance encountered!");
            }
            if (ride.time < 0)
            {
                throw new InvoiceGeneratorException(InvoiceGeneratorException.ExceptionType.INVALID_TIME, "Invalid time encountered!");
            }
            return Math.Max(minimumFare, ride.distance * pricePerKilometer + ride.time * pricePerMinute);
        }


    }
    
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Cabreservation
{
   
    class RideRepository
    {
        
        public Dictionary<string, List<Ride>> rideRepository;
        /// <summary>
        /// Adds to ride repository.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="ride">The ride.</param>
        public void AddRideRepository(string userId, Ride ride)
        {
            if (rideRepository.ContainsKey(userId))
            {
                rideRepository[userId].Add(ride);
            }
            else
            {
                rideRepository.Add(userId, new List<Ride>());
            }
        }

        public RideRepository()
        {
            rideRepository = new Dictionary<string, List<Ride>>();
        }
        /// <summary>
        /// Returns the list by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
       
        public List<Ride> returnListByUserId(string userId)
        {
            if (rideRepository.ContainsKey(userId))
            {
                return rideRepository[userId];
            }
            else
                throw new InvoiceGeneratorException(InvoiceGeneratorException.ExceptionType.INVALID_USER_ID, "Invalid user id encountered");
        }
    }
}
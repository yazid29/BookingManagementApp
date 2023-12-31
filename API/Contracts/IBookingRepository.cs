﻿using API.DTO.Bookings;
using BookingManagementApp.Models;

namespace API.Contracts
{
    public interface IBookingRepository : IGeneralRepos<Booking>
    {
        /*
        IEnumerable<Booking> GetAll();
        Booking? GetByGuid(Guid guid);
        Booking? Create(Booking booking);
        bool Update(Booking booking);
        bool Delete(Booking booking);
        */
    }
}

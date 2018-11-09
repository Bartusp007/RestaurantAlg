using System;
using System.Collections.Generic;
using System.Text;
using Calendar.Model;
using Calendar.ViewModel;

namespace Calendar.Service
{
    public interface IServiceReservation
    {
        bool ReserveTable(ReservationViewModel reservationData);
        StringBuilder DisplayReservation(DateTime date);
        bool CheckPreReservation(PreReservationViewModel preReservation);
        List<Table> GetAvailable(PreReservationViewModel preReservation);
    }
}
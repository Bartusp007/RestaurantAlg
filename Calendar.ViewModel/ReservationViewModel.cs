using System;
using Calendar.Model;

namespace Calendar.ViewModel
{
    public class ReservationViewModel
    {
        public TimeSpan FromWhatTime { get; set; }
        public TimeSpan ToWhatTime { get; set; }
        public DateTime? ReservationDate { get; set; }
        public int HowManyPeoples { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Reservation UpdateModel(Reservation reservation)
        {

            reservation.FromWhatTime = FromWhatTime;
            reservation.ToWhatTime = ToWhatTime;
            reservation.ReservationDate = ReservationDate;
            reservation.HowManyPeoples = HowManyPeoples;
            reservation.Name = Name;
            reservation.Surname = Surname;
            reservation.Email = Email;
            reservation.PhoneNumber = PhoneNumber;
            return reservation;
        }
        public PreReservationViewModel UpdatePreReservation()
        {
            PreReservationViewModel preReservation = new PreReservationViewModel
            {
                FromWhatTime = FromWhatTime,
                ToWhatTime = ToWhatTime,
                HowManyPeoples = HowManyPeoples,
                ReservationDate = ReservationDate
            };
            return preReservation;
        }
    }
}

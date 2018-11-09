using System.Windows.Controls;

namespace Calendar
{
    public interface IOutputCalendarMessage
    {
        void MessageForNpotaAvailableTable(Label label);
        void MessageForAvailableTable(Label label);
        void MessageForSuccesfulReservation(Label label);
        void MessageForNotSuccesfulReservation(Label label);
        void MessageForErrorDuringReserwation(Label label);
        void MessageForBrakRezerwacji(Label label);
    }
}
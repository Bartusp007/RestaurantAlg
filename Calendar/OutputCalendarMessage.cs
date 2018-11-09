using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Calendar
{
    public class OutputCalendarMessage : IOutputCalendarMessage
    {
        public void MessageForNpotaAvailableTable(Label label)
        {
            label.Background = new SolidColorBrush(Colors.Red);
            label.Visibility = Visibility.Visible;
            label.Content = "Dla wybranej rezerwacji nie ma dostepnych stolikow!!!";
        }

        public void MessageForAvailableTable(Label label)
        {
            label.Background = new SolidColorBrush(Colors.GreenYellow);
            label.Visibility = Visibility.Visible;
            label.Content = "Dla wybranej rezerwacji istnieja dostepne stoliki";
        }

        public void MessageForSuccesfulReservation(Label label)
        {
            label.Background = new SolidColorBrush(Colors.GreenYellow);
            label.Visibility = Visibility.Visible;
            label.Content = "Rezerwacja przeszla pomysle. Milej kolacji";
        }

        public void MessageForNotSuccesfulReservation(Label label)
        {
           label.Background = new SolidColorBrush(Colors.Red);
            label.Visibility = Visibility.Visible;
            label.Content = "Niestety nie mamy dostepnych stolikow przosze sprobowac w innym terminie";
        }

        public void MessageForErrorDuringReserwation(Label label)
        {
            label.Background = new SolidColorBrush(Colors.Red);
            label.Visibility = Visibility.Visible;
            label.Content = "Niestety doszlo do bledu w czasie rejestrowania twojej rezerwacji.";
        }

        public void MessageForBrakRezerwacji(Label label)
        {
            label.Visibility = Visibility.Visible;
            label.Content = "Brak dostepnych rezerwacji.";
        }
    }
}
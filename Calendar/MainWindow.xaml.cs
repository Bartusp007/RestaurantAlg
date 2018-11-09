using System;
using System.Data.Entity;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Calendar.Data;
using Calendar.Data.Infrastructure;
using Calendar.Data.Repositories;
using Calendar.Model;
using Calendar.Service;
using Calendar.ViewModel;


namespace Calendar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [System.Runtime.InteropServices.Guid("563AE32F-3588-4B97-BBB8-1B96E434FE4B")]
    public partial class MainWindow : Window
    {

        private readonly IOutputCalendarMessage _outputCalendar;
        private readonly IServiceReservation _serviceReservationOperation;

        public MainWindow()
        {
            _serviceReservationOperation = new ReservationService();
            //Init DataBase
            Database.SetInitializer(new ReservationsSeedData());

            _outputCalendar = new OutputCalendarMessage();

            InitializeComponent();

            InitialiceCommunicationLabel();

            UploadAvailableHours();
        }

        private void InitialiceCommunicationLabel()
        {
            ComunicationLabel.Visibility = Visibility.Hidden;
            ComunicationLabel.MouseDoubleClick += new MouseButtonEventHandler(LB_Click);
        }

        protected void LB_Click(object sender, EventArgs e)
        {
            //attempt to cast the sender as a label
            Label lbl = sender as Label;

            ComunicationLabel.Visibility = Visibility.Hidden;
        }

        private void CheckVariablePreReservation()
        {
            if (int.Parse(TextBoxPreReservationIloscOsob.Text) == 0 || TextBoxPreReservationIloscOsob.Text == "")
            {
                MessageBox.Show("Wprowadzona wartosc osob jest nie poprawna prosze sprawdz.");
            }
            else if (Convert.ToInt16(ComboBoxGodzinaOdPreRezerwacji.Text) >=
                     Convert.ToInt16(ComboBoxGodzinaDoPreRezerwacji.Text))
            {
                MessageBox.Show(
                    "Godzina rozpoczecia rezerwacji nie moze byc pozniejsz od godziny zakonczenia rezerwacji.");
            }
            else if (DatePickerDataPreRezerwacji.DisplayDate < DateTime.Now)
            {
                MessageBox.Show("Data rezerwacji nie moze byc z przeszlosci.");
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var preReservation = new PreReservationViewModel
            {

                FromWhatTime = TimeSpan.Parse(ComboBoxGodzinaOdPreRezerwacji.Text),
                ToWhatTime = TimeSpan.Parse(ComboBoxGodzinaDoPreRezerwacji.Text),
                HowManyPeoples = int.Parse(TextBoxPreReservationIloscOsob.Text),
                ReservationDate = DatePickerDataPreRezerwacji.SelectedDate.Value

            };

            try
            {

                if (_serviceReservationOperation.CheckPreReservation(preReservation))
                {
                    _outputCalendar.MessageForAvailableTable(ComunicationLabel);
                }
                else
                {
                    _outputCalendar.MessageForNpotaAvailableTable(ComunicationLabel);
                }
            }
            catch (Exception)
            {

                _outputCalendar.MessageForErrorDuringReserwation(ComunicationLabel);
            }
        }



        private void Rezerwuj_Click(object sender, RoutedEventArgs e)
        {
            var reservationData = new ReservationViewModel
            {
                FromWhatTime = TimeSpan.Parse(ComboBoxGodzinaOdPRezerwacji.Text),
                ToWhatTime = TimeSpan.Parse(ComboBoxGodzinaDoRezerwacji.Text),
                ReservationDate = DatePickerDataRezerwazji.SelectedDate.Value,
                Name = TextBoxImie.Text,
                Surname = TextBoxNazwisko.Text,
                Email = TextBoxEmail.Text,
                PhoneNumber = TextBoxPhoneNumber.Text,
                HowManyPeoples = int.Parse(TextBoxIloscOsob.Text)

            };
            IOutputCalendarMessage message = new OutputCalendarMessage();


            try
            {
                if (_serviceReservationOperation.ReserveTable(reservationData))
                {
                    _outputCalendar.MessageForSuccesfulReservation(ComunicationLabel);
                }
                else
                {
                    _outputCalendar.MessageForNotSuccesfulReservation(this.ComunicationLabel);
                }
            }
            catch (Exception)
            {
                message.MessageForErrorDuringReserwation(ComunicationLabel);
            }
        }







        private void WyswietlRezerwacje_Click(object sender, RoutedEventArgs e)
        {



            if (DatePickerWyswietlrezerwacje.SelectedDate != null)
            {
                var allResevation =
                    _serviceReservationOperation.DisplayReservation(DatePickerWyswietlrezerwacje.SelectedDate.Value);
                InformationAboutTables.Content = "";
                InformationAboutTables.Content = allResevation;
            }
            else
            {
                InformationAboutTables.Content = "Wybierz poprawna date.";
            }
        }

        private void UploadAvailableHours()
        {
            var min = new TimeSpan(12, 0, 0);
            var max = new TimeSpan(22, 0, 0);
            var jumbSpan = new TimeSpan(0, 30, 0);

            for (var i = min; i <= max; i = i + jumbSpan)
            {
                this.ComboBoxGodzinaOdPRezerwacji.Items.Add($"{i.Hours}:{i.Minutes}");
                this.ComboBoxGodzinaDoRezerwacji.Items.Add($"{i.Hours}:{i.Minutes}");
                this.ComboBoxGodzinaOdPreRezerwacji.Items.Add($"{i.Hours}:{i.Minutes}");
                this.ComboBoxGodzinaDoPreRezerwacji.Items.Add($"{i.Hours}:{i.Minutes}");
                //Ladowanie Listy ze stolikamoi 

            }
        }
    }
}





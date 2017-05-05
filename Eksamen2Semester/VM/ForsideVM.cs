using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Eksamen2Semester.Annotations;
using Eksamen2Semester.Facade;
using Eksamen2Semester.Model;
using Eksamen2Semester.Singletonz;
using Eksamen2Semester.View;
using Eventmaker.Common;


namespace Eksamen2Semester.VM
{
    public class ForsideVM : INotifyPropertyChanged
    {

        public ObservableCollection<Booking> ForsideOC { get; set; }
        public RelayCommand NavigatePersonsøgningCommand { get; set; }
        public RelayCommand NavigateKursusBookingCommand { get; set; }
        public RelayCommand NavigateToTilføjCommand { get; set; }
        public BookingSingelton BookingSingeltonVM { get; set; }

        public ForsideVM()
        {
            BookingFacade.GetBooking();
            ForsideOC = new ObservableCollection<Booking>();
            NavigateKursusBookingCommand = new RelayCommand(NavigateToKursusBooking);
            NavigatePersonsøgningCommand = new RelayCommand(NavigateToPersonsøgning);
            NavigateToTilføjCommand = new RelayCommand(NavigateToTilføj);
            BookingSingeltonVM= BookingSingelton.Intance;
            OCAdd();
            



        }

        public void NavigateToPersonsøgning()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(PersonSøgning));
        }

        public void NavigateToKursusBooking()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(KursusBooking));
        }

        public void NavigateToTilføj()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(TilføjDeltagerTilKursus));
        }


        public  void OCAdd()
        {
            
            foreach (var booking in BookingSingeltonVM.SingletonOCBooking)
            {
                ForsideOC.Add(booking);
            }
        }

        #region PropertyChangedHelper

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

}


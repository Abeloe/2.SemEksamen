using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Email;
using Windows.ApplicationModel.VoiceCommands;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Eksamen2Semester.Annotations;
using Eksamen2Semester.Converter;
using Eksamen2Semester.Facade;
using Eksamen2Semester.Model;
using Eksamen2Semester.Singletonz;
using Eksamen2Semester.View;
using Eventmaker.Common;

namespace Eksamen2Semester.VM
{
    public class KursusOprettelseVM : INotifyPropertyChanged
    {

        public RelayCommand NavigateForsideCommand { get; set; }
        public RelayCommand BookCommand { get; set; }
        public RelayCommand TilføjCommand { get; set; }
        private DateTimeOffset _date;
        private string _tempLokaleString;
        private Lokation _lokationKo;
        private string _tempBookDeltagerAntal;
        private string _tempNavn;
        private string _tempTelefonNr;
        private string _tempEmail;
        public List<string> KursusNavnListe { get; set; }
        public ObservableCollection<Lokale> LokaleOC { get; set; }
        public List<Lokale> LokaleListe { get; set; }
        public List<Lokation> LokationListe { get; set; }
        public KursusOCSingleton KursusOcSingleton { get; set; }
        public LokalerKatalogSingleton LokalerKatalogSingletonVM { get; set; }





        public Lokation LokationKO
        {
            get { return _lokationKo; }
            set
            {
                LokationString = value.Adresse;
                LedigeLokaler();
                _lokationKo = value;
            }
        }


        public string LokationString { get; set; }
        //til book
        public string BookName { get; set; }
        public Lokale BookLokale { get; set; }
        public DateTimeOffset BookDateTime { get; set; }

        public string TempBookDeltagerAntal
        {
            get { return _tempBookDeltagerAntal; }
            set
            {
                BookDeltagerAntal = value;
                _tempBookDeltagerAntal = value;
            }
        }

        public string BookDeltagerAntal { get; set; }
        //Person, tilføj deltager til kursus
        public string Navn { get; set; }

        public string tempNavn
        {
            get { return _tempNavn; }
            set
            {
                Navn = value;
                _tempNavn = value;
            }
        }

        public string TelefonNr { get; set; }

        public string tempTelefonNr
        {
            get { return _tempTelefonNr; }
            set
            {
                TelefonNr = value;
                _tempTelefonNr = value;
            }
        }

        public string Email { get; set; }

        public string tempEmail
        {
            get { return _tempEmail; }
            set
            {
                Email = value;
                _tempEmail = value;
            }
        }

        public Kursus SelectedKursus { get; set; }

        public KursusOprettelseVM()
        {
            KursusFacade.GetKursus();
          
            _date = new DateTimeOffset(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, 0, new TimeSpan());

            BookDateTime = _date;
            KursusNavnListe = new List<string>();
            LokaleListe = new List<Lokale>();
            LokationListe = new List<Lokation>();
            LokaleOC = new ObservableCollection<Lokale>();
            SelectedKursus = new Kursus();
            KursusOcSingleton = KursusOCSingleton.Intance;
            LokalerKatalogSingletonVM = LokalerKatalogSingleton.LokalerKatalogSingeltons;





            #region TestData
            KursusOCSingleton.Intance.SingletonOCKursus.Add(new Kursus(1, "ASD6", "SWD", new List<Deltager>()));
            KursusOCSingleton.Intance.SingletonOCKursus.Add(new Kursus(2, "sss", "Nerd", new List<Deltager>()));
            KursusOCSingleton.Intance.SingletonOCKursus.Add(new Kursus(3, "Westeros", "Dragons", new List<Deltager>()));

            LokaleListe.Add(new Lokale("Lysallen 11", 2));
            LokaleListe.Add(new Lokale("Lysallen 11", 4));
            LokaleListe.Add(new Lokale("Vestegenen 14", 4));

            LokationListe.Add(new Lokation("Lysallen 11", "Roskilde", "DK"));
            LokationListe.Add(new Lokation("Vestegenen 14", "Nordborg", "DK"));
            #endregion

            #region metoder

            KursusNavnToList();
            NavigateForsideCommand = new RelayCommand(NavigateToForside);
            BookCommand = new RelayCommand(NewBooking);
            TilføjCommand = new RelayCommand(TilføjDeltagerTilKursus);
            LedigeLokaler();



            #endregion
        }

     
        public void NavigateToForside()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Forside));

        }
        public void KursusNavnToList()
        {

            foreach (var kursus in KursusOcSingleton.SingletonOCKursus)
            {
                KursusNavnListe.Add(kursus.Navn);
            }
        }
        //Mads
        public void LedigeLokaler()
        {

            if (LokationString == null)
            {
                return;
            }

            List<Lokale> tempList = new List<Lokale>();
            tempList = LokaleListe.FindAll((t) => t.Adresse.ToLower() == LokationString.ToLower());

            LokaleOC.Clear();

            foreach (Lokale lokale in tempList)
            {
                LokaleOC.Add(lokale);
            }

        }
        //Mads
       public void NewBooking()
       {

           try
           {
                if (Int32.Parse(BookDeltagerAntal) <=2)
               {
                   throw new ArgumentException("der skal være flere end 2 deltagere");
               }
                
                BookingSingelton.Intance.SingletonOCBooking.Add(new Booking(BookName, BookLokale, BookDateTime.Date, BookDeltagerAntal, LokationKO));

               
           }
           catch (Exception e)
           {

               new MessageDialog(e.Message).ShowAsync();
           }
 
          
             
        

        }

       public void TilføjDeltagerTilKursus()
       {
           try
           {
                Deltager deltager = new Deltager(Navn, TelefonNr, Email);
                foreach (var kursus in from t in KursusOcSingleton.SingletonOCKursus
                                       where t.Navn == SelectedKursus.Navn
                                       select t)
                {
                    kursus.DeltagerListe=new List<Deltager>();
                    kursus.DeltagerListe.Add(deltager);
                }

            }
            catch (NullReferenceException)
            {

                new MessageDialog("Husk at vælg et kursus :)").ShowAsync();
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

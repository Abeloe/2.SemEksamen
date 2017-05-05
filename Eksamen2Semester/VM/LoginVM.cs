using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Eksamen2Semester.Annotations;
using Eksamen2Semester.Facade;
using Eksamen2Semester.Model;
using Eksamen2Semester.View;
using Eventmaker.Common;
using Eksamen2Semester.Singletonz;

namespace Eksamen2Semester.VM
{
    public class LoginVM : INotifyPropertyChanged
    {
        private string _tempNavn;
        private string _tempKode;
        public string Kode { get; set; }
        public string Navn { get; set; }

        public string TempNavn
        {
            get { return _tempNavn; }
            set
            {
                Navn = value;
                _tempNavn = value;

            }
        }

        public string TempKode
        {
            get { return _tempKode; }
            set
            {
                Kode = value;
                _tempKode = value;

            }
        }

        public List<LoginBruger> LoginListeVM { get; set; }
        public RelayCommand LoginCommand { get; set; }
        public LoginKatalogSingleton LoginKatalogSingletonVM { get; set; }

       public LoginVM()
       {

           LoginFacade.GetLogin();
            LoginKatalogSingletonVM = LoginKatalogSingleton.LoginKatalogSingeltons;
            LoginListeVM = new List<LoginBruger>();
           
            // LoginListeVM.Add(new LoginBruger("Mads", "123"));

            LoginCommand = new RelayCommand(LoginCheck);

        }

       
       
        public void  LoginCheck()
        {
            foreach (var loginBruger in LoginKatalogSingletonVM.Logins)
            {
                LoginListeVM.Add(loginBruger);
            }

            Frame rootFrame = Window.Current.Content as Frame;
            var  bruger = LoginListeVM.FirstOrDefault(x => x.BrugerNavn == Navn && x.KodeOrd == Kode);
            if (bruger != null)
            {
               rootFrame.Navigate(typeof(Forside));

            }
            else
            {
                new MessageDialog("Du har tastet forkert brugernavn eller kodeord", "Hovsa").ShowAsync();
            }
            
        }
        #region PropertyChangedHelper

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    #endregion

}

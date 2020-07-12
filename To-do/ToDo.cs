using System;
using System.ComponentModel;
using FluentValidation;

namespace To_do
{
    public class ToDo : INotifyPropertyChanged
    {
        public int ID { get; set; }

        private string _opis;
        public string Opis
        {
            get => _opis;
            set
            {
                _opis = value;
            }
        }

        private DateTime _vreme = DateTime.Now;
        public DateTime Vreme
        {
            get => _vreme;
            set
            {
                _vreme = value;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public ToDo() { }
        //tyui
    }
    
}

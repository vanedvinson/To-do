using System;
using System.ComponentModel;
using FluentValidation;

namespace To_do
{
    public class ToDo : INotifyPropertyChanged
    {
        public int ID { get; set; }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
            }
        }

        private DateTime _time = DateTime.Now;
        public DateTime Time
        {
            get => _time;
            set
            {
                _time = value;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public ToDo() { }
        //tyui
    }
    
}

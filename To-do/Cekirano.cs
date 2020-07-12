using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_do
{
    public class Cekirano
    {
        public int ID { get; set; }

        private DateTime _vremeKraja;
        public DateTime VremeKraja
        {
            get => _vremeKraja;
            set
            {
                _vremeKraja = value;
            }
        }
        private string _opisCekirano;
        public string OpisCekirano
        {
            get => _opisCekirano;
            set
            {
                _opisCekirano = value;
            }
        }

        private string _status;
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
            }
        }

        public Cekirano() { }
        public Cekirano(DateTime v, string o, string s)
        {
            _vremeKraja = v;
            _opisCekirano = o;
            _status = s;
        }
    }
}

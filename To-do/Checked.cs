using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_do
{
    public class Checked
    {
        public int ID { get; set; }

        private DateTime _dueDate;
        public DateTime DueDate
        {
            get => _dueDate;
            set
            {
                _dueDate = value;
            }
        }
        private string _checkedDescription;
        public string CheckedDescription
        {
            get => _checkedDescription;
            set
            {
                _checkedDescription = value;
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

        public Checked() { }
        public Checked(DateTime v, string o, string s)
        {
            _dueDate = v;
            _checkedDescription = o;
            _status = s;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.ComponentModel;

namespace AmenixEditer.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private int _column = 1;
        public int Column
        {
            get { return _column; }
            set
            {
                _column = value;
                NotifyPropertyChanged(nameof(Column));
            }
        }

        private int _line = 1;
        public int Line
        {
            get { return _line; }
            set
            {
                _line = value;
                NotifyPropertyChanged(nameof(Line));
            }
        }


    }
}

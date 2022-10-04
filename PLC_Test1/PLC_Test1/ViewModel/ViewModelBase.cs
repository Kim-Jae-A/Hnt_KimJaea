using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLC_Test1.ViewModel
{
    class ViewModelBase : INotifyPropertyChanged
    {
        public void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        int _isConnected = 1;
        public int IsConnected
        {
            get
            {
                return _isConnected;
            }
            set
            {
                if (_isConnected == value)
                    return;
                _isConnected = value;
                OnPropertyChanged("IsConnected");
            }
        }

        int _number;
        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                if (_number == value)
                    return;
                _number = value;
                OnPropertyChanged("Number");
            }
        }
        int _num;
        public int Num
        {
            get
            {
                return _num;
            }
            set
            {
                if (_num == value)
                    return;
                _num = value;
                OnPropertyChanged("Num");
            }
        }

        /*        string _str1;
                public string Str1
                {
                    get
                    {
                        return _str1;
                    }
                    set
                    {
                        if (_str1 == value)
                            return;
                        _str1 = value;
                        OnPropertyChanged("Str1");
                    }
                }*/

        string _str2;
        public string Str2
        {
            get
            {
                return _str2;
            }
            set
            {
                if (_str2 == value)
                    return;
                _str2 = value;
                OnPropertyChanged("Str2");
            }
        }

        string _szDevice;
        public string SzDevice
        {
            get
            {
                return _szDevice;
            }
            set
            {
                if (_szDevice == value)
                    return;
                _szDevice = value;
                OnPropertyChanged("SzDevice");
            }
        }
    }
}

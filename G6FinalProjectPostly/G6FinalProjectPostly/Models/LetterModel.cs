using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace G6FinalProjectPostly.Models
{
    public class LetterModel : INotifyPropertyChanged
    {
        int _id { get; set; }
        string _to { get; set; }
        string _date { get; set; }
        string _subject { get; set; }

        string _letter { get; set; }
        bool _isRead { get; set; }

        public int id { get { return _id; } set { _id = value; OnPropertyChanged(nameof(id)); } }

        public string to { get { return _to; } set { _to = value; OnPropertyChanged(nameof(to)); } }

        public string date { get { return _date; } set { _date = value; OnPropertyChanged(nameof(date)); } }
        public string subject { get { return _subject; } set { _subject = value; OnPropertyChanged(nameof(subject)); } }

        public string letter { get { return _letter; } set { _letter = value; OnPropertyChanged(nameof(letter)); } }
        public bool isRead { get { return _isRead; } set { _isRead = value; OnPropertyChanged(nameof(isRead)); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

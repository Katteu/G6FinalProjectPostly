using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace G6FinalProjectPostly.Models
{
    public static class DataRepository
    {
        public static ObservableCollection<LetterModel> letterList = new ObservableCollection<LetterModel>();
        public static ObservableCollection<LetterModel> staticList = new ObservableCollection<LetterModel>();
    }
}

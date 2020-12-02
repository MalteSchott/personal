using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_example
{
    public class Presenter : ObservableObject
    {
        private readonly TextConverter textConverter
            = new TextConverter(s => s.ToUpper());
        private string someText;
        private readonly ObservableCollection<string> history
            = new ObservableCollection<string>();

        public string SomeText
        {
            get { return someText; }
            set
            {
                someText = value;
                RaisePropertyChangedEvent("SomeText");
            }
        }

        public IEnumerable<string> History
        {
            get { return history; }
        }

        public ICommand ConvertTextCommand
        {
            get { return new DelegateCommand(ConvertText); }
        }

        private void ConvertText()
        {
            if (string.IsNullOrWhiteSpace(SomeText)) return;
            AddToHistory(textConverter.ConvertText(SomeText));
            SomeText = string.Empty;
        }

        private void AddToHistory(string item)
        {
            if (!history.Contains(item))
                history.Add(item);
        }
    }
}

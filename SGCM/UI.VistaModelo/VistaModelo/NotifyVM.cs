using System.ComponentModel;

namespace UI.Desktop.VistaModelo
{
    public abstract class NotifyVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}


//public event PropertyChangedEventHandler PropertyChanged;
//protected void RaisePropertyChanged(string propertyName)
//{
//    var handler = PropertyChanged;

//    if (handler != null)
//    {
//        handler(this, new PropertyChangedEventArgs(propertyName));
//    }
//}

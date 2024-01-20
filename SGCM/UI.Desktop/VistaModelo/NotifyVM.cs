using System.ComponentModel;

namespace Sgcm.UI.Desktop.VistaModelo
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
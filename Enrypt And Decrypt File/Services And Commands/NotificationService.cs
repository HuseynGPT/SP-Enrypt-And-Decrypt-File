using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Enrypt_And_Decrypt_File;

public abstract class NotificationService : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;


    public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
                => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));




}

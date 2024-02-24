using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Enrypt_And_Decrypt_File.ViewModels;

public class MainWindowViewModel:NotificationService
{
    private string? filePath;

    public string? FilePath { get => filePath; set { filePath = value;OnPropertyChanged(); } }


    public bool IsEncrypted { get; set; } = false;
    public bool IsDecrypted { get; set; } = true;
    public bool IsEncyrptRadioButtonChecked { get; set; }
    public bool IsDecyrptRadioButtonChecked { get; set; }
    public ICommand? SelectFileCommand { get; set; }
    public ICommand? StartCommand { get; set; }




    public MainWindowViewModel()
    {
        SelectFileCommand = new RelayCommand(SelectFile);
        StartCommand = new RelayCommand(Start, CanStart);
    }

    private bool CanStart(object? obj)
    {
        if (FilePath == null)
        {
            return false;
        }
        return true;
    }

    private void Start(object? obj)
    {
        if (FilePath != string.Empty)
        {

            //Encrypt
            if (IsEncyrptRadioButtonChecked == true && IsDecrypted == true)
            {
                string textFormFile = File.ReadAllText(FilePath!);
                textFormFile = Convert.ToBase64String(Encoding.Unicode.GetBytes(textFormFile));
                File.WriteAllText(FilePath!, textFormFile);
                IsEncrypted = true;
                

            }

            // decrypt
            else if (IsDecyrptRadioButtonChecked == true && IsEncrypted == true)
            {
                string textFormFile = File.ReadAllText(FilePath!);
                textFormFile = Encoding.Unicode.GetString(Convert.FromBase64String(textFormFile));
                File.WriteAllText(FilePath!, textFormFile);
                IsEncrypted = false;
                IsDecrypted = true;
            }
        }
        else
            MessageBox.Show("You mmust select file");

    }

    private void SelectFile(object? obj)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Title = "Choose file";
        openFileDialog.Filter = "All Files(*.*)|*.*";

        if (openFileDialog.ShowDialog() == true)
        {
            FilePath = openFileDialog.FileName;
        }
        else
        {
            MessageBox.Show("File cannot choose");
        }
    }
}

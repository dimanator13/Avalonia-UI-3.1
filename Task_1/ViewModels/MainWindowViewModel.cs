using System;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Task_1.Models;

namespace Task_1.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly UserProfile _userProfile = new UserProfile();
    private string _resultText = "";
    
    public ICommand CreateGreetingCommand { get; }
    public ICommand ClearCommand { get; }
    public ICommand ExitCommand { get; }

    public MainWindowViewModel()
    {
        CreateGreetingCommand = new RelayCommand(CreateGreeting);
        ClearCommand = new RelayCommand(Clear);
        ExitCommand = new RelayCommand(Exit);
    }

    public string Name
    {
        get => _userProfile.Name;
        set
        {
            if (_userProfile.Name == value)
            {
                return;
            }

            _userProfile.Name = value;
            OnPropertyChanged();
        }
    }
    
    public string Phone
    {
        get => _userProfile.Phone;
        set
        {
            if (_userProfile.Phone == value)
            {
                return;
            }

            _userProfile.Phone = value;
            OnPropertyChanged();
        }
    }
    
    public string Email
    {
        get => _userProfile.Email;
        set
        {
            if (_userProfile.Email == value)
            {
                return;
            }

            _userProfile.Email = value;
            OnPropertyChanged();
        }
    }

    public string ResultText
    {
        get => _resultText;
        set => SetProperty(ref _resultText, value);
    }

    public void CreateGreeting()
    {
        var name = string.IsNullOrWhiteSpace(Name) ? "None" : Name;
        var phone = string.IsNullOrWhiteSpace(Phone) ? "None" : Phone;
        var email = string.IsNullOrWhiteSpace(Email) ? "None" : Email;

        ResultText = $"Hi, {name}! Your phone: {phone}. Your email: {email}";
    }

    public void Clear()
    {
        Name = "";
        Phone = "";
        Email = "";
        ResultText = "";
    }

    public void Exit()
    {
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.Shutdown();
        }
    }
}
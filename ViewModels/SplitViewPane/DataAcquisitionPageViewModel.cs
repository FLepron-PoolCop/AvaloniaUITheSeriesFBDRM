using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AvaloniaUITheSeriesFBDRM.ViewModels.SplitViewPane;

public partial class DataAcquisitionPageViewModel : ViewModelBase { 

    [ObservableProperty]
    private ObservableCollection<Measurement>? _measurements;

    [RelayCommand]
    private void AddMeasurement()
    {
        Measurements?.Add(new Measurement { MeasurementType = "Nouvelle Mesure", Value = 0.0, Timestamp = DateTime.Now });
    }
}

public class Measurement
{
    public string MeasurementType { get; set; } = "" ;
    public double Value { get; set; }
    public DateTime Timestamp { get; set; }
}
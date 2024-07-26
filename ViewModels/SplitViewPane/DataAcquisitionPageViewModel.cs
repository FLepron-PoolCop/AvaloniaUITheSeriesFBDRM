using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AvaloniaUITheSeriesFBDRM.ViewModels.SplitViewPane;

public partial class DataAcquisitionPageViewModel : ViewModelBase { 

    [ObservableProperty]
    private ObservableCollection<Measurement>? _measurements;

    public DataAcquisitionPageViewModel()
    {
        Measurements = new ObservableCollection<Measurement>
        {
            new Measurement { MeasurementType = "Measurement", Value = 23.5, Timestamp = DateTime.Now.AddHours(-1) },
            new Measurement { MeasurementType = "Humidity", Value = 60.2, Timestamp = DateTime.Now.AddHours(-2) },
            new Measurement { MeasurementType = "Pression", Value = 1013.1, Timestamp = DateTime.Now }
        };
    }

    [RelayCommand]
    private void AddMeasurement()
    {
        Measurements?.Add(new Measurement { MeasurementType = "pH", Value = 7.2, Timestamp = DateTime.Now });
    }
}

public class Measurement
{
    public string MeasurementType { get; set; } = "" ;
    public double Value { get; set; }
    public DateTime Timestamp { get; set; }
}
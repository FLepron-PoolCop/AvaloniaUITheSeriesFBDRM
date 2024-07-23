using System;
using Avalonia.Controls;
using System.Collections.ObjectModel;
using AvaloniaUITheSeriesFBDRM.ViewModels.SplitViewPane ;

namespace AvaloniaUITheSeriesFBDRM.Views;


public partial class DataAcquisitionPageView : UserControl
{
    public DataAcquisitionPageView()
    {
        InitializeComponent();

        DataContext = new DataAcquisitionPageViewModel
        {
            Measurements = new ObservableCollection<Measurement>
            {
                new Measurement { MeasurementType = "Température", Value = 23.5, Timestamp = DateTime.Now.AddHours(-1) },
                new Measurement { MeasurementType = "Humidité", Value = 60.2, Timestamp = DateTime.Now.AddHours(-2) },
                new Measurement { MeasurementType = "Pression", Value = 1013.1, Timestamp = DateTime.Now }
            }
        };
    }

    // private void InitializeComponent()
    // {
    //     AvaloniaXamlLoader.Load(this);
    // }
}
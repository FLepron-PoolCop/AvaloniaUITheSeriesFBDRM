using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.ObjectModel;
using AvaloniaUITheSeriesFBDRM.ViewModels.SplitViewPane ;

namespace AvaloniaUITheSeriesFBDRM.Views;


public partial class DataAcquisitionPageView : UserControl
{
    public DataAcquisitionPageView()
    {
        // DataContext = new DataAcquisitionPageViewModel
        // {
        //     Measurements = new ObservableCollection<Measurement>
        //     {
        //         new Measurement { MeasurementType = "Measurement", Value = 23.5, Timestamp = DateTime.Now.AddHours(-1) },
        //         new Measurement { MeasurementType = "Humidity", Value = 60.2, Timestamp = DateTime.Now.AddHours(-2) },
        //         new Measurement { MeasurementType = "Pression", Value = 1013.1, Timestamp = DateTime.Now }
        //     }
        // };

        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
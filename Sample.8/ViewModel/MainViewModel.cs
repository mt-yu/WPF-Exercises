using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sample._8.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {

        }

        public ISeries[] Series { get; set; } =
            {
                new LineSeries<double>
                {
                    Values = new double[] { 4,5,3,4,3,7,5,7,6 },
                    Fill = new SolidColorPaint(new SKColor(0xff, 0x80, 0x64, 90)),
                    Stroke = new SolidColorPaint(new SKColor(0xff, 0x80, 0x64), 2),
                    GeometryFill = null,
                    GeometryStroke = null
                },
        };

        public Axis[] XAxes { get; set; } =
        {
            new Axis
            {
                MinLimit = 0,
                MaxLimit = 8,
                IsVisible = false,
            }
        };

        public Axis[] YAxes { get; set; } =
        {
            new Axis
            {
                IsVisible = false,
            }
        };

        public ISeries[] Series1 { get; set; } =
    {
                new LineSeries<double>
                {
                    Values = new double[] { 4,6,5,7,1,8,5,2,7 },
                    Fill = new SolidColorPaint(new SKColor(0xfe, 0xbc, 0x4d, 90)),
                    Stroke = new SolidColorPaint(new SKColor(0xfe, 0xbc, 0x4d), 2),
                    GeometryFill = null,
                    GeometryStroke = null
                },
        };

        public Axis[] XAxes1 { get; set; } =
        {
            new Axis
            {
                MinLimit = 0,
                MaxLimit = 8,
                IsVisible = false,
            }
        };

        public Axis[] YAxes1 { get; set; } =
        {
            new Axis
            {
                MinLimit = 0,
                IsVisible = false,
            }
        };

        public ISeries[] Series2 { get; set; } =
    {
                new LineSeries<double>
                {
                    Values = new double[] { 7,8,4,7,6,7,5,7,6 },
                    Fill = new SolidColorPaint(new SKColor(0x78, 0xc7, 0x9c, 90)),
                    Stroke = new SolidColorPaint(new SKColor(0x78, 0xc7, 0x9c), 2),
                    GeometryFill = null,
                    GeometryStroke = null
                },
        };

        public Axis[] XAxes2 { get; set; } =
        {
            new Axis
            {
                MinLimit = 0,
                MaxLimit = 8,
                IsVisible = false,
            }
        };

        public Axis[] YAxes2 { get; set; } =
        {
            new Axis
            {
                MinLimit = 0,
                MaxLimit = 15,
                IsVisible = false,
            }
        };

        public ISeries[] Series3 { get; set; } =
            {
                new LineSeries<double>
                {
                    Values = new double[] { 4,5,3,4,3,7,5,7,6 },
                    Fill = new SolidColorPaint(new SKColor(0x53, 0xbd, 0xe1, 90)),
                    Stroke = new SolidColorPaint(new SKColor(0x53, 0xbd, 0xe1), 2),
                    GeometryFill = null,
                    GeometryStroke = null
                },
        };

        public Axis[] XAxes3 { get; set; } =
        {
            new Axis
            {
                MinLimit = 0,
                MaxLimit = 8,
                IsVisible = false,
            }
        };

        public Axis[] YAxes3 { get; set; } =
        {
            new Axis
            {
                IsVisible = false,
            }
        };

        public ISeries[] Series4 { get; set; } =
    {
                new LineSeries<double>
                {
                    Values = new double[] { 19, 32, 25, 31, 1, 32, 19, 28, 25, 30, 29, 35},
                    LineSmoothness = 0,
                    Fill = new SolidColorPaint(new SKColor(0x02, 0xae, 0xcf, 40)),
                    Stroke = new SolidColorPaint(new SKColor(0x02, 0xae, 0xcf), 2),
                    GeometryFill = null,
                    GeometryStroke = null
                },
        };

        public Axis[] XAxes4 { get; set; } =
        {
            new Axis
            {
                MinLimit = 0,
                MaxLimit = 11,
                TextSize = 10,
                ShowSeparatorLines = true,
                Labels = new string[]  { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sept", "Oct", "Nov", "Dec" },
                LabelsPaint = new SolidColorPaint { Color = new SKColor(0xb3, 0xb5, 0xb7) },
            }
        };

        public Axis[] YAxes4 { get; set; } =
        {
            new Axis
            {
                MinLimit = 0,
                TextSize = 10,
                ShowSeparatorLines = false,
                CustomSeparators = new double[] { 10, 20, 30, 40 },
                LabelsPaint = new SolidColorPaint
                {
                    Color = new SKColor(0xb3, 0xb5, 0xb7),
                    FontFamily = "Times New Roman",
                    SKFontStyle = new SKFontStyle(SKFontStyleWeight.ExtraBold, SKFontStyleWidth.Normal, SKFontStyleSlant.Italic)
                },
            }
        };

        public DrawMarginFrame DrawMarginFrame4 => new()
        {
            Fill = new SolidColorPaint(new SKColor(0xf5, 0xf7, 0xf9)),
        };

        public ObservableCollection<ISeries> Series5 { get; set; } = new ObservableCollection<ISeries>
            {
                new PieSeries<ObservableValue> { Values = new[] { new ObservableValue(4) }, Name="Hover", InnerRadius=15, DataLabelsSize = 5,  MiniatureShapeSize = 8},
                new PieSeries<ObservableValue> { Values = new[] { new ObservableValue(2) }, Name="Click & Submit", InnerRadius=15, DataLabelsSize = 5,MiniatureShapeSize = 8 },
                new PieSeries<ObservableValue> { Values = new[] { new ObservableValue(11) }, Name="Impression", InnerRadius=15, DataLabelsSize = 5, MiniatureShapeSize = 8},
            };
    }
}
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Sample._3.Models;
using SkiaSharp;
using System.Collections.ObjectModel;

namespace Sample._3.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            MyTasks = new ObservableCollection<TaskModel>()
            {
                new TaskModel() {IsChecked = true, Content=$@"Sign contract for ""What are conference organizers afraid of?"""},
                new TaskModel() {IsChecked = false, Content=$@"Lines From Grat Russian Literature? Or E-mails From My Boss?"},
                new TaskModel() {IsChecked = false, Content=$@"Flooded: One year later, assessing what was lost and what was found when a ravaging rain swept through metro Detroit"},
                new TaskModel() {IsChecked = false, Content=$@"Create 4 Invisible User Experiences you Never Knew About"},
                new TaskModel() {IsChecked = false, Content=$@"Read ""Following makes Medium better"""},
                new TaskModel() {IsChecked = false, Content=$@"Unfollow 5 enemies from twitter"},
            };

            Employees = new ObservableCollection<EmployeeModel>()
            {
                new EmployeeModel() {Id = 1, Name = "Andrew", Salary = "$1,250", Country = "USA"},
                new EmployeeModel() {Id = 2, Name = "Andrea", Salary = "$1,550", Country = "USA"},
                new EmployeeModel() {Id = 3, Name = "Michael", Salary = "$1,650", Country = "USA"},
                new EmployeeModel() {Id = 4, Name = "Meredith", Salary = "$1,750", Country = "USA"},
                new EmployeeModel() {Id = 5, Name = "Laura", Salary = "$1,850", Country = "USA"},
                new EmployeeModel() {Id = 6, Name = "Robert", Salary = "$1,950", Country = "USA"},
                new EmployeeModel() {Id = 7, Name = "Laura", Salary = "$1,850", Country = "USA"},
            };
        }

        private ObservableCollection<EmployeeModel> employees;

        public ObservableCollection<EmployeeModel> Employees
        {
            get { return employees; }
            set { employees = value; }
        }


        private ObservableCollection<TaskModel> myTasks;

        public ObservableCollection<TaskModel> MyTasks
        {
            get { return myTasks; }
            set { myTasks = value; OnPropertyChanged(); }
        }

        public ISeries[] Series { get; set; } =
        {
            new LineSeries<double>
            {
                Values = new double[] { 10, 18, 2, 15, 20, 16, 36 },
                Fill = null,
                LineSmoothness = 0,
                Stroke = new SolidColorPaint { Color = SKColors.White, StrokeThickness = 3 },
                GeometryStroke = new SolidColorPaint { Color = SKColors.White, StrokeThickness = 3 },
            },
        };

        public Axis[] XAxes { get; set; } =
        {
            new Axis
            {
                Labels = new string[] { "M", "T", "W", "T ", "F", "S ", "S" },
                LabelsPaint = new SolidColorPaint { Color = SKColors.White },
            }
        };

        public Axis[] YAxes { get; set; } =
        {
            new Axis
            {
                ShowSeparatorLines = false,
                CustomSeparators = new double[] { 0, 10, 20, 30, 40 },
                LabelsPaint = new SolidColorPaint
                {
                    Color = SKColors.White,
                    FontFamily = "Times New Roman",
                    SKFontStyle = new SKFontStyle(SKFontStyleWeight.ExtraBold, SKFontStyleWidth.Normal, SKFontStyleSlant.Italic)
                },
            }
        };

        public ISeries[] Series2 { get; set; } =
        {
            new ColumnSeries<double>
            {
                Values = new double[] { 450, 400, 250, 700, 480, 400, 300, 400, 500, 580, 680, 790 },
                Fill = new SolidColorPaint { Color = SKColors.White },
            },
        };

        public Axis[] XAxes2 { get; set; } =
        {
            new Axis
            {
                Labels = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sept", "Oct", "Nov", "Dec" },
                LabelsPaint = new SolidColorPaint { Color = SKColors.White, SKFontStyle = new SKFontStyle(SKFontStyleWeight.Light, SKFontStyleWidth.Normal, SKFontStyleSlant.Italic) },
            }
        };

        public Axis[] YAxes2 { get; set; } =
        {
            new Axis
            {
                ShowSeparatorLines = false,
                CustomSeparators = new double[] { 0, 200, 400, 600, 800 },
                LabelsPaint = new SolidColorPaint
                {
                    Color = SKColors.White,
                    FontFamily = "Times New Roman",
                    SKFontStyle = new SKFontStyle(SKFontStyleWeight.ExtraBold, SKFontStyleWidth.Normal, SKFontStyleSlant.Italic)
                },
            }
        };

        public ISeries[] Series3 { get; set; } =
        {
            new LineSeries<double>
            {
                Values = new double[] { 200, 700, 400, 300, 280, 260, 250 },
                Fill = null,
                LineSmoothness = 0,
                Stroke = new SolidColorPaint { Color = SKColors.White, StrokeThickness = 3 },
                GeometryStroke = new SolidColorPaint { Color = SKColors.White, StrokeThickness = 3 },
            },
        };

        public Axis[] XAxes3 { get; set; } =
        {
            new Axis
            {
                Labels = new string[] { "12am", "3pm", "6pm", "9pm", "12pm", "3am", "6am", "9am"},
                LabelsPaint = new SolidColorPaint { Color = SKColors.White, SKFontStyle = new SKFontStyle(SKFontStyleWeight.Light, SKFontStyleWidth.Normal, SKFontStyleSlant.Italic) },
            }
        };

        public Axis[] YAxes3 { get; set; } =
        {
            new Axis
            {
                ShowSeparatorLines = false,
                CustomSeparators = new double[] { 0, 200, 400, 600, 800 },
                LabelsPaint = new SolidColorPaint
                {
                    Color = SKColors.White,
                    FontFamily = "Times New Roman",
                    SKFontStyle = new SKFontStyle(SKFontStyleWeight.ExtraBold, SKFontStyleWidth.Normal, SKFontStyleSlant.Italic)
                },
            }
        };
    }
}
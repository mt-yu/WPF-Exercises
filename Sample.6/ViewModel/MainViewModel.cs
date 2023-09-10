using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using Sample._6.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Sample._6.ViewModel
{
    public class MainViewModel : ObservableObject
    {

        public MainViewModel()
        {
            MetroInfos = new ObservableCollection<MetroModel>();
            kinds = new List<TransitionEffectKind>
            {
                TransitionEffectKind.ExpandIn,
                TransitionEffectKind.FadeIn,
                TransitionEffectKind.SlideInFromLeft,
                TransitionEffectKind.SlideInFromTop,
                TransitionEffectKind.SlideInFromRight,
                TransitionEffectKind.SlideInFromBottom
            };

            #region 颜色

            colors = new List<string>
            {
                "#FF8C69",
                "#FF8247",
                "#FF7256",
                "#FF6347",
                "#FFA07A",
                "#FF82AB",
                "#FF7F00",
                "#FF69B4",
                "#FFA500",
                "#FF83FA",
                "#FF7F24",
                "#FF6A6A",
                "#FFA54F",
                "#FF8C00",
                "#FF7F50",
                "#FF6EB4",
                "#00CED1",
                "#00C5CD",
                "#008B8B",
                "#00688B",
                "#00E5EE",
                "#00CD00",
                "#009ACD",
                "#00868B",
                "#00EE00",
                "#00CD66",
                "#00B2EE",
                "#008B00",
                "#00EE76",
                "#00CDCD",
                "#00BFFF",
                "#008B45",
                "#87CEFF",
                "#858585",
                "#838B83",
                "#7FFF00",
                "#7D7D7D",
                "#87CEFA",
                "#848484",
                "#836FFF",
                "#7F7F7F",
                "#7D26CD",
                "#87CEEB",
                "#8470FF",
                "#828282",
                "#7EC0EE",
                "#7CFC00",
                "#878787",
                "#838B8B",
                "#7FFFD4",
                "#7D9EC0",
                "#7CCD7C"
            };
            #endregion

            #region 图标
            icons = new List<PackIconKind>()
            {
                PackIconKind.Twitter,
                PackIconKind.Twitch,
                PackIconKind.Trello,
                PackIconKind.Trophy,
                PackIconKind.TrophyAward,
                PackIconKind.Facebook,
                PackIconKind.MicrosoftAzure,
                PackIconKind.MicrosoftBing,
                PackIconKind.MicrosoftEdge,
                PackIconKind.MicrosoftInternetExplorer,
                PackIconKind.MicrosoftOffice,
                PackIconKind.MicrosoftOnedrive,
                PackIconKind.MicrosoftOutlook,
                PackIconKind.MicrosoftPowerpoint,
                PackIconKind.MicrosoftVisualStudio,
                PackIconKind.MicrosoftWindows,
                PackIconKind.MicrosoftWord,
                PackIconKind.MicrosoftXbox,
                PackIconKind.MicrosoftXboxControllerBatteryAlert,
                PackIconKind.MicrosoftXboxControllerBatteryEmpty,
                PackIconKind.MicrosoftXboxControllerBatteryFull,
                PackIconKind.MicrosoftXboxControllerBatteryLow,
                PackIconKind.MicrosoftXboxControllerBatteryMedium,
                PackIconKind.MicrosoftXboxControllerBatteryUnknown,
                PackIconKind.MicrosoftXboxControllerMenu,
                PackIconKind.MicrosoftXboxControllerOff,
                PackIconKind.MicrosoftXboxControllerView,
                PackIconKind.Microsoft,
                PackIconKind.MicroSd,
                PackIconKind.Microphone,
                PackIconKind.MicrophoneOff,
            };
            #endregion
            RefreshCommand = new RelayCommand(Refresh);
            Refresh();
        }

        private async void Refresh()
        {
            MetroInfos.Clear();
            for (int i = 0; i < 60; i++)
            {
                var icon = icons[new Random().Next(0, 31)];
                MetroInfos.Add(new MetroModel()
                {
                    Name = $"{icon}",
                    Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colors[new Random().Next(0, 51)])),
                    Width = new Random().Next(0, 8) == 3 ? 296 : 100,
                    Height = 100,
                    Effact = new TransitionEffect()
                    {
                        Kind = kinds[new Random().Next(2, 6)],
                        Duration = new TimeSpan(0, 0, 0, 0, 900)
                    },
                    IconKind = icon,
                });
                await Task.Delay(10);
            }
        }
        public RelayCommand RefreshCommand { get; private set; }

        public List<TransitionEffectKind> kinds;

        public List<string> colors;

        public List<PackIconKind> icons;

        public ObservableCollection<MetroModel> metroInfos;

        public ObservableCollection<MetroModel> MetroInfos
        {
            get => metroInfos;
            set => SetProperty(ref metroInfos, value);
        }

        private string _title = "Sample.6";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        
    }
}

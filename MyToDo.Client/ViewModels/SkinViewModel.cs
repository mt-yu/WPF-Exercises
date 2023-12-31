﻿using MaterialDesignColors;
using MaterialDesignColors.ColorManipulation;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MyToDo.Client.ViewModels
{
    public class SkinViewModel : BindableBase
    {
        private bool isDarkTheme;
        private readonly PaletteHelper paletteHelper = new PaletteHelper();

        public SkinViewModel()
        {
            ChangeHueCommand = new DelegateCommand<object>(ChangeHue);
        }

        private void ChangeHue(object obj)
        {
            var hue = (Color)obj!;

            ITheme theme = paletteHelper.GetTheme();

            theme.PrimaryLight = new ColorPair(hue.Lighten());
            theme.PrimaryMid = new ColorPair(hue);
            theme.PrimaryDark = new ColorPair(hue.Darken());

            paletteHelper.SetTheme(theme);
        }

        public bool IsDarkTheme
        {
            get { return isDarkTheme; }
            set
            {
                if (SetProperty(ref isDarkTheme, value))
                {
                    ModifyTheme(theme => theme.SetBaseTheme(value ? Theme.Dark : Theme.Light));
                }
            }
        }

        private void ModifyTheme(Action<ITheme> modificationAction)
        {
            ITheme theme = paletteHelper.GetTheme();

            modificationAction?.Invoke(theme);

            paletteHelper.SetTheme(theme);
        }

        public DelegateCommand<object> ChangeHueCommand { get; private set; }

        public IEnumerable<ISwatch> Swatches { get; } = SwatchHelper.Swatches;
    }
}

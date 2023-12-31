﻿using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Sample._1
{
    public class GridViewColumnThumb : Thumb
    {
        public GridViewColumnThumb() : base()
        {
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.SizeWE;
            base.OnMouseLeftButtonDown(e);
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            Mouse.OverrideCursor = null;
        }
    }
}
﻿using System.Collections.Generic;
using System.Diagnostics;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace RemoteTerminal.Screens
{
    public class ScreenCell : IRenderableScreenCell
    {
        public ScreenCell()
        {
            this.Reset();
        }

        public void Reset()
        {
            this.Character = ' ';
            this.Modifications = ScreenCellModifications.None;
            this.ForegroundColor = ScreenColor.DefaultForeground;
            this.BackgroundColor = ScreenColor.DefaultBackground;
        }

        public override string ToString()
        {
            return this.Character.ToString();
        }

        public void ApplyFormat(ScreenCellFormat format)
        {
            if (format == null)
            {
                return;
            }

            this.Modifications = ScreenCellModifications.None;
            if (format.BoldMode)
            {
                this.Modifications |= ScreenCellModifications.Bold;
            }

            if (format.UnderlineMode)
            {
                this.Modifications |= ScreenCellModifications.Underline;
            }

            if (format.ReverseMode)
            {
                this.BackgroundColor = format.ForegroundColor;
                this.ForegroundColor = format.BackgroundColor;
            }
            else
            {
                this.BackgroundColor = format.BackgroundColor;
                this.ForegroundColor = format.ForegroundColor;
            }
        }

        public ScreenCell Clone()
        {
            return new ScreenCell()
            {
                Character = this.Character,
                Modifications = this.Modifications,
                ForegroundColor = this.ForegroundColor,
                BackgroundColor = this.BackgroundColor,
            };
        }

        public char Character { get; set; }
        public ScreenCellModifications Modifications { get; set; }
        public ScreenColor ForegroundColor { get; set; }
        public ScreenColor BackgroundColor { get; set; }
    }
}

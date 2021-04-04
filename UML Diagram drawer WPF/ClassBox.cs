﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace UML_Diagram_drawer_WPF
{
    class ClassBox : GroupBox
    {
        
        public ClassBox()
        {
            Height = 170;
            Width = 386;
                        
            var bc = new BrushConverter();
            Background = (Brush)bc.ConvertFrom("#FF3C3C3C");
            BorderBrush = Brushes.White;
            Foreground = Brushes.White;

            Grid gridClassBox = new Grid();

            gridClassBox.RowDefinitions.Add(new RowDefinition());
            gridClassBox.RowDefinitions.Add(new RowDefinition());
            gridClassBox.RowDefinitions.Add(new RowDefinition());

            TextBlock heading = new TextBlock();
            heading.FontSize = 18;
            heading.FontWeight = FontWeights.Bold;
            heading.HorizontalAlignment = HorizontalAlignment.Center;
            heading.VerticalAlignment = VerticalAlignment.Top;
            heading.Text = "C# Class";
            Grid.SetRow(heading, 0);

            gridClassBox.Children.Add(heading);
            this.Content = gridClassBox;

        }
        
    }
}

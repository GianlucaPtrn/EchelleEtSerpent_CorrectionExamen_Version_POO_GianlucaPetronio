using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace EX_Simpl_EchelleSerpent
{
    class StructureQuadri
    {
        MainWindow Structure = (EX_Simpl_EchelleSerpent.MainWindow)App.Current.MainWindow;
        public void Quadrillage()
        {
            Structure.Width = 800;
            Structure.Height = 720;

            Grid grdPlateau = new Grid();
            RowDefinition[] rowdef = new RowDefinition[10];
            ColumnDefinition[] colDef = new ColumnDefinition[10];

            for (int i = 0; i < 10; i++)
            {
                rowdef[i] = new RowDefinition();
                grdPlateau.RowDefinitions.Add(rowdef[i]);
            }

            for (int y = 0; y < 10; y++)
            {
                colDef[y] = new ColumnDefinition();
                grdPlateau.ColumnDefinitions.Add(colDef[y]);
            }

            Grid.SetColumn(grdPlateau, 0);
            Grid.SetRow(grdPlateau, 1);
            Structure.grdMain.Children.Add(grdPlateau);

            for (int x = 0; x < 10; x++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Structure.BtnCase[x, j] = new Button();
                    if (x % 2 == 0)
                    {
                        int numberCase = (10 * x) + j + 1;
                        Structure.BtnCase[x, j].Content = Convert.ToString(numberCase);

                    }
                    else
                    {
                        int numberCase = (10 * x) + 10 - j;
                        Structure.BtnCase[x, j].Content = Convert.ToString(numberCase);
                    }

                    if (int.Parse((string)Structure.BtnCase[x, j].Content) % 2 == 0)
                    {
                        Structure.BtnCase[x, j].Background = Brushes.Blue;
                    }
                    else
                    {
                        Structure.BtnCase[x, j].Background = Brushes.Red;
                    }

                    Structure.BtnCase[x, j].HorizontalAlignment = HorizontalAlignment.Center;
                    Structure.BtnCase[x, j].VerticalAlignment = VerticalAlignment.Center;
                    Structure.BtnCase[x, j].Width = 60;
                    Structure.BtnCase[x, j].Height = 60;

                    Grid.SetRow(Structure.BtnCase[x, j], x);
                    Grid.SetColumn(Structure.BtnCase[x, j], j);

                    grdPlateau.Children.Add(Structure.BtnCase[x, j]);
                }
            }
        }
    }
}

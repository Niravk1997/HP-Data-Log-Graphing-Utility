using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using MathNet.Numerics.Statistics;
using Microsoft.Win32;
using ScottPlot;
using Math_Waveform_Graph;
using Histogram_Graph;
using MahApps.Metro.Controls;

namespace DateTime_Waveform_Graph
{
    public partial class DateTime_Math_Waveform : MetroWindow
    {
        private void Graph_RightClick_Menu()
        {
            Graph.RightClicked -= Graph.DefaultRightClickEvent;
            Graph.RightClicked += Graph_RightClick_Menu_Options;
        }

        private void Graph_RightClick_Menu_Options(object sender, EventArgs e)
        {
            MenuItem addSaveImageMenuItem = new MenuItem() { Header = "Save Image" };
            addSaveImageMenuItem.Click += Right_ClickSave_Graph_Image;

            MenuItem addCopyImageMenuItem = new MenuItem() { Header = "Copy Image" };
            addCopyImageMenuItem.Click += RightClick_Copy_Graph_Image;

            MenuItem Place_Text_Here_MenuItem = new MenuItem() { Header = "Place Text" };
            Place_Text_Here_MenuItem.Click += Place_Text_Here_Click;

            ContextMenu rightClickMenu = new ContextMenu();
            rightClickMenu.Items.Add(addSaveImageMenuItem);
            rightClickMenu.Items.Add(addCopyImageMenuItem);
            rightClickMenu.Items.Add(Place_Text_Here_MenuItem);
            rightClickMenu.IsOpen = true;
        }

        private void Right_ClickSave_Graph_Image(object sender, EventArgs e)
        {
            Save_Graph_to_Image();
        }

        private void Save_Graph_to_Image()
        {
            try
            {
                var Save_Image_Window = new SaveFileDialog
                {
                    FileName = "Graph Plot_" + Measurement_Unit + "_" + DateTime.Now.ToString("yyyy-MM-dd h-mm-ss tt") + ".png",
                    Filter = "PNG Files (*.png)|*.png;*.png" +
                      "|JPG Files (*.jpg, *.jpeg)|*.jpg;*.jpeg" +
                      "|BMP Files (*.bmp)|*.bmp;*.bmp" +
                      "|All files (*.*)|*.*"
                };

                if (Save_Image_Window.ShowDialog() is true)
                {
                    Graph.Plot.SaveFig(Save_Image_Window.FileName);
                }
            }
            catch (Exception Ex)
            {
                Insert_Log("Could not save Graph Plot Image.", 1);
                Insert_Log(Ex.Message, 1);
            }
        }

        private void RightClick_Copy_Graph_Image(object sender, RoutedEventArgs e)
        {
            System.Drawing.Bitmap Graph_Image = Graph.Plot.Render(); ;

            MemoryStream Image_Memory = new MemoryStream();
            Graph_Image.Save(Image_Memory, System.Drawing.Imaging.ImageFormat.Png);

            BitmapImage Graph_Bitmap = new BitmapImage();
            Graph_Bitmap.BeginInit();
            Graph_Bitmap.StreamSource = new MemoryStream(Image_Memory.ToArray());
            Graph_Bitmap.EndInit();

            Clipboard.SetImage(Graph_Bitmap);

            Graph_Image.Dispose();
            Image_Memory.Dispose();
            Graph_Bitmap.Freeze();

        }

        private void Place_Text_Here_Click(object sender, RoutedEventArgs e)
        {
            (double Mouse_X, double Mouse_Y) = Graph.GetMouseCoordinates();
            (bool isValid, double Font_Num) = Text_Num(Font_Size_Place_Text.Text, false, false);
            if (Place_Text.Text != string.Empty & isValid == true)
            {
                if (Font_Num <= 30)
                {
                    Graph.Plot.AddText(Place_Text.Text, Mouse_X, Mouse_Y, size: (int)Font_Num, color: System.Drawing.ColorTranslator.FromHtml(PlaceText_GraphColor_Preview.Fill.ToString()));
                }
                else
                {
                    Insert_Log("Place Text Font Size must be between 0 and 30.", 2);
                }
            }
            else
            {
                if (Place_Text.Text == string.Empty)
                {
                    Insert_Log("Place Text must not be empty.", 2);
                }
                if (isValid == false)
                {
                    Insert_Log("Place Text Font Size must be a real number greater than 0.", 2);
                }
            }
        }
    }
}
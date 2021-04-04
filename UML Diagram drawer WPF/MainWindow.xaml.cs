using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UML_Diagram_drawer_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Перемещаемый элемент
        FrameworkElement moveObject;
        // Начальная позиция эдемента
        double beginTop;
        double beginLeft;

        // Допустимый диапазон перемещения мыши
        double mouseMinX;
        double mouseMinY;
        double mouseMaxX;
        double mouseMaxY;

        // Родительский холст
        //Canvas canvas;
        // Начальная позиция мыши в холсте
        double mouseBeginX;
        double mouseBeginY;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ClassBox cl = new ClassBox();
            cl.MouseLeftButtonDown += new MouseButtonEventHandler(groupClassBox_MouseLeftButtonDown);
            cl.MouseMove += new MouseEventHandler(groupClassBox_MouseMove);
            canvas.Children.Add(cl);
        }

        private void groupClassBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ((sender is ClassBox))
            {
                moveObject = (ClassBox)sender;

                if (moveObject.Parent is Canvas)
                {
                    beginTop = Canvas.GetTop(moveObject);
                    beginLeft = Canvas.GetLeft(moveObject);

                    mouseMaxX = canvas.Width - moveObject.Width;
                    mouseMaxY = canvas.Height - moveObject.Height;

                    Point point = e.GetPosition(moveObject);
                    mouseMaxX += point.X;
                    mouseMaxY += point.Y;

                    point = e.GetPosition(canvas);
                    beginLeft -= point.X;
                    beginTop -= point.Y;

                    moveObject.MouseMove += groupClassBox_MouseMove;
                }
            }
        }

        private void groupClassBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!(sender is FrameworkElement moveObject))
                return;

            Point point = e.GetPosition(canvas);
            double x = point.X;
            double y = point.Y;
            if (x < mouseMinX)
                x = mouseMinX;
            else if (x > mouseMaxX)
                x = mouseMaxX;
            if (y < mouseMinY)
                y = mouseMinY;
            else if (y > mouseMaxY)
                y = mouseMaxY;

            double top = beginTop + y;
            double left = beginLeft + x;

            Canvas.SetLeft(moveObject, left);
            Canvas.SetTop(moveObject, top);
        }
    }
}

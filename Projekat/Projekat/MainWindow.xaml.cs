using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

using Projekat.Vrsta;
using Projekat.Tip;
using Projekat.Etiketa;
using Projekat.Help;
using Projekat.DEMO;
using System.Xml.Linq;
using System.Timers;


namespace Projekat
{
    public partial class MainWindow : Window
    {
        private const int ICON_SIZE = 40;
        private ViewModel vm;
        Point start = new Point();
        private const int OFFSET = ICON_SIZE / 2;

        private const string FROM_SIDEBAR = "VrstaDraggedFromSidebar";
        private const string FROM_CANVAS = "VrstaDraggedFromCanvas";

        public class ViewModel
        {
            public ObservableCollection<VrstaA> Vrste { get; set; }     //vrste koje nisu jos ubacene na kanvas    
            public ObservableCollection<VrstaA> droppedVrste { get; set; }  //vrste spustene na kanvas
            public VrstaA ClickedVrsta { get; set; }    //kliknuta vrsta
        }

        public MainWindow()
        {
            InitializeComponent();

            SerijalizacijaEtikete.deserijalizacijaEtikete();    //ucitavam sve sacuvane etikete 
            SerijalizacijaTipa.deserijalizacijaTipa();          //ucitavam sve sacuvane tipove
            SerijalizacijaVrste.deserijalizacijaVrste();        //ucitavam sve sacuvane vrste

            //ugroVrste.ItemsSource = Podaci.getInstance().Vrste;

            vm = new ViewModel();
            vm.Vrste = new ObservableCollection<VrstaA>();
            vm.droppedVrste = new ObservableCollection<VrstaA>();
 

            foreach (VrstaA vrsta in Podaci.getInstance().Vrste)    //prolazim kroz sve vrste
            {
                if (vrsta.X == 0 && vrsta.Y == 0)   //ako koordinate vrste  0 znaci da se ne nalazi na kanvasu 
                {
                    vm.Vrste.Add(vrsta);    //dodajem vrstu u vrste koje nisu na KANVASU tj u prikaz sa lijeve strane
                }

                else    //inace su vrste na kanvasu i spustam ih na kanvas
                {
                    Canvas canvas = mapaVrsta;

                    try     //try catch u slucaju da se ikonica obrise sa diska
                    {
                        Image Ikonica = new Image
                        {
                            Width = ICON_SIZE,
                            Height = ICON_SIZE,
                            Uid = vrsta.Oznaka,
                            Source = new BitmapImage(new Uri(vrsta.Ikonica, UriKind.Absolute)),
                        };


                        Ikonica.ToolTip = vrsta.Oznaka; //ucitavam tooltipove na ikonicama na kanvasu

                        canvas.Children.Add(Ikonica);

                        Canvas.SetLeft(Ikonica, vrsta.X);
                        Canvas.SetTop(Ikonica, vrsta.Y);

                        vm.droppedVrste.Add(vrsta);
                    }

                    catch
                    {
                        MessageBox.Show("Neke ikonice nece biti prikazane jer su obrisane!");
                    }
                }
            }

            //this.DataContext = vm;
            ugroVrste.ItemsSource = vm.Vrste;

        }

        private VrstaA ClickedVrsta(int x, int y)   //vraca kliknutu vrstu na kanvasu
        {
            foreach (VrstaA vrsta in vm.droppedVrste)   //prolazim kroz vrste spustene na kanvas
            {
                if (Math.Sqrt(Math.Pow((x - vrsta.X - OFFSET), 2) + Math.Pow((y - vrsta.Y - OFFSET), 2)) < 1.5 * OFFSET)
                {
                    return vrsta;
                }
            }
            return null;
        }

        #region Click

        private void ucitaj()
        {
            foreach (VrstaA vrsta in Podaci.getInstance().Vrste)    //prolazim kroz sve vrste
            {
                if (vrsta.X == 0 && vrsta.Y == 0)   //ako su joj koordinate  0 znaci da se ne nalazi na kanvasu
                {
                    vm.Vrste.Add(vrsta);    //dodajem vrstu u vrste koje nisu na KANVASU
                }
            }
        }

        private void NovaVrsta_Click(object sender, RoutedEventArgs e)
        {
            var s = new NovaVrsta1(vm.Vrste);
            if (s.ShowDialog().Equals(true)) { }
        }

        private void NoviTip_Click(object sender, RoutedEventArgs e)
        {
            var s = new NoviTip1();
            if (s.ShowDialog().Equals(true)) { }
        }

        private void NovaEtiketa_Click(object sender, RoutedEventArgs e)
        {
            var s = new NovaEtiketa1();
            if (s.ShowDialog().Equals(true)) { }
        }

        private void PregledVrsta_Click(object sender, RoutedEventArgs e)
        {
            var s = new PregledVrsta(vm.Vrste, vm.droppedVrste, mapaVrsta);
            if (s.ShowDialog().Equals(true)) { }
        }

        private void PregledTipova_Click(object sender, RoutedEventArgs e)
        {
            var s = new PregledTipova();
            if (s.ShowDialog().Equals(true)) { }
        }

        private void PregledEtiketa_Click(object sender, RoutedEventArgs e)
        {
            var s = new PregledEtiketa();
            if (s.ShowDialog().Equals(true)) { }
        }

        private void DemoEtiketa_Click(object sender, RoutedEventArgs e)
        {
            var s = new NovaEtiketaDEMO();
            if (s.ShowDialog().Equals(true)) { }
        }

        private void DemoTip_Click(object sender, RoutedEventArgs e)
        {
            var s = new NoviTipDEMO();
            if (s.ShowDialog().Equals(true)) { }
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            var s = new About();
            if (s.ShowDialog().Equals(true)) { }
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            var s = new Pomoc();
            if (s.ShowDialog().Equals(true)) { }
        }

        #endregion Click


        #region DR&DOP CANVAS

        #region toBe
        private void mapaVrsta_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)  
        {

        }

        private void mapaVrsta_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void mapaVrsta_DragEnter(object sender, DragEventArgs e)
        {

        }

        #endregion toBe

        private void mapaVrsta_Drop(object sender, DragEventArgs e)
        {
            Point dropPosition = e.GetPosition(mapaVrsta);

            if (ClickedVrsta((int)dropPosition.X, (int)dropPosition.Y) != null) 
            {
                return;
            }

            if (e.Data.GetDataPresent(FROM_SIDEBAR))    //sa panela na kanvas
            {
                VrstaA vrsta = e.Data.GetData(FROM_SIDEBAR) as VrstaA;

                vm.Vrste.Remove(vrsta); //uklanjam iz vrsta koje nisu na kanvasu vrstu
                vrsta.X = (int)dropPosition.X - OFFSET;
                vrsta.Y = (int)dropPosition.Y - OFFSET;

                Podaci.ChangeDroppedVrsta(vrsta);   //pozivam serijalizaciju zbog koordinata

                vm.droppedVrste.Add(vrsta); //dodajem u vrste na kanvasu vrstu

                Canvas canvas = this.mapaVrsta;

                Image VrstaIkonica = new Image
                {
                    Width = ICON_SIZE,
                    Height = ICON_SIZE,
                    Uid = vrsta.Oznaka,
                    Source = new BitmapImage(new Uri(vrsta.Ikonica, UriKind.Absolute))
                };

                VrstaIkonica.ToolTip = vrsta.Oznaka;


                canvas.Children.Add(VrstaIkonica);

                Canvas.SetLeft(VrstaIkonica, vrsta.X);
                Canvas.SetTop(VrstaIkonica, vrsta.Y);

                return;
            }

            if (e.Data.GetDataPresent(FROM_CANVAS)) //sa kanvasa na kanvas
            {
                VrstaA vrsta = e.Data.GetData(FROM_CANVAS) as VrstaA;

                vm.droppedVrste.Remove(vrsta);
                vrsta.X = (int)dropPosition.X - OFFSET;
                vrsta.Y = (int)dropPosition.Y - OFFSET;

                Podaci.ChangeDroppedVrsta(vrsta);
                vm.droppedVrste.Add(vrsta);

                Canvas canvas = this.mapaVrsta;

                UIElement remove = null;
                foreach (UIElement elem in canvas.Children)
                {
                    if (elem.Uid == vrsta.Oznaka)
                    {
                        remove = elem;
                        break;
                    }
                }
                canvas.Children.Remove(remove);

                Image VrstaIkonica = new Image
                {
                    Width = ICON_SIZE,
                    Height = ICON_SIZE,
                    Uid = vrsta.Oznaka,
                    Source = new BitmapImage(new Uri(vrsta.Ikonica, UriKind.Absolute)),
                };

                VrstaIkonica.ToolTip = vrsta.Oznaka;
                //VrstaIkonica.ToolTip = vrsta.Ime;

                canvas.Children.Add(VrstaIkonica);

                Canvas.SetLeft(VrstaIkonica, vrsta.X);
                Canvas.SetTop(VrstaIkonica, vrsta.Y);

                return;
            }
        }

        private void mapaVrsta_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            start = e.GetPosition(null);

            Canvas map = sender as Canvas;

            VrstaA dataObject = null;
            Point mousePosition = e.GetPosition(mapaVrsta);

            dataObject = ClickedVrsta((int)mousePosition.X, (int)mousePosition.Y);

            if (dataObject != null)
            {
                DataObject data = new DataObject(FROM_CANVAS, dataObject);
                DragDrop.DoDragDrop(map, data, DragDropEffects.Move);
            }
        }

        #endregion DR&DOP CANVAS


        #region DR&DOP LIJEVA STRANA
        //lijeva strana
        private void StackPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)   //sa panela na kanvas
        {
            start = e.GetPosition(null);

            StackPanel panel = sender as StackPanel;
            VrstaA dataObject = null;

            foreach (VrstaA vrsta in vm.Vrste)
            {
                if ((string)panel.Tag == vrsta.Oznaka)
                {
                    dataObject = vrsta;
                    break;
                }
            }

            DataObject data = new DataObject(FROM_SIDEBAR, dataObject);
            DragDrop.DoDragDrop(panel, data, DragDropEffects.Move);
        }

        private void StackPanel_MouseMove(object sender, MouseEventArgs e)
        {

        }

        #endregion DR&DOP LIJEVA STRANA

        #region PromjenaMape

        private void PromjenaMape_Click(object sender, RoutedEventArgs e)
        {
            mapaSlika.ImageSource = new BitmapImage(new Uri("C:/Users/Lemur/GIT/HCI/Projekat/Projekat/map1.png"));
        }

        private void PromjenaMape1_Click(object sender, RoutedEventArgs e)
        {
            mapaSlika.ImageSource = new BitmapImage(new Uri("C:/Users/Lemur/GIT/HCI/Projekat/Projekat/map2.jpg"));
        }

        private void PromjenaMape2_Click(object sender, RoutedEventArgs e)
        {
            mapaSlika.ImageSource = new BitmapImage(new Uri("C:/Users/Lemur/GIT/HCI/Projekat/Projekat/map3.png"));
        }

        #endregion PromjenaMape

    }
}

﻿using System;
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
using System.Windows.Shapes;
using Microsoft.Win32;

using Projekat.Help;

namespace Projekat.Tip
{
    public partial class NoviTip1 : Window
    {
        private ViewModel vm;
        DataGrid dg;

        public class ViewModel
        {
            public TipP Tip { get; set; }
        }

        public NoviTip1(DataGrid d) //konstruktor kada dodajes iz pregleda kako bi osvjezio pregled
        {
            InitializeComponent();

            this.dg = d;
            vm = new ViewModel();
            vm.Tip = new TipP();
            this.DataContext = vm;
        }

        public NoviTip1()
        {
            InitializeComponent();

            this.dg = new DataGrid();
            vm = new ViewModel();
            vm.Tip = new TipP();
            this.DataContext = vm;
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            SerijalizacijaTipa.deserijalizacijaTipa();
            Podaci.getInstance().Tipovi.Add(vm.Tip);
            SerijalizacijaTipa.serijalizacijaTipa();
            this.dg.ItemsSource = Podaci.getInstance().Tipovi;  //!pazi
            this.Close();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnIkonica_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();


            fileDialog.Title = "Izaberite ikonicu";
            fileDialog.Filter = "Images|*.jpg;*.jpeg;*.png|" +
                                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                                "Portable Network Graphic (*.png)|*.png";
            if (fileDialog.ShowDialog() == true)
            {
                Ikonica.Source = new BitmapImage(new Uri(fileDialog.FileName));
                vm.Tip.Ikonica = fileDialog.FileName;
            }
        }

        private void btnPomoc_Click(object sender, RoutedEventArgs e)
        {
            var s = new Pomoc();
            if (s.ShowDialog().Equals(true)) { }
            //s.Show();
        }
    }
}

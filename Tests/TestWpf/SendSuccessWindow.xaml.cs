﻿using System;
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
using System.Windows.Shapes;

namespace TestWpf
{
    /// <summary>
    /// Логика взаимодействия для SendSuccessWindow.xaml
    /// </summary>
    public partial class SendSuccessWindow : Window
    {
        public SendSuccessWindow()
        {
            InitializeComponent();
        }

        private void Success_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

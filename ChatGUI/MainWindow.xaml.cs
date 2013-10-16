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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ChatBackend.ChatBackend _backend;

        public MainWindow()
        {
            InitializeComponent();
            _backend = new ChatBackend.ChatBackend(this.DisplayMessage);
        }

        public void DisplayMessage(ChatBackend.CompositeType composite)
        {
            string username = composite.Username == null ? "" : composite.Username;
            string message = composite.Message == null ? "" : composite.Message;
            textBoxLog.Text += (username + ": " + message + Environment.NewLine);
        }

        private void textBoxEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Enter)
            {
                _backend.SendMessage(textBoxEntry.Text);
                textBoxEntry.Clear();
            }
        }
    }
}

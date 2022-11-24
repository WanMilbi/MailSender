﻿using System.Net.Mime;
using System.Threading;
using System.Windows;

namespace WPFTests
{
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComputeResultButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var result = GetResultHard();
            new Thread(() =>
            {
                UpdateResultValue(result);
            }){IsBackground = true}.Start();
        }

        private void UpdateResultValue(string Result)
        {
            if (Dispatcher.CheckAccess())
                ResultText.Text = Result;
            else
                Dispatcher.Invoke(() => UpdateResultValue(Result));
        }
        
        private string GetResultHard()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
            }

            return "Hello World!";
        }
    }
}

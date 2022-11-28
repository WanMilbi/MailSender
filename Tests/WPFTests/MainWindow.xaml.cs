using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;

namespace WPFTests
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void ComputeResultButton_Click(object sender, System.Windows.RoutedEventArgs e)
        //{
        //    var result = GetResultHard();
        //    new Thread(() =>
        //    {
        //        UpdateResultValue(result);
        //    }){IsBackground = true}.Start();
        //}

        //private void UpdateResultValue(string Result)
        //{
        //    if (Dispatcher.CheckAccess())
        //        ResultText.Text = Result;
        //    else
        //        Dispatcher.Invoke(() => UpdateResultValue(Result));
        //}

        //private string GetResultHard()
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //        Thread.Sleep(10);
        //    }

        //    return "Hello World!";
        //}
        private async void OnOpenFileClick(object Sender, RoutedEventArgs E)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Выбор файла для чтения",
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*",
                RestoreDirectory = true
            };

            if (dialog.ShowDialog() != true) return;

             //var dict = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);*/

            //using (var reader = new StreamReader(dialog.FileName))
            //{
            //    while (!reader.EndOfStream)
            //    {
            //        var line = await reader.ReadLineAsync().ConfigureAwait(false);
            //        var words = line.Split(' ');
            //        await Task.Delay(1000);

            //        foreach (var word in words)
            //        {
            //            if (dict.ContainsKey(word))
            //                dict[word]++;
            //            else
            //            dict.Add(word, 1);

            //            //ProgressInfo.Value = reader.BaseStream.Position / (double) reader.BaseStream.Length;
            //            ProgressInfo.Dispatcher.Invoke(() =>
            //                ProgressInfo.Value = reader.BaseStream.Position / (double)reader.BaseStream.Length);
            //        }
            //        }
            //var count = dict.Count;
            //    //Result.Text = $"Число слов {count}
            //    ProgressInfo.Dispatcher.Invoke(() =>
            //                    Result.Text = $"Число слов {count}");

StartAction.IsEnabled = false;
CancelAction.IsEnabled = true;

_ReadingFileCancellation = new CancellationTokenSource();
    
    var cancel = _ReadingFileCancellation.Token;
IProgress<double> progress = new Progress<double>(p => ProgressInfo.Value = p);

            try
    {
        
        var count = await GetWordsCountAsync(dialog.FileName, progress, cancel);
        Result.Text = $"Число слов {count}";
            }
    catch (OperationCanceledException)
    {
        Debug.WriteLine("Операция чтения файла была отменена");
        Result.Text = "---";
        progress.Report(0);
    }             

            CancelAction.IsEnabled = false;
            StartAction.IsEnabled = true;
        }

        private static async Task<int> GetWordsCountAsync(string FileName, IProgress<double> Progress = null, CancellationToken Cancel = default)
        {
            var dict = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
Cancel.ThrowIfCancellationRequested();
            using (var reader = new StreamReader(FileName))
            {
                while (!reader.EndOfStream)
                {
                    Cancel.ThrowIfCancellationRequested();
                    var line = await reader.ReadLineAsync().ConfigureAwait(false);
                    var words = line.Split(' ');
                    //await Task.Delay(5000);

                    foreach (var word in words)
                    {
                        if (dict.ContainsKey(word))
                            dict[word]++;
                        else
                            dict.Add(word, 1);
Progress?.Report(reader.BaseStream.Position / (double)reader.BaseStream.Length);
                        
                    }
                } 
return dict.Count;
            }
        }

        private CancellationTokenSource _ReadingFileCancellation;

        private void OnCancelReadingClick(object Sender, RoutedEventArgs E)
        {
            _ReadingFileCancellation?.Cancel();
        }
    }

}

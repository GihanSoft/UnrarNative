using Gihan.UnrarNative;
using Gihan.UnrarNative.Models;
using Gihan.UnrarNative.Models.Enums;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
//using System.Windows.Forms;

namespace Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSelectArchive_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog
            {
                CheckFileExists = true
            };
            var result = fileDialog.ShowDialog();
            if (result == true)
            {
                TxtArchiveDir.Text = fileDialog.FileName;
            }

            RAROpenArchiveDataEx openArchiveDataEx = new RAROpenArchiveDataEx()
            {
                ArcName = TxtArchiveDir.Text,
                ArcNameW = TxtArchiveDir.Text,
                OpenMode = OpenMode.List,
            };
            openArchiveDataEx.Initializ();

            var rarHandle = Unrar.RAROpenArchiveEx(ref openArchiveDataEx);
            RARHeaderDataEx headerDataEx = new RARHeaderDataEx();
            headerDataEx.Initialize();

            string preFile = null;
            var entities = new List<string>();

            while (true)
            {
                Unrar.RARReadHeaderEx(rarHandle, ref headerDataEx);
                if (headerDataEx.FileNameW == "" || headerDataEx.FileNameW == " ")
                {
                    if (preFile == headerDataEx.FileName) break;
                    preFile = headerDataEx.FileName;
                }
                else
                {
                    if (preFile == headerDataEx.FileNameW) break;
                    preFile = headerDataEx.FileNameW;
                }
                entities.Add(preFile);
                Unrar.RARProcessFileW(rarHandle, Operation.Skip, null, null);
            }
            Unrar.RARCloseArchive(rarHandle);

            var entityTree = new List<TreeViewItem>();

            entities.Sort();

            foreach (var entity in entities)
            {
                if (!entity.Contains("\\"))
                {
                    entityTree.Add(new TreeViewItem() { Header = entity });
                    continue;
                }
                var parent = entityTree.First(en => (entity.StartsWith((string)en.Header)));
                parent.Items.Add(entity);
            }

            tre.ItemsSource = entityTree;
        }

        private void BtnSelectFolder_Click(object sender, RoutedEventArgs e)
        {
            var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            var result = folderBrowserDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                TxtExtractDir.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void BtnExtract_Click(object sender, RoutedEventArgs e)
        {
            RAROpenArchiveDataEx openArchiveDataEx = new RAROpenArchiveDataEx()
            {
                ArcName = TxtArchiveDir.Text,
                ArcNameW = TxtArchiveDir.Text,
                OpenMode = OpenMode.Extract,
                Callback = UNRARCallback
            };
            openArchiveDataEx.Initializ();

            var rarHandle = Unrar.RAROpenArchiveEx(ref openArchiveDataEx);
            RARHeaderDataEx headerDataEx = new RARHeaderDataEx();
            headerDataEx.Initialize();

            while (true)
            {
                Unrar.RARReadHeaderEx(rarHandle, ref headerDataEx);
                Unrar.RARProcessFileW(rarHandle, Operation.Extract, TxtExtractDir.Text, null);
                if (headerDataEx.FileNameW == " ") break;
            }
            Unrar.RARCloseArchive(rarHandle);
        }

        private int UNRARCallback(CallbackMessages msg, long UserData, IntPtr p1, long p2)
        {
            return 1;
        }
    }
}
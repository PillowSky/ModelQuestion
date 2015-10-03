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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ModelQuestion {
    public partial class MainWindow : Window {
        private QuestionModel Model = new QuestionModel();

        public MainWindow() {
            InitializeComponent();
            this.DataContext = Model;
        }

        private void DirectoryButton_Click(object sender, RoutedEventArgs e) {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                Model.Directory = dialog.SelectedPath;
                Model.Questions = QuestionLoader.LoadQuestion(dialog.SelectedPath);
                
                if (Model.Questions.Length == 0) {
                    OptionGrid.IsEnabled = false;
                    MessageBox.Show("No usable test case, the directory choosed is incorrect", "Incorrect directory", MessageBoxButton.OK, MessageBoxImage.Stop);
                } else {
                    OptionGrid.IsEnabled = true;
                    CaseCount.Maximum = CaseCount.Value = Model.Questions.Length;
                }
            }
        }

        private void PathButton_Click(object sender, RoutedEventArgs e) {
            System.Windows.Forms.SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog();
            dialog.DefaultExt = "xlsx";
            dialog.Filter = "Excel Worksheet (*.xlsx)|*.xlsx|Comma Separated Values (*.csv)|*.csv|Text Files (*.txt)|*.txt";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                Model.Path = dialog.FileName;
                StartButton.IsEnabled = true;
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e) {

        }
    }
}

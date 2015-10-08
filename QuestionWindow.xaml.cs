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

namespace ModelQuestion {
    /// <summary>
    /// Interaction logic for QuestionWindow.xaml
    /// </summary>
    public partial class QuestionWindow : Window {
        private QuestionModel Model;

        public QuestionWindow(QuestionModel model) {
            InitializeComponent();
            this.DataContext = Model = model;
            Model.TimeBegin = DateTime.Now;
        }

        private void Next_Click(object sender, RoutedEventArgs e) {
            if (Model.Current.Selected == null) {
                MessageBox.Show("Please select to continue", "Please select to continue", MessageBoxButton.OK, MessageBoxImage.Stop);
            } else {
                if (Model.Index + 1 < Model.CaseCount) {
                    Model.Index++;
                } else {
                    if (MessageBox.Show("Are you sure to submit?", "Are you sure to sumit?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) {
                        Model.TimeEnd = DateTime.Now;
                        QuestionIO.StoreQuestion(Model);
                        MessageBox.Show("Test result saved to " + Model.Path, "Test result saved", MessageBoxButton.OK, MessageBoxImage.Information);

                        MainWindow window = new MainWindow(Model);
                        window.Show();
                        Close();
                    }
                }
            }
        }

        private void Prev_Click(object sender, RoutedEventArgs e) {
            if (Model.Index > 0) {
                Model.Index--;
            }
        }
    }
}

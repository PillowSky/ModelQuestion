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

namespace ModelQuestion {
    public partial class MainWindow : Window {
        private Question[] Questions;

        public MainWindow() {
            InitializeComponent();
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e) {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                PathBox.Text = dialog.SelectedPath;
                PreviewGrid.ItemsSource = Questions = QuestionLoader.LoadQuestion(dialog.SelectedPath);
                QuestionCount.Content = Questions.Length;

                if (Questions.Length == 0) {
                    OptionGrid.IsEnabled = false;
                    MessageBox.Show("No usable test case, the directory choosed is incorrect", "Incorrect directory", MessageBoxButton.OK, MessageBoxImage.Stop);
                } else {
                    OptionGrid.IsEnabled = true;
                    CaseCount.Maximum = CaseCount.Value = Questions.Length;
                }
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e) {
            Console.Write(sender);
            Console.WriteLine(e);
        }

        private void SerialRadio_Checked(object sender, RoutedEventArgs e) {
            if (CaseCount != null) {
                CaseCount.IsEnabled = false;
            }
        }

        private void RandomRadio_Checked(object sender, RoutedEventArgs e) {
            if (CaseCount != null) {
                CaseCount.IsEnabled = true;
            }
        }
    }
}

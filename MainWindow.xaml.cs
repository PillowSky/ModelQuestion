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
        private QuestionModel Model;

        public MainWindow() {
            InitializeComponent();
            DataContext = Model = new QuestionModel();
        }

        public MainWindow(QuestionModel model) {
            InitializeComponent();
            DataContext = Model = model;
        }

        private void DirectoryButton_Click(object sender, RoutedEventArgs e) {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                Model.Directory = dialog.SelectedPath;
                Model.Questions = QuestionIO.LoadQuestion(dialog.SelectedPath);

                if (Model.Questions.Length == 0) {
                    MessageBox.Show(FindResource("BadDirectoryText") as string, FindResource("BadDirectoryTitle") as string, MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
        }

        private void PathButton_Click(object sender, RoutedEventArgs e) {
            System.Windows.Forms.SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog();
            dialog.DefaultExt = "txt";
            dialog.Filter = "Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                Model.Path = dialog.FileName;

                if (Model.Cases != null) {
                    QuestionIO.StoreQuestion(Model);
                    MessageBox.Show(FindResource("ResultSavedText") as string + Model.Path, FindResource("ResultSavedTitle") as string, MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e) {
            if (Model.IsRandom) {
                Random rng = new Random();
                Model.Cases = Model.Questions.OrderBy(q => rng.Next()).Take(Model.CaseCount).ToArray();
            } else {
                Model.Cases = Model.Questions;
            }

            QuestionWindow window = new QuestionWindow(Model);
            window.Show();
            Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ModelQuestion {
    public class QuestionModel : INotifyPropertyChanged {
        private string _directory;
        public string Directory {
            get {
                return _directory;
            }
            set {
                _directory = value;
                NotifyPropertyChanged("Directory");
                NotifyPropertyChanged("IsReady");
            }
        }

        private string _path;
        public string Path {
            get {
                return _path;
            }
            set {
                _path = value;
                NotifyPropertyChanged("Path");
                NotifyPropertyChanged("IsReady");
            }
        }

        private Question[] _questions;
        public Question[] Questions {
            get {
                return _questions;
            }
            set {
                _questions = value;
                ProblemCount = value.Length;
                NotifyPropertyChanged("Questions");
                NotifyPropertyChanged("IsReady");
            }
        }

        private Question[] _problems;
        public Question[] Problems {
            get {
                return _problems;
            }
            set {
                _problems = value;
                NotifyPropertyChanged("Problems");
            }
        }

        private bool _isRandom;
        public bool IsRandom {
            get {
                return _isRandom;
            }
            set {
                _isRandom = value;
                NotifyPropertyChanged("IsRandom");
            }
        }

        private int _problemCount;
        public int ProblemCount {
            get {
                return _problemCount;
            }
            set {
                _problemCount = value;
                NotifyPropertyChanged("ProblemCount");
            }
        }

        public bool IsReady {
            get {
                return _questions != null && _questions.Length > 0 && _path != null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

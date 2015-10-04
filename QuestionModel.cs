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
                NotifyPropertyChanged("ProblemMax");
            }
        }

        public int ProblemMax {
            get {
                return _problemCount - 1;
            }
        }

        public bool IsReady {
            get {
                return _questions != null && _questions.Length > 0 && _path != null;
            }
        }

        public DateTime TimeBegin;
        public DateTime TimeEnd;
        public Answer[] Answers { get; set; }

        private Answer _current;
        public Answer Current {
            get {
                if (_current == null) {
                    return Answers[0];
                } else {
                    return _current;
                }
            }
            set {
                _current = value;
                NotifyPropertyChanged("Current");
            }
        }

        private int _index;
        public int Index {
            get {
                return _index;
            }
            set {
                _index = value;
                Current = Answers[value];
                NotifyPropertyChanged("Index");
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

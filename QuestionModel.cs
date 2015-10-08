﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ModelQuestion {
    public class QuestionModel : INotifyPropertyChanged {
        private string _directory;
        private string _path;
        private bool _isRandom;
        private int _caseCount;
        private int _index;
        private Question _current;
        private Question[] _questions;
        private Question[] _cases;

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

        public bool IsRandom {
            get {
                return _isRandom;
            }
            set {
                _isRandom = value;
                NotifyPropertyChanged("IsRandom");
            }
        }

        public int CaseCount {
            get {
                return _caseCount;
            }
            set {
                _caseCount = value;
                NotifyPropertyChanged("CaseCount");
            }
        }

        public int Index {
            get {
                return _index;
            }
            set {
                _index = value;
                NotifyPropertyChanged("Index");
                NotifyPropertyChanged("NatureIndex");
                Current = _questions[value];
            }
        }

        public Question Current {
            get {
                return _current;
            }
            set {
                _current = value;
                NotifyPropertyChanged("Current");
            }
        }

        public Question[] Questions {
            get {
                return _questions;
            }
            set {
                _questions = value;
                NotifyPropertyChanged("Questions");
                NotifyPropertyChanged("IsReady");

                CaseCount = value.Length;
            }
        }

        public Question[] Cases {
            get {
                return _cases;
            }
            set {
                _cases = value;
                NotifyPropertyChanged("Cases");

                Current = value.FirstOrDefault();
            }
        }

        public bool IsReady {
            get {
                return _directory != null && _path != null && _questions != null && _questions.Length > 0;
            }
        }

        public int NatureIndex {
            get {
                return _index + 1;
            }
            set {
                Index = value - 1;
            }
        }

        public DateTime TimeBegin;
        public DateTime TimeEnd;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

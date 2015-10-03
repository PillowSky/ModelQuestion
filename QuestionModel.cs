﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ModelQuestion {
    class QuestionModel : INotifyPropertyChanged {
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
                _items = value.Length;
                NotifyPropertyChanged("Questions");
                NotifyPropertyChanged("Items");
                NotifyPropertyChanged("IsReady");
            }
        }

        private Question[] _cases;
        public Question[] Cases {
            get {
                return _cases;
            }
            set {
                _cases = value;
                NotifyPropertyChanged("Cases");
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

        private int _items;
        public int Items {
            get {
                return _items;
            }
            set {
                _items = value;
                NotifyPropertyChanged("Items");
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

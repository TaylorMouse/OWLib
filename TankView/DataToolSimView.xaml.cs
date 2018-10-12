﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace TankView {
    /// <summary>
    /// Interaction logic for DataToolSimView.xaml
    /// </summary>
    public partial class DataToolSimView : Window {

        private string _moduleName = "DataTool";

        public string ModuleName {
            get => _moduleName;
            set {
                _moduleName = value;
                NotifyPropertyChanged(nameof(ModuleName));
            }
        }

        private Control _control;
        
        public Control DataToolControl {
            get => _control;
            set {
                _control = value;
                MainSource.Children.Clear();
                MainSource.Children.Add(DataToolControl);
                NotifyPropertyChanged(nameof(DataToolControl));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string name) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        
        public DataToolSimView() {
            InitializeComponent();
        }
    }
}

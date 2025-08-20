﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;

namespace Dev_WpfAppFramework.ViewModels
{
    class MainWindowViewModel: ViewModelBase
    {
        [BindableProperty]
        public virtual ViewModelBase CurrentContent { get; set; }

        public MainWindowViewModel()
        {
            CurrentContent = new QuickTestViewModel();
        }
    }
}

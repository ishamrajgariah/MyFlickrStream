﻿using FlickrStream.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
using FlickrStream.Infrastructure;
using Unity;

namespace FlickrStream.Views
{
    /// <summary>
    /// Interaction logic for StreamView.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class StreamView : UserControl
    {
        public StreamView()
        {
            InitializeComponent();
            this.DataContext = DIContainer.UnityContainer.Resolve<IPhotoViewModel>();
        }
    }
}

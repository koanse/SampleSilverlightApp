﻿#pragma checksum "C:\Users\Антон\Documents\Visual Studio 2010\Projects\StudBusApp\StudBusApp\Views\Home.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "736071FF2780177DCA2A08146B59A409"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.1
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace StudBusApp {
    
    
    public partial class Home : System.Windows.Controls.Page {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.ScrollViewer PageScrollViewer;
        
        internal System.Windows.Controls.StackPanel ContentStackPanel;
        
        internal System.Windows.Controls.TextBlock HeaderText;
        
        internal System.Windows.Controls.TextBlock ContentText;
        
        internal System.Windows.Controls.DataGrid группаDataGrid;
        
        internal System.Windows.Controls.DataGridTextColumn кодColumn;
        
        internal System.Windows.Controls.DataGridTextColumn наименованиеColumn;
        
        internal System.Windows.Controls.DomainDataSource группаDomainDataSource;
        
        internal System.Windows.Controls.DataForm dataForm1;
        
        internal System.Windows.Controls.DataGrid студентDataGrid;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/StudBusApp;component/Views/Home.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.PageScrollViewer = ((System.Windows.Controls.ScrollViewer)(this.FindName("PageScrollViewer")));
            this.ContentStackPanel = ((System.Windows.Controls.StackPanel)(this.FindName("ContentStackPanel")));
            this.HeaderText = ((System.Windows.Controls.TextBlock)(this.FindName("HeaderText")));
            this.ContentText = ((System.Windows.Controls.TextBlock)(this.FindName("ContentText")));
            this.группаDataGrid = ((System.Windows.Controls.DataGrid)(this.FindName("группаDataGrid")));
            this.кодColumn = ((System.Windows.Controls.DataGridTextColumn)(this.FindName("кодColumn")));
            this.наименованиеColumn = ((System.Windows.Controls.DataGridTextColumn)(this.FindName("наименованиеColumn")));
            this.группаDomainDataSource = ((System.Windows.Controls.DomainDataSource)(this.FindName("группаDomainDataSource")));
            this.dataForm1 = ((System.Windows.Controls.DataForm)(this.FindName("dataForm1")));
            this.студентDataGrid = ((System.Windows.Controls.DataGrid)(this.FindName("студентDataGrid")));
        }
    }
}

﻿#pragma checksum "C:\Users\Антон\Documents\Visual Studio 2010\Projects\StudBusApp\StudBusApp\Views\Дисциплины.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "502AA7256B82F28D5B118DEFEB72F992"
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
    
    
    public partial class ДисциплиныPage : System.Windows.Controls.Page {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.ScrollViewer PageScrollViewer;
        
        internal System.Windows.Controls.StackPanel ContentStackPanel;
        
        internal System.Windows.Controls.TextBlock HeaderText;
        
        internal System.Windows.Controls.DomainDataSource дисциплинаDomainDataSource;
        
        internal System.Windows.Controls.DataForm дисциплинаDataForm;
        
        internal System.Windows.Controls.DomainDataSource студентDomainDataSource;
        
        internal System.Windows.Controls.DataGrid дисциплинаDataGrid;
        
        internal System.Windows.Controls.DataGridTextColumn наименованиеColumn;
        
        internal System.Windows.Controls.Button button1;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/StudBusApp;component/Views/%D0%94%D0%B8%D1%81%D1%86%D0%B8%D0%BF%D0%BB%D0%B8%D0%B" +
                        "D%D1%8B.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.PageScrollViewer = ((System.Windows.Controls.ScrollViewer)(this.FindName("PageScrollViewer")));
            this.ContentStackPanel = ((System.Windows.Controls.StackPanel)(this.FindName("ContentStackPanel")));
            this.HeaderText = ((System.Windows.Controls.TextBlock)(this.FindName("HeaderText")));
            this.дисциплинаDomainDataSource = ((System.Windows.Controls.DomainDataSource)(this.FindName("дисциплинаDomainDataSource")));
            this.дисциплинаDataForm = ((System.Windows.Controls.DataForm)(this.FindName("дисциплинаDataForm")));
            this.студентDomainDataSource = ((System.Windows.Controls.DomainDataSource)(this.FindName("студентDomainDataSource")));
            this.дисциплинаDataGrid = ((System.Windows.Controls.DataGrid)(this.FindName("дисциплинаDataGrid")));
            this.наименованиеColumn = ((System.Windows.Controls.DataGridTextColumn)(this.FindName("наименованиеColumn")));
            this.button1 = ((System.Windows.Controls.Button)(this.FindName("button1")));
        }
    }
}


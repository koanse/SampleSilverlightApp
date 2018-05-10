using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using StudBusApp.Web;
using System.Windows.Data;

namespace StudBusApp.Views
{
    public class КодГруппыConverter : IValueConverter
    {

        #region Члены IValueConverter

        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // КодГруппы->Наименование
            int i = СтудентыPage.lGID.BinarySearch((int)value);
            if (i >= 0)
                return СтудентыPage.lGName[i];
            return "Не определена";
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Наименование->КодГруппы
            int i = СтудентыPage.lGName.IndexOf((string)value);
            if (i >= 0)
                return СтудентыPage.lGID[i];
            return 0;
        }

        #endregion
    }
    public partial class СтудентыPage : Page
    {
        public СтудентыPage()
        {
            InitializeComponent();
        }

        // Выполняется, когда пользователь переходит на эту страницу.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        public static List<int> lGID=new List<int>();
        public static List<string> lGName = new List<string>();
        

        private void button1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                студентDomainDataSource.SubmitChanges();
            }
            catch
            {
                студентDomainDataSource.RejectChanges();
                MessageBox.Show("Ошибка сохранения");
            }
        }

        private void группаDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {
            lGID.Clear();
            lGName.Clear();
            for (int i = 0; i < группаDomainDataSource.DataView.Count; i++)
            {
                int id=(группаDomainDataSource.DataView[i] as Группа).Код;
                string name=(группаDomainDataSource.DataView[i] as Группа).Наименование;
                int j=lGID.BinarySearch(id);
                lGID.Insert(~j,id);
                lGName.Insert(~j,name);
            }
            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (!студентDomainDataSource.DataView.CanAdd)
                return;
            Студент s = new Студент()
            {                
                КодГруппы = (группаDomainDataSource.DataView[0] as Группа).Код,
                ФИО = ""
            };
            студентDomainDataSource.DataView.Add(s);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (студентDomainDataSource.DataView.CanRemove)
                студентDomainDataSource.DataView.RemoveAt(студентDomainDataSource.DataView.CurrentPosition);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            студентDomainDataSource.DataView.MoveCurrentToNext();
        }

        private void студентDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }
    }
}

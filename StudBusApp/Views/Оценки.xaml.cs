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
using System.Threading;
using System.ServiceModel.DomainServices.Client;

namespace StudBusApp.Views
{
    public partial class ОценкиPage : Page
    {
        public ОценкиPage()
        {
            InitializeComponent();
        }
        public static List<int> lSID = new List<int>();
        public static List<string> lSName = new List<string>();
        

        // Выполняется, когда пользователь переходит на эту страницу.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void оценкаDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        private void button1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                оценкаDomainDataSource.SubmitChanges();
            }            
            catch
            {
                оценкаDomainDataSource.RejectChanges();
                MessageBox.Show("Ошибка сохранения");
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            студентDomainDataSource1.QueryParameters[0].Value = кодComboBox1.SelectedValue;
            студентDomainDataSource1.QueryParameters[1].Value = кодComboBox.SelectedValue;
            студентDomainDataSource1.Load();            
        }        

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (оценкаDomainDataSource.DataView.CanRemove)
                    оценкаDomainDataSource.DataView.RemoveAt(оценкаDomainDataSource.DataView.CurrentPosition);
            }
            catch
            {
                MessageBox.Show("Ошибка удаления");
            }
        }

        private void студентDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {
            lSID.Clear();
            lSName.Clear();
            for (int i = 0; i < студентDomainDataSource.DataView.Count; i++)
            {
                int id = (студентDomainDataSource.DataView[i] as Студент).Код;
                string name = (студентDomainDataSource.DataView[i] as Студент).ФИО;
                int j = lSID.BinarySearch(id);
                lSID.Insert(~j, id);
                lSName.Insert(~j, name);
            }
            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        private void группаDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        private void дисциплинаDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
        {

            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            оценкаDomainDataSource.DataView.MoveCurrentToNext();
        }


        InvokeOperation<double> op;
        private void оценкаDomainDataSourceLoadButton_Click(object sender, RoutedEventArgs e)
        {
            if (!оценкаDomainDataSource.CanLoad)
            {
                MessageBox.Show("Для загрузки данных требуется сохранить изменения");
                return;
            }
            оценкаDomainDataSource.QueryParameters[0].Value = кодComboBox.SelectedValue;
            оценкаDomainDataSource.QueryParameters[1].Value = кодComboBox1.SelectedValue;            
            оценкаDomainDataSource.Load();
            StudDomainContext sdc = new StudDomainContext();
            op= sdc.GetAvgОценкаByГруппаДисциплина((int)кодComboBox.SelectedValue, (int)кодComboBox1.SelectedValue);
            op.Completed += new EventHandler(op_Completed);
        }

        void op_Completed(object sender, EventArgs e)
        {
            HeaderText.Text = string.Format("Средний балл по группе: {0:g3}", op.Value);
        }

        private void студентDomainDataSource1_LoadedData(object sender, LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                System.Windows.MessageBox.Show(e.Error.ToString(), "Load Error", System.Windows.MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
            // продолжение добавления записи
            if (студентDomainDataSource1.DataView.Count == 0)
            {
                MessageBox.Show("Добавление невозможно: для всех студентов данной группы проставлены оценки по данной дисциплине");
                return;
            }
            int i = 0;
            do
            {
                int j;
                for (j = 0; j < оценкаDomainDataSource.DataView.Count; j++)
                {
                    if ((оценкаDomainDataSource.DataView[j] as Оценка).КодСтудента ==
                        (студентDomainDataSource1.DataView[i] as Студент).Код)
                        break;
                }
                if (j == оценкаDomainDataSource.DataView.Count)
                    break;
                i++;
            }
            while (i < студентDomainDataSource1.DataView.Count);
            if (i == студентDomainDataSource1.DataView.Count)
            {
                MessageBox.Show("Добавление невозможно: для всех студентов данной группы проставлены оценки по данной дисциплине");
                return;
            }
            if (оценкаDomainDataSource.DataView.CanAdd)
                оценкаDomainDataSource.DataView.Add(new Оценка()
                {
                    КодДисциплины = (int)кодComboBox.SelectedValue,
                    КодСтудента = (студентDomainDataSource1.DataView[i] as Студент).Код,
                    Оценка1 = 100
                });            
        }
    }
    public class КодСтудентаConverter : IValueConverter
    {

        #region Члены IValueConverter

        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // КодСтудента->ФИО
            int i = ОценкиPage.lSID.BinarySearch((int)value);
            if (i >= 0)
                return ОценкиPage.lSName[i];
            return "Не определена";
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // ФИО->КодСтудента
            int i = ОценкиPage.lSName.IndexOf((string)value);
            if (i >= 0)
                return ОценкиPage.lSID[i];
            return 0;
        }

        #endregion
    }
}

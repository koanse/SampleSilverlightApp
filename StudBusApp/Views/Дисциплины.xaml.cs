namespace StudBusApp
{
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using System.Windows;

    /// <summary>
    /// <see cref="Page"/> class to present information about the current application.
    /// </summary>
    public partial class ДисциплиныPage : Page
    {
        /// <summary>
        /// Creates a new instance of the <see cref="ГруппыPage"/> class.
        /// </summary>
        public ДисциплиныPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Executes when the user navigates to this page.
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void дисциплинаDomainDataSource_LoadedData(object sender, LoadedDataEventArgs e)
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
                дисциплинаDomainDataSource.SubmitChanges();
            }
            catch
            {
                дисциплинаDomainDataSource.RejectChanges();
                MessageBox.Show("Ошибка сохранения");
            }
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
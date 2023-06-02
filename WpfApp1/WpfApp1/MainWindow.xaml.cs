using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using WpfApp1.ClassforSaving;
using WpfApp1.NewFolder1;

namespace WpfApp1
{
    
    public partial class MainWindow : Window
    {
        private readonly String Path = $"{Environment.CurrentDirectory}\\Todomod.json";
        private ClassforSaveDelite Savedell;
        private BindingList<Todomod> doList;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Savedell = new ClassforSaveDelite(Path);
            try
            {
                doList = Savedell.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            DgName.ItemsSource = doList;
            doList.ListChanged += IfdoListchanged;
        }
        private void IfdoListchanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                Savedell = new ClassforSaveDelite(Path);
                try
                {
                    Savedell.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
            
        }
    }
}
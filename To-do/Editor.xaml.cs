using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace To_do
{
    /// <summary>
    /// Interaction logic for Editor.xaml
    /// </summary>
    public partial class Editor : Window
    {
        public Editor()
        {
            InitializeComponent();
            BindingGroup = new BindingGroup();
            DataContext = new ToDo();
        }

        private void EditorUnos(object sender, RoutedEventArgs e)
        {
            if (BindingGroup.CommitEdit())
            {
                DialogResult = true;
                this.Close();
            }
        }

        private void EditorOtkaz(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

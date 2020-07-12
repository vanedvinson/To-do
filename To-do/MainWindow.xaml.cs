using System;
using System.Linq;
using System.Windows;

namespace To_do
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    

    public partial class MainWindow : Window
    {
        Baza db = new Baza();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            dg.ItemsSource = db.toDos.ToList();
            dgCekirano.ItemsSource = db.cekiranos.ToList();

        }

        private void AddToDo(object sender, RoutedEventArgs e)
        {
            Editor ed = new Editor();
            ed.Owner = this;

            if (ed.ShowDialog().Value)
            {
                db.toDos.Add(ed.DataContext as ToDo);
                db.SaveChanges();
                dg.ItemsSource = db.toDos.ToList();
            }
        }

        private void DeleteToDo(object sender, RoutedEventArgs e)
        {
            if(dg.SelectedItem != null)
            {
                db.toDos.Remove(dg.SelectedItem as ToDo);
                db.SaveChanges();
                dg.ItemsSource = db.toDos.ToList();
            }
        }

        private void EditToDo(object sender, RoutedEventArgs e)
        {
            if(dg.SelectedItem != null)
            {
                Editor ed = new Editor();
                ed.Owner = this;
                ed.DataContext = dg.SelectedItem;
                ed.ShowDialog();
                db.SaveChanges();
                dg.ItemsSource = db.toDos.ToList();

            }
            

        }

        private void CheckedToDo(object sender, RoutedEventArgs e)
        {
            if(dg.SelectedItem != null)
            {
                if ((dg.SelectedItem as ToDo).Time < DateTime.Now)
                {
                    Checked c = new Checked(DateTime.Now, (dg.SelectedItem as ToDo).Description, "FAIL");
                    db.cekiranos.Add(c);
                    db.toDos.Remove(dg.SelectedItem as ToDo);
                    db.SaveChanges();
                    dg.ItemsSource = db.toDos.ToList();
                    dgCekirano.ItemsSource = db.cekiranos.ToList();
                }
                else
                {
                    Checked c = new Checked(DateTime.Now, (dg.SelectedItem as ToDo).Description, "In Time");
                    db.cekiranos.Add(c);
                    db.toDos.Remove(dg.SelectedItem as ToDo);
                    db.SaveChanges();
                    dg.ItemsSource = db.toDos.ToList();
                    dgCekirano.ItemsSource = db.cekiranos.ToList();
                }
                

            }
        }

        private void DeleteChecked(object sender, RoutedEventArgs e)
        {
            if(dgCekirano.SelectedItem != null)
            {
                db.cekiranos.Remove(dgCekirano.SelectedItem as Checked);
                db.SaveChanges();
                dgCekirano.ItemsSource = db.cekiranos.ToList();
            }
        }
    }
}

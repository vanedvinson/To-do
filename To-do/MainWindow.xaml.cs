using System;
using System.Linq;
using System.Windows;

namespace To_do
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    /* TASK: napraviti kaze da li je u roku ili ne
     * TASK: Dodati dugme za brisanje na listi za cekirane
     * TASK: Napraviti Statistiku koliko je uspesno izvrsenih
     *  SUBTASK: npr za ovaj mesec
     */

    public partial class MainWindow : Window
    {
        Baza db = new Baza();
        public string heh;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            dg.ItemsSource = db.toDos.ToList();
            dgCekirano.ItemsSource = db.cekiranos.ToList();

        }

        private void dodajToDo(object sender, RoutedEventArgs e)
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

        private void ObrisiStavku(object sender, RoutedEventArgs e)
        {
            if(dg.SelectedItem != null)
            {
                db.toDos.Remove(dg.SelectedItem as ToDo);
                db.SaveChanges();
                dg.ItemsSource = db.toDos.ToList();
            }
        }

        private void IzmenaStavke(object sender, RoutedEventArgs e)
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

        private void GotovaStavka(object sender, RoutedEventArgs e)
        {
            if(dg.SelectedItem != null)
            {
                if ((dg.SelectedItem as ToDo).Vreme < DateTime.Now)
                {
                    Cekirano c = new Cekirano(DateTime.Now, (dg.SelectedItem as ToDo).Opis, "FAIL");
                    db.cekiranos.Add(c);
                    db.toDos.Remove(dg.SelectedItem as ToDo);
                    db.SaveChanges();
                    dg.ItemsSource = db.toDos.ToList();
                    dgCekirano.ItemsSource = db.cekiranos.ToList();
                }
                else
                {
                    Cekirano c = new Cekirano(DateTime.Now, (dg.SelectedItem as ToDo).Opis, "U roku");
                    db.cekiranos.Add(c);
                    db.toDos.Remove(dg.SelectedItem as ToDo);
                    db.SaveChanges();
                    dg.ItemsSource = db.toDos.ToList();
                    dgCekirano.ItemsSource = db.cekiranos.ToList();
                }
                

            }
        }

        private void ObrisiCekirano(object sender, RoutedEventArgs e)
        {
            if(dgCekirano.SelectedItem != null)
            {
                db.cekiranos.Remove(dgCekirano.SelectedItem as Cekirano);
                db.SaveChanges();
                dgCekirano.ItemsSource = db.cekiranos.ToList();
            }
        }
    }
}

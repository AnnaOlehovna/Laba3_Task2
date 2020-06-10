using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace Laba3_Task2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Person newPerson;
        ObservableCollection<Person> people;
        ObservableCollection<string> positions = new ObservableCollection<string>();                        
        ObservableCollection<string> cities = new ObservableCollection<string>();
        ObservableCollection<string>  streets= new ObservableCollection<string>();

        HashSet<string> positionHashSet = new HashSet<string>();
        HashSet<string> cityHashSet = new HashSet<string>();
        HashSet<string> streetHashSet = new HashSet<string>();

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream fs = new FileStream("person.txt", FileMode.OpenOrCreate))
                {
                    if (fs.Length != 0)
                    {
                        List<Person> list = (List<Person>)bf.Deserialize(fs);
                        people = new ObservableCollection<Person>(list);

                        foreach (Person p in list)
                        {
                            if (!positions.Contains(p.Position))
                            {
                                positions.Add(p.Position);
                            }

                            if (!cities.Contains(p.City))
                            {
                                cities.Add(p.City);
                            }

                            if (!streets.Contains(p.Street))
                            {
                                streets.Add(p.Street);
                            }
                        }
  
                    }
                    else
                    {
                        people = new ObservableCollection<Person>();
                        
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            newPerson = new Person();
            myGrid.DataContext = newPerson;

            personList.DataContext = people;
            tbPosition.DataContext = positions;
            tbCity.DataContext = cities;
            tbStreet.DataContext = streets;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            newPerson.Position = tbPosition.Text;
            newPerson.City = tbCity.Text;
            newPerson.Street = tbStreet.Text;

            people.Add(newPerson);

            if(!positions.Contains(newPerson.Position))
            {
                positions.Add(newPerson.Position);
            }

            if (!cities.Contains(newPerson.City))
            {
                cities.Add(newPerson.City);
            }

            if (!streets.Contains(newPerson.Street))
            {
                streets.Add(newPerson.Street);
            }

            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream("person.txt", FileMode.OpenOrCreate))
            {
                fs.SetLength(0);
                bf.Serialize(fs, people.ToList<Person>());
            }
            clearAllFields();
        }

        private void clearAllFields()
        {
            newPerson = new Person();
            myGrid.DataContext = newPerson;
            tbLastName.Text = null;
            tbPosition.Text = null;
            tbSalary.Text = "0";
            tbCity.Text = null;
            tbStreet.Text = null;
            tbHouse.Text = null;
        }
    }
}

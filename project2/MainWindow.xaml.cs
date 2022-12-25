using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.SqlClient;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;



namespace project2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    //EG/2019/3633
    //Kavinda B.G.K

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            binddatagrid();
            
            
            
        }
        //Bind data with datagrid
        public void binddatagrid() {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select* from [Employees]";
            cmd.Connection = conn;
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Employees");
            da.Fill(dt);
            g1.ItemsSource = dt.DefaultView;
            

        }
        //Data add to the data base (Add button)
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            ModelContext context = new ModelContext();
            Employee employee = new Employee() {
                EmpID = Int32.Parse(t1.Text),
                FName=t2.Text,
                LName=t3.Text,
                Age= Int32.Parse(t4.Text),
                Address=t5.Text,

            };
            context.EmpList.Add(employee);
            context.SaveChanges();
            binddatagrid();
            clc();
        }
        //Data Updata (Eddit button)
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ModelContext context = new ModelContext();
            //var employee1 = context.EmpList.Where(b=> b.EmpID==Int32.Parse(t1.Text)).ToList();
            var employee1 = context.EmpList.Find(Int32.Parse(t1.Text));
            employee1.FName = t2.Text;
            employee1.LName = t3.Text;
            employee1.Age = Int32.Parse(t4.Text);
            employee1.Address = t5.Text;
            context.SaveChanges();
            binddatagrid();
            clc();

        }

        //Data remove from data base (Delete Button)
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ModelContext context = new ModelContext();
            var employee1 = context.EmpList.Find(Int32.Parse(t1.Text));
            context.EmpList.Remove(employee1);
            context.SaveChanges();
            binddatagrid();
            clc();
        }

        // Data retereving (View Button)
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ModelContext context = new ModelContext();
            var employee1 = context.EmpList.Find(Int32.Parse(t1.Text));
            t2.Text = employee1.FName;
            t3.Text = employee1.LName;
            t4.Text = Convert.ToString(employee1.Age); 
            t5.Text = employee1.Address;
            


        }

        //Cancel button

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you want to exit application", "Exit message", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
          
            }
        }
         // this will clear textboxes
        public void clc() {
            t1.Clear();
            t2.Clear();
            t3.Clear();
            t4.Clear();
            t5.Clear();

        }
    }
}

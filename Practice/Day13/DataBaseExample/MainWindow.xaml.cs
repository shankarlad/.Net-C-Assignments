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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace DataBaseExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";

            cn.Open();
            MessageBox.Show("connection Successfull");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

            cmd.Parameters.AddWithValue("@EmpNo", txtEmpNo.Text);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Basic", txtBasic.Text);
            cmd.Parameters.AddWithValue("@DeptNo", txtDeptNo.Text);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            cn.Close();
            MessageBox.Show("Data added Successfully");
        }

        private void btnInserSp_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";

            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "InsertEmployee";

            cmd.Parameters.AddWithValue("@EmpNo", txtEmpNo.Text);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Basic", txtBasic.Text);
            cmd.Parameters.AddWithValue("@DeptNo", txtDeptNo.Text);

  
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            cn.Close();
            MessageBox.Show("Data added Successfully");
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";

            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "UpdateEmployee";

            cmd.Parameters.AddWithValue("@EmpNo", txtEmpNo.Text);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Basic", txtBasic.Text);
            cmd.Parameters.AddWithValue("@DeptNo", txtDeptNo.Text);


            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            cn.Close();
            MessageBox.Show("Data updated Successfully");
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";

            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "DeleteEmployee";

            cmd.Parameters.AddWithValue("@EmpNo", txtEmpNo1.Text);
           

            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            cn.Close();
            MessageBox.Show("Data Deleted Successfully");
        }

        private void btnSelectAll_1_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";

            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Employees";


            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                // dr.GetString(1)
                //dr.GetInt32(0)

                lstNames.Items.Add(dr["Name"]);
                //lstNames.Items.Add(dr[1]);
            }
            dr.Close();

            cn.Close();
        }

        private void btnSelectAll_2_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true;MultipleActiveResultSets=true";
            cn.Open();

            SqlCommand cmdDepts = new SqlCommand();
            cmdDepts.Connection = cn;
            cmdDepts.CommandType = CommandType.Text;
            cmdDepts.CommandText = "Select * from Department";

            SqlCommand cmdEmps = new SqlCommand();
            cmdEmps.Connection = cn;
            cmdEmps.CommandType = CommandType.Text;

            SqlDataReader drDepts = cmdDepts.ExecuteReader();
            while (drDepts.Read())
            {
                lstNames.Items.Add(drDepts["DeptName"]);

                cmdEmps.CommandText = "Select * from Employees where DeptNo = " + drDepts["DeptNo"];
                SqlDataReader drEmps = cmdEmps.ExecuteReader();
                while (drEmps.Read())
                {
                    lstNames.Items.Add("    " + drEmps["Name"]);
                }
                drEmps.Close();
            }
            drDepts.Close();
            cn.Close();
        }

        private void btnSelectAll_3_Click(object sender, RoutedEventArgs e)
        {
            SqlDataReader dr = GetDataReader();
            while (dr.Read())
            {
                lstNames.Items.Add(dr["Name"]);
            }
            dr.Close();
            //MessageBox.Show(cn.State.ToString());
        }

        private SqlDataReader GetDataReader()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Employees";
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            //SqlDataReader dr = cmd.ExecuteReader();
            //cn.Close();
            return dr;
        }

        private void btnTransaction_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";
            cn.Open();

            SqlTransaction t = cn.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.Transaction = t;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Employees values(109,'new emp',12345,10)";

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = cn;
            cmd2.Transaction = t;
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "insert into Employees values(110,'new emp2',12345,30)";
            try
            {
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                t.Commit();
                MessageBox.Show("commit");
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
                t.Rollback();
                MessageBox.Show("Rollback");
            }
            finally
            {
                cn.Close();
            }

        }

        private void btnScaler_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";

            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select count(*) from Employees";
            MessageBox.Show(cmd.ExecuteScalar().ToString());

            cn.Close();
        }
    }
}

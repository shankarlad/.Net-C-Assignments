using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace DataBaseExample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        DataSet ds;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";

            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            ds = new DataSet();
            cmd.CommandText = "select * from Employees";
            da.Fill(ds, "Emps");

            cmd.CommandText = "select * from Department";
            da.Fill(ds, "Deps");

            //dgEmps.ItemsSource = ds.Tables[0].DefaultView;
            dgEmps.ItemsSource = ds.Tables["Emps"].DefaultView;
            //dgEmps.ItemsSource = ds.Tables["Deps"].DefaultView;

            //primary key validation
            DataColumn[] arrCols = new DataColumn[1];
            arrCols[0] = ds.Tables["Emps"].Columns["EmpNo"];
            ds.Tables["Emps"].PrimaryKey = arrCols;

            //foreign key validation
            ds.Relations.Add(ds.Tables["Deps"].Columns["DeptNo"], ds.Tables["Emps"].Columns["DeptNo"]);

            //column level constraints
            //ds.Tables["Deps"].Columns["DeptName"].Unique = true;

            cn.Close();

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";

            cn.Open();

            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = cn;
            cmdUpdate.CommandType = CommandType.Text;
            cmdUpdate.CommandText = "update Employees set Name =@Name, Basic= @Basic, DeptNo = @DeptNo where EmpNo =@EmpNo";

            // cmdUpdate.Parameters.AddWithValue("@Name", txtName.Text);

            //SqlParameter p = new SqlParameter();
            //p.ParameterName = "@Name";
            //p.SourceColumn = "Name";
            //p.SourceVersion = DataRowVersion.Current;
            //cmdUpdate.Parameters.Add(p);
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });

            //similarly create the insert command
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = CommandType.Text;
            cmdInsert.CommandText = "Insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Current });


            //similarly create the delete command
            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.Connection = cn;
            cmdDelete.CommandType = CommandType.StoredProcedure;
            cmdDelete.CommandText = "DeleteEmployee";

            cmdDelete.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });

            SqlDataAdapter da = new SqlDataAdapter();

            da.UpdateCommand = cmdUpdate;
            da.InsertCommand = cmdInsert;
            da.DeleteCommand = cmdDelete;

           // da.ContinueUpdateOnError = true; // any error is there still go through whole list
            da.Update(ds, "Emps");
            MessageBox.Show("Done");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";

            cn.Open();

            //similarly create the update command
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = cn;
            cmdUpdate.CommandType = CommandType.Text;
            cmdUpdate.CommandText = "update Employees set Name =@Name, Basic= @Basic, DeptNo = @DeptNo where EmpNo =@EmpNo";

            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });

            //similarly create the insert command
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = CommandType.Text;
            cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });


            //similarly create the delete command
            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.Connection = cn;
            cmdDelete.CommandType = CommandType.Text;
            cmdDelete.CommandText = "delete from Employees where EmpNo=@EmpNo";

            cmdDelete.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });

            SqlDataAdapter da = new SqlDataAdapter();

            da.UpdateCommand = cmdUpdate;
            da.InsertCommand = cmdInsert;
            da.DeleteCommand = cmdDelete;
            DataSet ds2 = ds.GetChanges(); // all insert ,updated ,deleted
            //DataSet ds2 = ds.GetChanges(DataRowState.Modified); // perticuler modified values

            da.Update(ds2, "Emps");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";

            cn.Open();

            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = cn;
            cmdUpdate.CommandType = CommandType.Text;
            cmdUpdate.CommandText = "update Employees set Name =@Name, Basic= @Basic, DeptNo = @DeptNo where EmpNo =@EmpNo";


            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });

            //similarly create the insert command
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = CommandType.Text;
            cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });


            //similarly create the delete command
            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.Connection = cn;
            cmdDelete.CommandType = CommandType.Text;
            cmdDelete.CommandText = "delete from Employees where EmpNo=@EmpNo";

            cmdDelete.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });

            SqlDataAdapter da = new SqlDataAdapter();

            da.UpdateCommand = cmdUpdate;
            da.InsertCommand = cmdInsert;
            da.DeleteCommand = cmdDelete;


            da.Update(ds, "Emps");
            ds.AcceptChanges(); // changes to unchange

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ds.RejectChanges();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //DataView dv = new DataView(ds.Tables["Emps"]);
            //dv.RowFilter = "DeptNo=" + txtDeptNo.Text;  //where clause
            //                                            //dv.Sort = "Name"; // order by clause
            //dgEmps.ItemsSource = dv;


              ds.Tables["Emps"].DefaultView.RowFilter = "DeptNo=" + txtDeptNo.Text;
            //ds.Tables["Emps"].DefaultView.RowFilter = "";
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(ds.GetXml()); // give xml file of all data
            //MessageBox.Show(ds.GetXmlSchema()); // give structure of table with constarints

            ds.WriteXmlSchema("a.xsd");
            ds.WriteXml("a.xml", XmlWriteMode.DiffGram);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            ds = new DataSet();
            ds.ReadXmlSchema("a.xsd");
            ds.ReadXml("a.xml", XmlReadMode.DiffGram);
            dgEmps.ItemsSource = ds.Tables["Emps"].DefaultView;
        }
    }
}

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
using WpdTest1.ViewModel;

namespace WpdTest1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Student stu = new Student();
            //var stu = this.DataContext as Student;
            stu.Name = ssss.Text;
            
            string sql = $"insert into Student(Name,Sex) values('{stu.Name}',{stu.Sex})";
            int i= DBHelper.ExecuteNonQuery(sql);
            if (i>0)
            {
                MessageBox.Show("添加成功");
            }

        }
        
    }
}

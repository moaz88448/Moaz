using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
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

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            string task = TaskInput.Text.Trim();
            if (!string.IsNullOrEmpty(task))
            {
                TaskList.Items.Add(task);
                TaskInput.Clear();
                TaskInput.Focus();
            }
            else
            {
                MessageBox.Show("Please enter a task.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void TaskCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                var stackPanel = (StackPanel)checkBox.Parent;
                var deleteButton = (Button)stackPanel.Children[2];
                var editButton = (Button)stackPanel.Children[3];
                deleteButton.Visibility = Visibility.Visible;
                editButton.Visibility = Visibility.Visible;
            }
        }

        private void TaskCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                var stackPanel = (StackPanel)checkBox.Parent;
                var deleteButton = (Button)stackPanel.Children[2];
                var editButton = (Button)stackPanel.Children[3];
                deleteButton.Visibility = Visibility.Collapsed;
                editButton.Visibility = Visibility.Collapsed;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button deleteButton = sender as Button;
            if (deleteButton != null)
            {
                var stackPanel = (StackPanel)deleteButton.Parent;
                TaskList.Items.Remove((string)((TextBlock)stackPanel.Children[1]).Text);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Button editButton = sender as Button;
            if (editButton != null)
            {
                var stackPanel = (StackPanel)editButton.Parent;
                string currentTask = (string)((TextBlock)stackPanel.Children[1]).Text;

                string newTask = Microsoft.VisualBasic.Interaction.InputBox("Edit Task:", "Edit Task", currentTask);
                if (!string.IsNullOrEmpty(newTask))
                {
                    int index = TaskList.Items.IndexOf(currentTask);
                    TaskList.Items[index] = newTask;
                }
            }


        }
    }
}
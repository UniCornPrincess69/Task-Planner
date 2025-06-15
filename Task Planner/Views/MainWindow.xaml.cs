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
using Task_Planner.Models;
using Task_Planner.ViewModels;

namespace Task_Planner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            TaskList.ItemsSource = viewModel.Tasks;
        }


        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Titlebox.Text) || DeadlinePicker.SelectedDate == null || PriorityBox.SelectedItem == null)
            {
                MessageBox.Show("Please enter a title and select a deadline.");
                return;
            }

            var priority = (PriorityBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            var task = new TaskItem
            {
                Title = Titlebox.Text,
                Deadline = DeadlinePicker.SelectedDate.Value,
                Priority = priority
            };

            viewModel.AddTask(task);
            Titlebox.Clear();
            DeadlinePicker.SelectedDate = null;
            PriorityBox.SelectedIndex = -1;
        }

        private void RemoveTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedItem is TaskItem selectedTask)
            {
                viewModel.RemoveTask(selectedTask);
            }
            else
            {
                MessageBox.Show("Please select a task to remove.");
            }
        }
    }
}

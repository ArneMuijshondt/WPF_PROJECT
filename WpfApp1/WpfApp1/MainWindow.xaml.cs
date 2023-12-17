using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private string selectedRadioButtonContent = string.Empty;

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton && radioButton.IsChecked == true)
            {
                selectedRadioButtonContent = radioButton.Content.ToString();
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            var name = text_name.Text;
            var group = selectedRadioButtonContent;

            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(group))
            {
                using (var context = new DataContext())
                {
                    var newEntry = new User
                    {
                        Name = name,
                        Group = group
                    };

                    context.User.Add(newEntry);
                    context.SaveChanges();
                }

                text_name.Text = string.Empty;
                selectedRadioButtonContent = string.Empty;
            }
            else
            {
                MessageBox.Show("Name and Group cannot be empty.");
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new DataContext())
            {
                var group1Users = context.User.Where(u => u.Group == "Muisje").ToList();
                var group2Users = context.User.Where(u => u.Group == "Minikikker").ToList();
                var group3Users = context.User.Where(u => u.Group == "Maxikikker").ToList();

                DisplayGroupData("Muisjes", group1Users);
                DisplayGroupData("Minikikkers", group2Users);
                DisplayGroupData("Maxikikkers", group3Users);
            }
        }

        private void DisplayGroupData(string groupName, List<User> users)
        {
            if (users.Any())
            {
                StringBuilder message = new StringBuilder();
                foreach (var user in users)
                {
                    message.AppendLine($"{user.Name}");
                }

                MessageBox.Show(message.ToString(), groupName);
            }
            else
            {
                MessageBox.Show($"No data found for {groupName}", groupName);
            }
        }
    }
}

using DevCitySim.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DevCitySim
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>

    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            using (var db = new AppDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }

            LoadCitizens();
        }

        // Search functionality based on job
        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadCitizens();
        }

        // Load citizens and display as buttons
        private void LoadCitizens()
        {
            using (var db = new AppDbContext())
            {
                //var citizens = db.Citizens
                //    .Include(c => c.Buildings)
                //    .Where(c => c.Job.Contains(searchBox.Text))
                //    .ToList();

                var citizens = db.Citizens
                    .Where(c => c.Job.Contains(searchBox.Text))
                    .ToList();

                citizenList.Children.Clear();

                foreach (var citizen in citizens)
                {
                    var button = new Button
                    {
                        Content = $"{citizen.Name} - {citizen.Job}",
                        Tag = citizen.Id
                    };
                    button.Click += (s, e) => OpenCitizenDetailWindow((int)button.Tag);
                    citizenList.Children.Add(button);
                }
            }
        }

        // Open the BuildingCitizenView window with citizen details
        private void OpenCitizenDetailWindow(int citizenId)
        {
            using (var db = new AppDbContext()) 
            {
                var citizen = db.Citizens.FirstOrDefault(c => c.Id == citizenId);

                db.Entry(citizen)
                    .Collection(c => c.Buildings)
                    .Load();

                var detailWindow = new BuildingCitizenView(citizenId);
                detailWindow.Activate();
            }
        }
    }
}

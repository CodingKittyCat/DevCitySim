using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using DevCitySim.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DevCitySim
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BuildingCitizenView : Window
    {
        private int citizenId;

        public BuildingCitizenView(int citizenId)
        {
            this.InitializeComponent();
            this.citizenId = citizenId;
            LoadCitizenData();
        }

        private void LoadCitizenData()
        {
            using (var db = new AppDbContext())
            {
                var citizen = db.Citizens
                    .Include(c => c.Buildings)
                    .FirstOrDefault(c => c.Id == citizenId);


                    citizenName.Text = citizen.Name;
                    citizenJob.Text = $"Profession: {citizen.Job}";

                    buildingList.Children.Clear();
                    foreach (var building in citizen.Buildings)
                    {
                        TextBlock buildingText = new TextBlock
                        {
                            Text = $"{building.Name} - {building.Type} located at {building.Location}"
                        };
                        buildingList.Children.Add(buildingText);
                    }
            }
        }
    }
}

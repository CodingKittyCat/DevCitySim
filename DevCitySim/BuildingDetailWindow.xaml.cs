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
    public sealed partial class BuildingDetailWindow : Window
    {
        private int buildingId;

        public BuildingDetailWindow(int buildingId)
        {
            this.InitializeComponent();
            this.buildingId = buildingId;
            LoadBuildingDetails();
        }

        private void LoadBuildingDetails()
        {
            using (var db = new AppDbContext())
            {
                var building = db.Buildings
                            .Include(b => b.CitizenBuildings)
                            .ThenInclude(cb => cb.Citizen)
                            .FirstOrDefault(c => c.Id == buildingId);

                buildingName.Text = building.Name;
                buildingType.Text = $"Type: {building.Type}";
                buildingLocation.Text = $"Location: {building.Location}";

                citizenList.Children.Clear();

                foreach (var citizenBuilding in building.CitizenBuildings)
                {
                    var citizen = citizenBuilding.Citizen;
                    var textBlock = new TextBlock
                    {
                        Text = $"{citizen.Name} - {citizen.Job}"
                    };
                    citizenList.Children.Add(textBlock);
                }
            }
        }
    }

}

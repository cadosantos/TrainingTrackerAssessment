using Mapsui;
using System.Windows;

namespace Client.Views
{
    /// <summary>
    /// Interaction logic for SoldierMapControl.xaml
    /// </summary>
    public partial class SoldierMapControlView : Window
    {
        public SoldierMapControlView()
        {
            InitializeComponent();

            MapControl.Map.Navigator.RotationLock = false;
            MapControl.Map.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());

            //MapControl.Map.Navigator.FlyTo(new MPoint(100, 200), 500); //TODO find a way to set positions
        }
    }
}
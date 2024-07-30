using Client.Installers;
using Client.Models;
using Domain.EF;
using Domain.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    public class SoldierPositionViewModel
    {
        public SoldierPositionViewModel()
        {
            SoldierPositions = new ObservableCollection<SoldierPositionModel>();
            
            SaveJsonDataAsync() //TODO this is a temporary solution to populate the database with data
                .ContinueWith(task => LoadSoldierPositions());
        }

        private void LoadSoldierPositions()
        {
            SoldierPositions.Clear();
            DependencyInjectionHelper.SoldierMovementRepository.GetAllSoldiersPositions()
                .ToList()
                .ForEach(position => SoldierPositions.Add(new SoldierPositionModel(position.SoldierName, position.Longitude, position.Latitude)));
        }

        public ObservableCollection<SoldierPositionModel> SoldierPositions { get; set; }

        private async Task SaveJsonDataAsync()
        {
            try
            {
                //TODO because it is a temporary solution, it cannot be run twice, otherwise we would be trying to insert the same data again

                TrainingTrackerAssessmentEntities dbContext = TrainingTrackerAssessmentEntitiesHelper.OpenConnection();
                dbContext.Countries.AddRange(LoadJsonData<Country>());
                dbContext.Ranks.AddRange(LoadJsonData<Rank>());
                dbContext.SensorManufacturers.AddRange(LoadJsonData<SensorManufacturer>());
                dbContext.SensorTypes.AddRange(LoadJsonData<SensorType>());
                dbContext.Sensors.AddRange(LoadJsonData<Sensor>());
                dbContext.Soldiers.AddRange(LoadJsonData<Soldier>());
                dbContext.MapPositions.AddRange(LoadJsonData<MapPosition>());

                await dbContext.SaveChangesAsync();
            }
            finally
            {
                TrainingTrackerAssessmentEntitiesHelper.CloseConnection();
            }
        }

        private static List<T> LoadJsonData<T>()
        {
            return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText($".\\DatabaseJson\\{typeof(T).Name}.json"));
        }
    }
}
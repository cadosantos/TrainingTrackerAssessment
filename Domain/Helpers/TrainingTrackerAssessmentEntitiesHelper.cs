using Domain.EF;

namespace Domain.Helpers
{
    public class TrainingTrackerAssessmentEntitiesHelper
    {
        public static TrainingTrackerAssessmentEntities OpenConnection()
        {
            Instance.Database.Connection.Open();
            return Instance;
        }

        public static void CloseConnection()
        {
            if (Instance.Database.Connection.State != System.Data.ConnectionState.Closed)
                Instance.Database.Connection.Close();
        }

        private static TrainingTrackerAssessmentEntities _instance;
        private static TrainingTrackerAssessmentEntities Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TrainingTrackerAssessmentEntities();
                }

                return _instance;
            }
        }
    }
}
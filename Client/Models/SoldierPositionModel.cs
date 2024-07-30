using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Client.Models
{
    public class SoldierPositionModel : INotifyPropertyChanged
    {
        public SoldierPositionModel(string soldierName, decimal longitude, decimal latitude)
            : this(soldierName, longitude, latitude, "")
        {
        }

        public SoldierPositionModel(string soldierName, decimal longitude, decimal latitude, string trainingInfo)
        {
            SoldierName = soldierName;
            Longitude = longitude;
            Latitude = latitude;
            TrainingInfo = trainingInfo;
        }

        private string _soldierName;
        public string SoldierName
        {
            get => _soldierName;
            set
            {
                if (_soldierName != value)
                {
                    _soldierName = value;
                    NotifyChanged(() => SoldierName);
                }
            }
        }

        private decimal _longitude;
        public decimal Longitude
        {
            get => _longitude;
            set
            {
                if (_longitude != value)
                {
                    _longitude = value;
                    NotifyChanged(() => Longitude);
                }
            }
        }

        private decimal _latitude;
        public decimal Latitude
        {
            get => _latitude;
            set
            {
                if (_latitude != value)
                {
                    _latitude = value;
                    NotifyChanged(() => Latitude);
                }
            }
        }

        private string _trainingInfo;
        public string TrainingInfo
        {
            get => _trainingInfo;
            set
            {
                if (_trainingInfo != value)
                {
                    _trainingInfo = value;
                    NotifyChanged(() => TrainingInfo);
                }
            }
        }

        // TODO this method should be moved to a shared class
        protected void NotifyChanged<T>(Expression<Func<T>> property)
        {
            if (property.Body.NodeType == ExpressionType.MemberAccess)
            {
                var expression = (MemberExpression)property.Body;
                OnPropertyChanged(expression.Member.Name);
            }
            else
            {
                throw new ArgumentException(property.ToString());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
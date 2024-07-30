using System;

namespace Domain.Exceptions
{
    public class MapPositionNotFoundException : Exception
    {
        public MapPositionNotFoundException()
            : base("Soldier has no tracking yet")
        {
        }
    }
}
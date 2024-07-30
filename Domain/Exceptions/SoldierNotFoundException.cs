using System;

namespace Domain.Exceptions
{
    public class SoldierNotFoundException : Exception
    {
        public SoldierNotFoundException()
            : base("Soldier not found")
        {
        }
    }
}
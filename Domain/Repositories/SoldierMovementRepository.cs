using Domain.Dtos;
using Domain.EF;
using Domain.Exceptions;
using Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Repositories
{
    public class SoldierMovementRepository : ISoldierMovementRepository
    {
        public SoldierPositionDto GetCurrentPosition(Guid soldierId)
        {
            try
            {
                TrainingTrackerAssessmentEntities dbContext = TrainingTrackerAssessmentEntitiesHelper.OpenConnection();

                var soldier = dbContext.Soldiers
                    .SingleOrDefault(s => s.Id == soldierId);

                if (soldier == null)
                    throw new SoldierNotFoundException();

                var lastMapPosition = dbContext.MapPositions
                    .Where(mp => mp.SoldierId == soldierId)
                    .OrderByDescending(mp => mp.CreatedDate)
                    .FirstOrDefault();

                if (lastMapPosition == null)
                    throw new MapPositionNotFoundException();

                return new SoldierPositionDto(soldier.Name, lastMapPosition.Longitude, lastMapPosition.Latitude);
            }
            finally
            {
                TrainingTrackerAssessmentEntitiesHelper.CloseConnection();
            }
        }

        public IList<SoldierPositionDto> GetAllSoldiersPositions()
        {
            try
            {
                TrainingTrackerAssessmentEntities dbContext = TrainingTrackerAssessmentEntitiesHelper.OpenConnection();
                
                var mapPositions = dbContext.MapPositions.ToList(); // TODO it could be paginated for performance reasons

                return mapPositions
                    .Select(position => new SoldierPositionDto(position.Soldier.Name, position.Longitude, position.Latitude))
                    .ToList();
            }
            finally
            {
                TrainingTrackerAssessmentEntitiesHelper.CloseConnection();
            }
        }
    }
}
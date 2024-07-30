using Domain.Dtos;
using System;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface ISoldierMovementRepository
    {
        SoldierPositionDto GetCurrentPosition(Guid soldierId);
        IList<SoldierPositionDto> GetAllSoldiersPositions();
    }
}
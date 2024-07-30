namespace Client.Installers
{
    public static class DependencyInjectionHelper
    {
        //TODO this should be using a DI container, but for simplicity I will instantiate the concrete classes here
        public static Domain.Repositories.ISoldierMovementRepository SoldierMovementRepository => new Domain.Repositories.SoldierMovementRepository();
    }
}
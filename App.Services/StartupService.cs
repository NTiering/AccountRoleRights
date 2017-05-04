namespace App.Services
{
    using App.Contracts.Services;
    using Dals;

    class StartupService : IStartupService
    {
        IStartupDal startupDal;

        public StartupService(IStartupDal startupDal)
        {
            this.startupDal = startupDal; 
        }
        /// <summary>
        /// Called when App starts up
        /// </summary>
        public void Startup()
        {
            startupDal.Statup();
            // add any start up code here
        }
    }
}

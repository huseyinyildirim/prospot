using System.ServiceProcess;

namespace IntegrationDelete
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
            InitializeScheduler();
        }

        private void InitializeScheduler()
        {
            Scheduler oScheduler = new Scheduler();
            oScheduler.Start();
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
}

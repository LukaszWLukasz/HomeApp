namespace HomeApp
{
    public class FamilyInMemory : FamilyBase
    {
        public override event PointAddedDelegate PointAdded;

        private List<double> points = new List<double>();
        public FamilyInMemory(string name, string surname) :
            base(name, surname)
        {
        }
        public override void AddPoint(double point)
        {
            if (point >= -10 & point <= 10)
            {
                this.points.Add(point);

                if (PointAdded != null)
                {
                    PointAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException("Invalid point value");
            }
        }
        public override StatisticsApp GetStatisticsApp()
        {
            var statisticsApp = new StatisticsApp();
            {
                foreach (var point in this.points)
                {
                    statisticsApp.AddPoint(point);
                }
            }
            return statisticsApp;
        }
    }
}

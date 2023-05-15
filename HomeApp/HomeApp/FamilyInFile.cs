using System.Reflection.Metadata.Ecma335;

namespace HomeApp
{
    public class FamilyInFile : FamilyBase
    {
        public override event PointAddedDelegate PointAdded;

        private const string fileName = "points.txt";
        public FamilyInFile(string name, string surname) :
            base(name, surname)
        {
        }
        public override void AddPoint(double point)
        {
            if (point >= -10 && point <= 10)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(point);

                    if (PointAdded != null)
                    {
                        PointAdded(this, new EventArgs());
                    }
                }
            }
            else
            {
                throw new ArgumentException("Invalid point value, only points from 0 to 10 or letter A-E");
            }
        }
        public override StatisticsApp GetStatisticsApp()
        {
            var pointsFromFile = this.ReadPointsFromFile();
            var result = this.CountStatistics(pointsFromFile);
            return result;
        }
        private List<double> ReadPointsFromFile()
        {
            var points = new List<double>();
            if (File.Exists($"{fileName}"))
            {
                using (var reader = File.OpenText($"{fileName}"))
                {
                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        var number = double.Parse(line);
                        points.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return points;
        }
        public StatisticsApp CountStatistics(List<double> points)
        {
            var statisticsApp = new StatisticsApp();
            foreach (var point in points)
            {
                statisticsApp.AddPoint(point);
            }
            return statisticsApp;
        }
    }
}

namespace HomeApp
{
    public abstract class FamilyMemberBase : IFamilyMember
    {
        public delegate void PointAddedDelegate(object sender, EventArgs args);


        public abstract event PointAddedDelegate PointAdded;

        public FamilyMemberBase(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public abstract void AddPoint(double point);

        public void AddPoint(float point)
        {
            var floatAsDouble = (double)point;
            this.AddPoint(floatAsDouble);
        }

        public void AddPoint(int point)
        {
            var floatAsDouble = (double)point;
            this.AddPoint(floatAsDouble);
        }

        public void AddPoint(string point)
        {
            if (double.TryParse(point, out double result))
            {
                this.AddPoint(result);
            }
            else if (char.TryParse(point, out char charResult))
            {
                AddPoint(charResult);
            }
            else
            {
                throw new ArgumentException("Invalid point value, only points from -10 to 10 or letter A-E");
            }
        }

        public void AddPoint(char point)
        {
            switch (point)
            {
                case 'A':
                case 'a':
                    this.AddPoint(10);
                    break;
                case 'B':
                case 'b':
                    this.AddPoint(8);
                    break;
                case 'C':
                case 'c':
                    this.AddPoint(6);
                    break;
                case 'D':
                case 'd':
                    this.AddPoint(4);
                    break;
                case 'E':
                case 'e':
                    this.AddPoint(2);
                    break;
                default:
                    throw new ArgumentException("Invalid point value, only scores from -10 to 10 or letter A-E");
            }
        }
        public abstract StatisticsApp GetStatisticsApp();

        public void ShowStatisticsApp()
        {
            var statistics = GetStatisticsApp();
            if (statistics.Count != 0)
            {
                Console.WriteLine($"Member {Name} {Surname} Min point: {statistics.Min}");
                Console.WriteLine($"Member {Name} {Surname} Max point: {statistics.Max}");
                Console.WriteLine($"Member {Name} {Surname} Sum point: {statistics.Sum}");
                Console.WriteLine($"Member {Name} {Surname} Count point: {statistics.Count}");
            }
        }
    }
}

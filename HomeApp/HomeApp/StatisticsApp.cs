namespace HomeApp
{
    public class StatisticsApp
    {
        public double Max;
        public double Min;
        public double Sum;
        public double Count;
        public double Average
        {
            get
            {
                return this.Sum / this.Count;
            }
        }
        public StatisticsApp()
        {
            Count = 0;
            Sum = 0;
            Max = double.MinValue;
            Min = double.MaxValue;
        }
        public void AddPoint(double point)
        {
            Sum += point;
            Count++;
            Max = Math.Max(point, Max);
            Min = Math.Min(point, Min);
        }
    }
}

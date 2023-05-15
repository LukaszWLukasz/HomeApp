using static HomeApp.FamilyBase;

namespace HomeApp
{
    public interface IFamily
    {
        string Name { get; }
        string Surname { get; }
        void AddPoint(double point);
        void AddPoint(float point);
        void AddPoint(int point);
        void AddPoint(string point);
        void AddPoint(char point);
        event PointAddedDelegate PointAdded;
        public StatisticsApp GetStatisticsApp();
    }
}

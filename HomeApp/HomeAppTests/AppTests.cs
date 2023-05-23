using HomeApp;

namespace HomeAppTests
{
    public class Tests
    {
        [Test]
        public void TestAddPointsFamilyInMemory_Sum_Count_Max_Min()
        {
            var member = new FamilyMemberInMemory("£ukasz", "Walczak");

            member.AddPoint(5);
            member.AddPoint(4.5);
            member.AddPoint("A");
            member.AddPoint('B');
            

            var result = member.GetStatisticsApp();

            Assert.AreEqual(27.5M, result.Sum);
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(10, result.Max);
            Assert.AreEqual(4.5, result.Min);
        }
    }
}
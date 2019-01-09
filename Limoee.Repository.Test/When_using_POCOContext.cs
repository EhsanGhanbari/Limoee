using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Limoee.Repository.Test
{
    [TestClass()]
    public class WhenUsingPocoContext
    {
        [TestMethod()]
        public void Should_be_able_to_create_POCOContext_database()
        {
            var target = new LimoeeDataContext();
            target.Database.Initialize(true);
        }
    }
}
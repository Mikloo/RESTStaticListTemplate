using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTStaticListTemplate;
using RESTStaticListTemplate.Controllers;

namespace UnitTestSLTemp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AmountOfObj()
        {
            SLTempsController slTemps = new SLTempsController();

            List<SLTemp> slTempsList = slTemps.GetList();

            Assert.AreEqual(2, slTempsList.Count);
        }

        [TestMethod]
        public void GetById()
        {
            SLTempsController slTemps = new SLTempsController();

            SLTemp sl = slTemps.GetById(0);

            Assert.AreEqual("Mikail", sl.FirstName);
        }

        [TestMethod]
        public void GetByIdNull()
        {
            SLTempsController slTemps = new SLTempsController();

            SLTemp sl = slTemps.GetById(10);

            Assert.IsNull(sl);
        }

        [TestMethod]
        public void TestDelete()
        {
            SLTempsController slTemps = new SLTempsController();

            List<SLTemp> slTempsList = slTemps.GetList();

            int preCount = slTempsList.Count;

            bool c1 = slTemps.DeleteSLTemp(1);

            List<SLTemp> slTempsList2 = slTemps.GetList();

            Assert.AreEqual(preCount - 1, slTempsList2.Count);
        }

        [TestMethod]
        public void TestMethodUpdate()
        {
            CustomerController cc = new CustomerController();
            Customer c = cc.GetCustomer(0);
            c.FirstName = c.FirstName + "1";
            Customer x = cc.UpdateCustomer(0, c);
            Assert.AreEqual(x.FirstName, c.FirstName);

            Customer c1 = new Customer("NewFirst", "NewLast", c.Year + 1);
            Customer y = cc.UpdateCustomer(0, c1);
            Assert.AreEqual(y.FirstName, c.FirstName);

            Customer z = cc.UpdateCustomer(17, c1);
            Assert.IsNull(z);

        }
    }
}

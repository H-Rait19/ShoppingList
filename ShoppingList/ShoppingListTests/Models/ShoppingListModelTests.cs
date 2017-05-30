using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingList.Models;

namespace ShoppingListTests.Models
{
    [TestClass()]
    public class ShoppingListModelTests
    {
        [TestMethod]
        public void AddItemTestShouldReturnFalse()
        {
            ShoppingListModel slm = new ShoppingListModel();
            var res = slm.AddItem("", 1);
            Assert.IsFalse(res);

            res = slm.AddItem("abc", 0);
            Assert.IsFalse(res);

            res = slm.AddItem("pepsi", 4);

            res = slm.AddItem("pepsi", 6);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void AddItemTestShouldReturnTrue()
        {
            ShoppingListModel slm = new ShoppingListModel();
            var res = slm.AddItem("sdd", 4);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void UpdateItemTestShouldReturnFalse()
        {
            ShoppingListModel slm = new ShoppingListModel();
            var res = slm.UpdateQuantity("", 1);
            Assert.IsFalse(res);

            res = slm.UpdateQuantity("fgh", 0);
            Assert.IsFalse(res); 
        }

        [TestMethod]
        public void UpdateItemTestShouldReturnTrue()
        {
            ShoppingListModel slm = new ShoppingListModel();
            var res = slm.AddItem("abc", 1);

            res = slm.UpdateQuantity("abc", 99);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void DeleteItemTestShouldReturnFalse()
        {
            ShoppingListModel slm = new ShoppingListModel();
            var res = slm.RemoveItem("jjj");
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void DeleteItemTestShouldReturnTrue()
        {
            int quant = 12;
            ShoppingListModel slm = new ShoppingListModel();
            var res = slm.AddItem("lll", quant);
            Assert.IsTrue(res);

            res = slm.RemoveItem("lll");
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void GetItemQuantityTestShouldReturnZero()
        {
            int quant = 0;
            ShoppingListModel slm = new ShoppingListModel();
            var res = slm.GetQuantity("lmn");
            Assert.AreEqual(res, quant);

            res = slm.GetQuantity("");
            Assert.AreEqual(res, quant);
        }

        [TestMethod]
        public void GetItemQuantityTestShouldReturnQuantity()
        {
            int quant = 78;
            ShoppingListModel slm = new ShoppingListModel();
            var res = slm.AddItem("qqq", quant);
            Assert.IsTrue(res);

            var resTwo = slm.GetQuantity("qqq");
            Assert.AreEqual(quant, resTwo);
        }

        [TestMethod]
        public void GetAllItemsTestShouldReturnListOfInputItems()
        {
            ShoppingListModel slm = new ShoppingListModel();
            var res = slm.AddItem("hjk", 78);
            Assert.IsTrue(res);
            res = slm.AddItem("xyz", 22);
            Assert.IsTrue(res);

            var resTwo = slm.GetAllListItems();
            Assert.IsTrue(resTwo.Count > 0);

            var check = resTwo.Any(x => x.Name == "hjk" && x.Quantity == 78);
            Assert.IsTrue(check);

            check = resTwo.Any(x => x.Name == "xyz" && x.Quantity == 22);
            Assert.IsTrue(check);
        }

    }
}
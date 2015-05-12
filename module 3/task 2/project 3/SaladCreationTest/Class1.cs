using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaladCreation;
using SaladCreation.Vegetables;
using System.IO;


namespace SaladCreationTest
{
    [TestFixture]
    public class SaladTestClass
    {
        Salad salad = new Salad();
        List<Vegetable> SaladCollection = new List<Vegetable>();

        [SetUp]
        public void Create()
        {
            Vegetable cabbage = new Cabbage(100, 24, "1 year");
            SaladCollection.Add(cabbage);

            Vegetable cucumber = new Cucumber(50, 15, "1 year");
            SaladCollection.Add(cucumber);

            Vegetable sweetpepper = new SweetPepper(100, 50, "1 year");
            SaladCollection.Add(sweetpepper);

            Vegetable tomato = new Tomato(150, 25, "1 year");
            SaladCollection.Add(tomato);

            Vegetable potato = new Potato(200, 45, "Greenhouse type");
            SaladCollection.Add(potato);
        }

        [Test, Timeout(2000)]
        [Category("Smoke")]
        public void SaladTypeTest()
        {
            Cucumber cucumber = new Cucumber(50, 15, "1 year");
            Assert.IsInstanceOf(typeof(Cucumber), cucumber);

        }

        [Test, Timeout(2000)]
        [Category("Smoke")]
        public void SaladToStringTest()
        {
            string result = salad.ToString();

            StringAssert.IsMatch(result, "Salad contains: \nCabbage has the following weight:100, calorific index:24 and lifespan:1 year;\nCucumber has the following weight:50, calorific index:15 and lifespan:1 year;\nSweet Pepper has the following weight:100, calorific index:50 and lifespan:1 year;\nTomato has the following weight:150, calorific index:25 and lifespan:1 year;\nPotato has the following weight:200, calorific index:45 and ingathering type:Greenhouse type.");
        }

        [Test]
        [Category("Extended")]
        public void SaladCollectionCreationTest()
        {
            Assert.IsNotEmpty(SaladCollection);
            Console.WriteLine("Collection contains some objects and hence is not empty.");
        }

        [Test]
        [Category("Extended")]
        public void CollectionContainsAnObjectTest()
        {
            Potato potato = new Potato(200, 45, "Greenhouse type");
            Assert.Contains(potato, SaladCollection);
            Console.WriteLine("Collection contains Potato object.");
        }

        [Test]
        [Category("Extended")]
        public void SameObjectsTest()
        {
            Potato potato = new Potato(200, 45, "Greenhouse type");
            Cabbage cabbage = new Cabbage(100, 24, "1 year");
            Assert.AreNotSame(potato, cabbage);
            Console.WriteLine("Objects are not the same.");
        }

        [Test]
        [Category("Negative test")]
        [Ignore("Not ready!")]
        public void NegativeTest()
        {
            
        }

        [Test]
        [Category("Exception Test")]
        [Ignore("Not ready!")]
        public void ExceptionTest()
        {
            
        }

        [Test]
        [Ignore("Not ready!")]
        public void SaladSortTest()
        {
            salad.Sort();
        }

       
    }
}

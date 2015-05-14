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
            Salad salad = new Salad();
            string result = salad.ToString();

            StringAssert.IsMatch(result, "Salad contains: \nCabbage has the following weight:100, calorific index:24 and lifespan:1 year;\nCucumber has the following weight:50, calorific index:15 and lifespan:1 year;\nSweet Pepper has the following weight:100, calorific index:50 and lifespan:1 year;\nTomato has the following weight:150, calorific index:25 and lifespan:1 year;\nPotato has the following weight:200, calorific index:45 and ingathering type:Greenhouse type.");
        }

        [Test]
        [Category("Extended")]
        public void SaladCollectionCreationTest()
        {
            Salad salad = new Salad();
            salad.Add(new Cabbage(100, 24, "1 year"));
            salad.Add(new Cucumber(50, 15, "1 year"));
            salad.Add(new SweetPepper(100, 50, "1 year"));
            salad.Add(new Tomato(150, 25, "1 year"));
            salad.Add(new Potato(200, 45, "Greenhouse type"));
            Assert.IsNotEmpty(salad.SaladCollection);
            Console.WriteLine("Collection contains some objects and hence is not empty.");
        }

        [Test]
        [Category("Extended")]
        public void CollectionContainsAnObjectTest()
        {
            Salad salad = new Salad();
            Vegetable potato = new Potato(200, 45, "Greenhouse type");
            salad.Add(potato);
            Assert.Contains(potato, salad.SaladCollection);
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
        public void ExceptionTest()
        {
            var salad = new Salad();
            Vegetable cabbage = new Cabbage(100, 24, "1 year");
            salad.Add(cabbage);

            Assert.Throws(typeof(Exception), () => salad.Add(cabbage));
        }

        [Test]
        [Ignore("Not ready!")]
        public void SaladSortTest()
        {
            Salad salad = new Salad();
            salad.Sort();
        }

       
    }
}

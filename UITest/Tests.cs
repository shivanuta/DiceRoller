using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest
{
    [TestFixture(Platform.Android)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        [Category("UI")]
        public void PromptLabelIsDisplayed()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Select a die:"));
            

            Assert.IsTrue(results.Any());
        }

        [Test]
        [Category("UI")]
        public void OptionAreDisplayed()
        {
            Assert.IsTrue(app.Query(c => c.Marked("d4")).Any());
            Assert.IsTrue(app.Query(c => c.Marked("d6")).Any());
            Assert.IsTrue(app.Query(c => c.Marked("d8")).Any());
            Assert.IsTrue(app.Query(c => c.Marked("d10")).Any());
            Assert.IsTrue(app.Query(c => c.Marked("d12")).Any());
            Assert.IsTrue(app.Query(c => c.Marked("d20")).Any());
        }
        [Test]
        [Category("UI")]
        public void OptionCanBeChecked()
        {
            app.Tap(c => c.Marked("d4"));

            Assert.IsTrue(app.Query(c =>
            c.Marked("d4")// look for items marked d4
            .Invoke("isChecked"))// call the isChecked method of the RadioButton
            .FirstOrDefault()//get the first result (there should only be one)
            .Equals(true));// check that the view is checked (isChecked = true)
        
        
            app.Tap(c => c.Marked("d6"));

            Assert.IsTrue(app.Query(c =>
            c.Marked("d6")// look for items marked d6
            .Invoke("isChecked"))// call the isChecked method of the RadioButton
            .FirstOrDefault()//get the first result (there should only be one)
            .Equals(true));// check that the view is checked (isChecked = true)

            app.Tap(c => c.Marked("d8"));

            Assert.IsTrue(app.Query(c =>
            c.Marked("d8")// look for items marked d8
            .Invoke("isChecked"))// call the isChecked method of the RadioButton
            .FirstOrDefault()//get the first result (there should only be one)
            .Equals(true));// check that the view is checked (isChecked = true)

            app.Tap(c => c.Marked("d10"));

            Assert.IsTrue(app.Query(c =>
            c.Marked("d10")// look for items marked d10
            .Invoke("isChecked"))// call the isChecked method of the RadioButton
            .FirstOrDefault()//get the first result (there should only be one)
            .Equals(true));// check that the view is checked (isChecked = true)

            app.Tap(c => c.Marked("d12"));

            Assert.IsTrue(app.Query(c =>
            c.Marked("d12")// look for items marked d12
            .Invoke("isChecked"))// call the isChecked method of the RadioButton
            .FirstOrDefault()//get the first result (there should only be one)
            .Equals(true));// check that the view is checked (isChecked = true)

            app.Tap(c => c.Marked("d20"));

            Assert.IsTrue(app.Query(c =>
            c.Marked("d20")// look for items marked d20
            .Invoke("isChecked"))// call the isChecked method of the RadioButton
            .FirstOrDefault()//get the first result (there should only be one)
            .Equals(true));// check that the view is checked (isChecked = true)
        }
        [Test]
        [Category("UI")]
        public void RollButtonAreDisplayed()
        {
            AppResult[] results = app.Query(c => c.Property("text").Like("Display * results*"));
            Assert.IsTrue(results.Length == 2);
        }
    }
}

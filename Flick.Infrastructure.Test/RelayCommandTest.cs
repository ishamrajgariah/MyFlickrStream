using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlickrStream.Infrastructure.Test
{
    [TestClass]
    public class RelayCommandTest
    {
        [TestMethod]
        public void RelayCommand_CanExecuteTest()
        {
            RelayCommand command = new RelayCommand(null, true);

            Assert.IsTrue(command.CanExecute(null));
        }

        [TestMethod]
        public void RelayCommand_ExecuteTest()
        {
            string testString = string.Empty;
            RelayCommand command = new RelayCommand(() => { testString = "updated"; }, true);

            command.Execute(null);

            Assert.AreEqual("updated", testString);
        }
    }
}

using System;
using NUnit.Framework;
using ToDoListApplication.Domain.Controller;

#pragma warning disable CA1707

namespace ToDoListApplication.Tests
{
    /// <summary>
    /// Testing ToDoList App.
    /// </summary>
    [TestFixture]
    public class ToDoListApplicationsTests
    {
        private IDbDataContext app;

        /// <summary>
        /// Setup part.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.app = new DbDataContext();
        }

        /// <summary>
        /// AddList throws Argument Null Exception when parameter is null.
        /// </summary>
        [Test]
        public void AddList_ThrowsNullException_ValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.app.AddList(null));
        }

        /// <summary>
        /// AddToDo throws Argument Null Exception when parameter is null.
        /// </summary>
        [Test]
        public void AddToDo_ThrowsNullException_ValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.app.AddToDo(null));
        }

        /// <summary>
        /// ReadList throws Argument Null Exception when parameter is null.
        /// </summary>
        [Test]
        public void ReadList_ThrowsNullException_ValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.app.ReadList(null));
        }

        /// <summary>
        /// ReadToDos throws Argument Null Exception when parameter is null.
        /// </summary>
        [Test]
        public void ReadToDos_ThrowsNullException_ValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.app.ReadToDos(null));
        }

        /// <summary>
        /// RemoveList throws Argument Null Exception when parameter is null.
        /// </summary>
        [Test]
        public void RemoveList_ThrowsNullException_ValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.app.ReadToDos(null));
        }

        /// <summary>
        /// RemoveToDo throws Argument Null Exception when parameter is null.
        /// </summary>
        [Test]
        public void RemoveToDo_ThrowsNullException_ValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.app.RemoveToDo(null));
        }

        /// <summary>
        /// UpdateList throws Argument Null Exception when parameter is null.
        /// </summary>
        [Test]
        public void UpdateList_ThrowsNullException_ValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.app.UpdateList(null));
        }

        /// <summary>
        /// UpdateToDo throws Argument Null Exception when parameter is null.
        /// </summary>
        [Test]
        public void UpdateToDo_ThrowsNullException_ValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.app.UpdateToDo(null));
        }
    }
}

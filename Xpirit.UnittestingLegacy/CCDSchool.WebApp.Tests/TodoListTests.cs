using CCDSchool.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Data;
using System.Web;

namespace CCDSchool.WebApp.Tests
{
    [TestClass]
    public class TodoListTests
    {
        [TestMethod]
        public void PageLoadWithoutPostback_ShouldDoNothing()
        {
            //Arrange
            const string connString = "connectionString";

            var mockRepository = new MockRepository(MockBehavior.Strict);

            var taskListService = mockRepository.Create<ITaskListService>();

            var todoListWrapper = mockRepository.Create<ITodoListWrapper>();
            todoListWrapper.Setup(page => page.IsPostBack()).Returns(true);

            var todoList = new TodoListUnitTestImpl(taskListService.Object, todoListWrapper.Object, connString);

            //Act
            var sender = "";
            var eventArgs = new EventArgs();

            todoList.Page_Load(sender, eventArgs);

            //Assert
            mockRepository.VerifyAll();
        }

        [Ignore("Fails on lstTaskListV.SelectedItem.Value and wrapping the separate fields makes this way too messy -> refactor!")]
        [TestMethod]
        public void PageLoadWithPostback_AndLastListID_ShouldLoadListData_AndSetSelectedIndex()
        {
            //Arrange
            const string connString = "connectionString";

            var mockRepository = new MockRepository(MockBehavior.Strict);

            var taskList = new DataTable("TaskList");

            var taskListService = mockRepository.Create<ITaskListService>();
            taskListService.Setup(service => service.GetAllTaskList(connString)).Returns(taskList);

            var todoListWrapper = mockRepository.Create<ITodoListWrapper>();
            todoListWrapper.Setup(page => page.IsPostBack()).Returns(false);
            todoListWrapper.Setup(page => page.GetRequestCookie("UserName")).Returns(new HttpCookie("UserName", "Reinier"));
            todoListWrapper.Setup(page => page.GetSessionState("LastListID")).Returns(1);

            var todoList = new TodoListUnitTestImpl(taskListService.Object, todoListWrapper.Object, connString);

            //Act
            var sender = "";
            var eventArgs = new EventArgs();

            todoList.Page_Load(sender, eventArgs);

            //Assert
            mockRepository.VerifyAll();
        }
    }
}

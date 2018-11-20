using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Data;
using System.Globalization;

namespace CCDSchool.Business.Tests
{
    [TestClass]
    public class TaskListServiceTests
    {
        [TestMethod]
        public void GetAllTaskList_Should_ExecuteCorrectQuery()
        {
            //Arrange
            const string query = "SELECT *,(SELECT COUNT(*) FROM ToDoListTask WHERE ToDoListId=a.Id AND Archieved=0) as count FROM (SELECT Id,Title from ToDoList) a";
            const string connString = "connString";
            const string tableName = "GetAllTaskList_Should_ExecuteCorrectQuery";

            var dataTable = new DataTable(tableName);

            var sqlLiteHelper = new Mock<ISqlLiteHelper>(MockBehavior.Strict);
            sqlLiteHelper.Setup(helper => helper.ExecuteQuery(query, connString)).Returns(dataTable);

            var taskListService = new TaskListService(sqlLiteHelper.Object);

            //Act
            var allTaskList = taskListService.GetAllTaskList(connString);

            //Assert
            allTaskList.Should().NotBeNull();
            allTaskList.TableName.Should().Be(tableName);

            Mock.Verify(sqlLiteHelper);
        }

        [TestMethod]
        public void UpdateTask_WithDueDate_Should_ExcecuteCorrectQuery()
        {
            //Arrange
            const int taskId = 1;
            const string title = "title";
            const string description = "description";
            const int important = 0;
            const string duedate = "08-12-1984";
            const string connString = "connString";

            var ci = new CultureInfo("de-de");
            var germanDueDate = DateTime.Parse(duedate, ci);

            var query = $"Update ToDoListTask  SET Title='{title}',Description='{description}',Important={important},DueDate='{germanDueDate.ToString("yyyy-MM-dd HH:mm")}' WHERE Id={taskId}";

            var sqlLiteHelper = new Mock<ISqlLiteHelper>(MockBehavior.Strict);
            sqlLiteHelper.Setup(helper => helper.ExecutegeneralQuery(query, connString));

            var taskListService = new TaskListService(sqlLiteHelper.Object);

            //Act
            taskListService.UpdateTask(taskId, title, description, important, duedate, connString);

            //Assert
            Mock.Verify(sqlLiteHelper);
        }

        [TestMethod]
        public void UpdateTask_WithNullDueDate_Should_Crash()
        {
            //Arrange
            const int taskId = 1;
            const string title = "title";
            const string description = "description";
            const int important = 0;
            const string duedate = null;
            const string connString = "connString";

            var sqlLiteHelper = new Mock<ISqlLiteHelper>(MockBehavior.Strict);

            var taskListService = new TaskListService(sqlLiteHelper.Object);

            //Act
            Action codeThatShouldCrash = () => taskListService.UpdateTask(taskId, title, description, important, duedate, connString);

            //Assert
            codeThatShouldCrash.Should().ThrowExactly<ArgumentNullException>();

            Mock.Verify(sqlLiteHelper);
        }

        [TestMethod]
        public void UpdateTask_WithoutDueDate_Should_ExcecuteCorrectQuery()
        {
            //Arrange
            const int taskId = 1;
            const string title = "title";
            const string description = "description";
            const int important = 0;
            const string duedate = "";
            const string connString = "connString";

            var query = $"Update ToDoListTask  SET Title='{title}',Description='{description}',Important={important},DueDate=null WHERE Id={taskId}";

            var sqlLiteHelper = new Mock<ISqlLiteHelper>(MockBehavior.Strict);
            sqlLiteHelper.Setup(helper => helper.ExecutegeneralQuery(query, connString));

            var taskListService = new TaskListService(sqlLiteHelper.Object);

            //Act
            taskListService.UpdateTask(taskId, title, description, important, duedate, connString);

            //Assert
            Mock.Verify(sqlLiteHelper);
        }
    }
}

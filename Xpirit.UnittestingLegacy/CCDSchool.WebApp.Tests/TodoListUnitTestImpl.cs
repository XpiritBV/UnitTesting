using CCDSchool.Business;
using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CCDSchool.WebApp.Tests
{
    public class TodoListUnitTestImpl : TodoList
    {
        public TodoListUnitTestImpl(ITaskListService taskListService, ITodoListWrapper todoListWrapper, string connString) : base(taskListService, todoListWrapper, connString)
        {
            lblUserName = new Label();
            trLoggedin = new HtmlTableRow();
            trLogin = new HtmlTableRow();
            btnAddList = new Button();
            txtTask = new TextBox();
            txtTodoList = new TextBox();
            btnAddTask = new Button();
            lstTaskListV = new ListBox();
            chkArchived = new CheckBox();
        }

        new public void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
        }
    }
}

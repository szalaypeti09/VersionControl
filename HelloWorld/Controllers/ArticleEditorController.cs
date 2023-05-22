using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using System;
using System.Data.SqlClient;

using System.Web.Mvc;

namespace StockY.Dnn.HelloWorld.Controllers
{
    [DnnHandleError]
    public class ArticleEditorController : DnnController
    {
        [HttpGet]
        public ActionResult Open()
        {
            return View("ArticleEditor");
        }

        [HttpPost]
        public ActionResult SaveData(string title, string article, string author, DateTime? created)
        {
            using (var connection = new SqlConnection("Data Source=.\\SQLExpress;Initial Catalog=host;User ID=host;Password=host123"))
            {
                connection.Open();

                var command = new SqlCommand("INSERT INTO ArticleTable (Title, Article, Author, Created) VALUES (@Title, @Article, @Author, @Created )", connection);

                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Article", article);
                command.Parameters.AddWithValue("@Author", author);
                command.Parameters.AddWithValue("@Created", created);

                command.ExecuteNonQuery();

                string query = "SELECT MAX(ID) FROM ArticleTable";

                SqlCommand command2 = new SqlCommand(query, connection);

                SqlDataReader reader = command2.ExecuteReader();


                reader.Read();
                int latestID = reader.GetInt32(0);
                reader.Close();

                var command3 = new SqlCommand("INSERT INTO AdminTable (ArticleID, StatusID) VALUES (@Article, @Status)", connection);

                command3.Parameters.AddWithValue("@Article", latestID);
                command3.Parameters.AddWithValue("@Status", 3);
                 
                command3.ExecuteNonQuery();


                return View();
            }
        }
    }
}
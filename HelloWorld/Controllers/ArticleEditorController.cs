using DotNetNuke.Web.Mvc.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockY.Dnn.HelloWorld.Controllers
{
    public class ArticleEditorController : DnnController
    {
        public ActionResult Open()
        {
            return View("ArticleEditor");
        }

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

                int insertedId = Convert.ToInt32(command.ExecuteScalar());

                string insertQuery2 = "INSERT INTO AdminTable (ArticleID, StatusID) VALUES (@Article, @Status)";

                using (SqlCommand command2 = new SqlCommand(insertQuery2, connection))
                {
                    command2.Parameters.AddWithValue("@Article", insertedId);
                    command2.Parameters.AddWithValue("@Status", 3);

                    command2.ExecuteNonQuery();
                }

                return RedirectToAction("Index", "Index");
            }
        }
    }
}
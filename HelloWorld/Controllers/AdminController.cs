﻿using DotNetNuke.Web.Mvc.Framework.Controllers;
using StockY.Dnn.HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockY.Dnn.HelloWorld.Controllers
{
    public class AdminController : DnnController
    {
        public ActionResult DisplayData()
        {
            List<ArticleTable> data = new List<ArticleTable>();

            using (SqlConnection connection = new SqlConnection("Data Source =.\\SQLExpress; Initial Catalog = host; User ID = host; Password = host123"))
            {
                string query = "SELECT ID, Title, Article, Author, Created FROM ArticleTable";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ArticleTable articleTable = new ArticleTable()
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Title = reader["Title"].ToString(),
                        Article = reader["Article"].ToString(),
                        Author = reader["Author"].ToString(),
                        Created = Convert.ToDateTime(reader["Created"])

                    };

                    data.Add(articleTable);
                }

                reader.Close();
            }

            return View(data);
        }

    }
}
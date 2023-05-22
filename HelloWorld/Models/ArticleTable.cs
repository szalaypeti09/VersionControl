using DotNetNuke.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockY.Dnn.HelloWorld.Models
{
    public class ArticleTable
    {
        [TableName("ArticleTable")]
        [PrimaryKey(nameof(ID), AutoIncrement = true)]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Article { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
    }
}
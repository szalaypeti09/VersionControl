using DotNetNuke.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockY.Dnn.HelloWorld.Models
{
    public class AdminTable
    {
        [TableName("AdminTable")]
        [PrimaryKey(nameof(ID), AutoIncrement = true)]
        public int ID { get; set; }
        public int ArticleID { get; set; }
        public int StatusID { get; set; }
    }
}
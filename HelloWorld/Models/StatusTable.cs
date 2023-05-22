using DotNetNuke.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockY.Dnn.HelloWorld.Models
{
    public class StatusTable
    {
        [TableName("StatusTable")]
        [PrimaryKey(nameof(ID), AutoIncrement = true)]
        public int ID { get; set; }
        public string StatusName { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Chatta.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { set; get; }
        public string Firstname { set; get; }
        public string Lastname { set; get; }
        public string Middlename { set; get; }
    }
}
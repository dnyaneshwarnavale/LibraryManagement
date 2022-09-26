using Library.Binders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class User
    {
        [ModelBinder (BinderType=typeof(CustomUserBinder))]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}

using Library.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Binders
{
    public class CustomUserBinder : IModelBinder

    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var data = bindingContext.HttpContext.Request.RouteValues;
            bool IsValueAvailable = data.TryGetValue("name", out object capsString);
            bool IsIDAvailable = data.TryGetValue("ID", out object isObject);

            if (IsValueAvailable && IsIDAvailable)
            {
                User user = new User();
                user.ID = Convert.ToInt32(isObject);
                user.Name = capsString.ToString().ToUpper();
                bindingContext.Result = ModelBindingResult.Success(user);

            }
            return Task.CompletedTask;
        }
    }
}

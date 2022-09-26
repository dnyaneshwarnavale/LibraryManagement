using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Binders
{
    public class CustomCapsBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var data = bindingContext.HttpContext.Request.RouteValues;
            bool IsValueAvailable = data.TryGetValue("name", out object capsString);
            if (IsValueAvailable)
            {
                string capitalString = capsString.ToString().ToUpper();
                bindingContext.Result = ModelBindingResult.Success(capitalString);

            }
            return Task.CompletedTask;
        }
    }
}

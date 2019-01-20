namespace TheStore.Site.Html
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;

    public static class HelperExtentions
    {
        public static MvcHtmlString FileFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
            where TProperty : HttpPostedFileBase
        {
            StringBuilder inputBuilder = new StringBuilder();
            string properyName = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData).PropertyName;
            inputBuilder.Append($"<input type='file' name='{properyName}' ");
            var properties = htmlAttributes.GetType().GetProperties();
            foreach (var prop in properties)
            {
                string propName = prop.Name;

                if (propName == "type" || propName == "name")
                    continue;

                var propVal = prop.GetValue(htmlAttributes);
                inputBuilder.Append($"{propName}='{propVal}' ");
            }

            inputBuilder.Append("/>");

            return MvcHtmlString.Create(inputBuilder.ToString());
        }

    }
}
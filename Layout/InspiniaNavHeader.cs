using System;
using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace PG.Inspinia.TagHelpers
{
    [HtmlTargetElement("Inspinia-NavHeader")]
    public class InspiniaNavHeader: TagHelper
    {

        #region Properties  
        public string Title { get; set; }

        public string SubTitle { get; set; } = "";
        
        public string HomeName { get; set; } = "Home";

        public string HomeUri { get; set; } = "#";

        public string AreaName { get; set; }
        
     
        public string ControllerName { get; set; }

        public string ControllerUri { get; set; } = "#";

      
        public string ActionName { get; set; } 
        #endregion

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            var htmlMainActionBlock = string.Empty;
            
            var htmlTitleBlock = Title;
            if (!string.IsNullOrWhiteSpace(SubTitle))
            {
                htmlTitleBlock = $"{Title} - {SubTitle}";
            }

            StringBuilder stringBuilder = new StringBuilder();

            if (!string.IsNullOrEmpty(AreaName)) stringBuilder.Append($"<li class='breadcrumb-item'>{AreaName}</li>");
            if (!string.IsNullOrEmpty(ControllerName)) stringBuilder.Append(GetLiElementFor(ControllerName, ControllerUri));
            if (!string.IsNullOrEmpty(ActionName)) stringBuilder.Append(GetLiElementFor(ActionName));

            var htmlBlock = $@"
                
                    <div class='col-lg-10'>
                        <h2>{htmlTitleBlock}</h2>
                        <ol class='breadcrumb'>
                            <li class='breadcrumb-item'>
                                <a href='{HomeUri}'>{HomeName}</a>
                            </li>
                           {stringBuilder}
                          
                        </ol>
                    </div>
                    <div class='col-lg-2'>
                    </div>
                ";

            output.Attributes.Add("class", "row wrapper border-bottom white-bg page-heading");
            output.PreContent.SetHtmlContent(htmlBlock);
            base.Process(context, output);
        }

        /// <summary>
        /// Usar para definir los enlaces entre el home y la accion.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        private string GetLiElementFor(string name, string url)
        {
            string htmlStr = $@"<li class='breadcrumb-item'><a href='{url}'>{name}</a></li>";
          

            return htmlStr;
        }

        /// <summary>
        /// Usar para definir la accion que se esta realizando
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string GetLiElementFor(string name)
        {
            string activeActionStr = $@"<li class='active breadcrumb-item'><strong>{name}</strong></li>";

            return activeActionStr;
        }
    }
}

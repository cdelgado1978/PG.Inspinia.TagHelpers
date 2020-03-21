using Microsoft.AspNetCore.Razor.TagHelpers;

namespace PG.Inspinia.TagHelpers
{
    [HtmlTargetElement("InspiniaNavHeader")]
    public class InspiniaNavHeader: TagHelper
    {

        #region Properties  
        public string Title { get; set; } = "Title";

        public string SubTitle { get; set; } = "";
        
        public string HomeName { get; set; } = "Home";

        public string HomeUri { get; set; } = "#";

        public string MainActionName { get; set; }

        public string MainActionUri { get; set; } = "#";

        public string ActiveActionName { get; set; } = "ActionName";
#endregion

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            var htmlMainActionBlock = string.Empty;
            
            if (!string.IsNullOrEmpty(MainActionName))
            {
                htmlMainActionBlock = 
                    $@"< li class='breadcrumb-item'>
                            <a href='{MainActionUri}'>{MainActionName}</a>
                        </li>";
            }

            var htmlTitleBlock = Title;
            if (!string.IsNullOrWhiteSpace(SubTitle))
            {
                htmlTitleBlock = $"{Title} - {SubTitle}";
            }

            var htmlBlock = $@"
                
                    <div class='col-lg-10'>
                        <h2>{htmlTitleBlock}</h2>
                        <ol class='breadcrumb'>
                            <li class='breadcrumb-item'>
                                <a href='{HomeUri}'>{HomeName}</a>
                            </li>
                            {htmlMainActionBlock}
                            <li class='active breadcrumb-item'>
                                <strong>{ActiveActionName}</strong>
                            </li>
                        </ol>
                    </div>
                    <div class='col-lg-2'>
                    </div>
                ";

            output.Attributes.Add("class", "row wrapper border-bottom white-bg page-heading");
            output.PreContent.SetHtmlContent(htmlBlock);
            base.Process(context, output);
        }

       
    }
}

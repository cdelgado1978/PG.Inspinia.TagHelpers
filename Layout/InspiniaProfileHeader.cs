using Microsoft.AspNetCore.Razor.TagHelpers;

namespace PG.Inspinia.TagHelpers
{
    [HtmlTargetElement("Inspinia-ProfileHeader")]
    public class InspiniaProfileHeader : TagHelper
    {

        #region Properties

        public string Username { get; set; } 
        public string Rol { get; set; }

        public string LogoutTitle { get; set; }

        public string LogoutUri { get; set; }
        #endregion
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            var htmlBlock = $@"
                    <a data-toggle='dropdown' class='dropdown-toggle' href='#'>
                        <span class='block m-t-xs font-bold'>{Username}</span>
                        <span class='text-muted text-xs block'>{Rol}<b class='caret'></b></span>
                    </a>
                    <ul class='dropdown-menu animated fadeInRight m-t-xs' style='position: absolute; top: 91px; left: 0px; will-change: top, left;'>
                        <li><a class='dropdown-item' href='{LogoutUri}'>{LogoutTitle}</a></li>
                    </ul>
                ";

            output.Attributes.Add("class", "dropdown profile-element");
            output.PreContent.SetHtmlContent(htmlBlock);
            base.Process(context, output);
        }
    }
}
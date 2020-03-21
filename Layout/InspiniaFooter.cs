using Microsoft.AspNetCore.Razor.TagHelpers;

namespace PG.Inspinia.TagHelpers
{
    [HtmlTargetElement("InspiniaFooter")]
    public class InspiniaFooter : TagHelper
    {
        public string text { get; set; }

        public string Copyright { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            var htmlbk = $@"
                    <div class='float-right'>
                        {text}
                    </div>
                    <div>
                        <strong>Copyright</strong> {Copyright}
                    </div>
                ";


            output.Attributes.Add("class", "footer");
            output.PreContent.SetHtmlContent(htmlbk);
            base.Process(context, output);

        }
    }
}
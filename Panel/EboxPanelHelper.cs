using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using pms.Helpers;

namespace PG.Inspinia.TagHelpers
{


    [HtmlTargetElement("Inspinia-Panel")]
    [RestrictChildren("panel-title-options", "panel-content", "panel-footer")]
    public class EboxPanelHelper : TagHelper
    {

        [HtmlAttributeName("Title")]
        public string Title { get; set; }

        [HtmlAttributeName("SubTitle")]
        public string SubTitle { get; set; }


        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("class", "ibox");

            var modalContext = new EBoxPanelContext();
            context.Items.Add(typeof(EboxPanelHelper), modalContext);

            await output.GetChildContentAsync();
            
            
            
            output.Content.AppendHtml("<div  class='ibox-title'>");
            output.Content.AppendHtml($"<h5>{Title}");

            if (!string.IsNullOrWhiteSpace(SubTitle))
            {
                output.Content.AppendHtml($"<small class='m-l-sm'>{SubTitle}</small>");
            }

            output.Content.AppendHtml("</h5>");
            output.Content.AppendHtml("<div class='ibox-tools'>");

            //output.Content.AppendHtml(template);
            if (modalContext.TitleOptions != null)
            {
              

                output.Content.AppendHtml(modalContext.TitleOptions); 
                
            }
            output.Content.AppendHtml("</div>");
            output.Content.AppendHtml("</div>");

            if (modalContext.Content != null)
            {
                output.Content.AppendHtml("<div class='ibox-content'>");

                output.Content.AppendHtml(modalContext.Content); 
                output.Content.AppendHtml("</div>");

            }

            if (modalContext.Footer != null)
            {
                output.Content.AppendHtml("<div class='ibox-footer'>");
                output.Content.AppendHtml(modalContext.Footer); 
                output.Content.AppendHtml("</div>");

            }


        }

       
    }


    [HtmlTargetElement("panel-title-options", ParentTag = "Inspinia-Panel")]
    public class TitleOptionsHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var modalContext = (EBoxPanelContext)context.Items[typeof(EboxPanelHelper)];
            modalContext.TitleOptions = childContent;


            output.SuppressOutput();


        }


    }


    [HtmlTargetElement("panel-content", ParentTag = "Inspinia-Panel")]
    public class ContentHelper : TagHelper
    {

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var modalContext = (EBoxPanelContext)context.Items[typeof(EboxPanelHelper)];
            modalContext.Content = childContent;

            output.SuppressOutput();


        }

    }


    [HtmlTargetElement("panel-footer", ParentTag = "Inspinia-Panel")]
    public class FooterHelper : TagHelper
    {

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var modalContext = (EBoxPanelContext)context.Items[typeof(EboxPanelHelper)];
            modalContext.Footer = childContent;

            output.SuppressOutput();


        }

    }
}

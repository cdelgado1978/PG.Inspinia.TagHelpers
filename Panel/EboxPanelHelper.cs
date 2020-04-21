using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;



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

        public bool ShowCloseButton { get; set; } = false;

        public bool ShowCollapseButton { get; set; } = false;

        
        private readonly string collapseTemplate = $@"<a class='collapse-link'>
                                            <i class='fa fa-chevron-up'></i>
                                            </a>";

        private readonly string closeTemplate = $@"<a class='close-link'>
                                            <i class='fa fa-times'></i>
                                         </a>";

        private readonly string dropdownTemplate = $@"<a class='dropdown-toggle' data-toggle='dropdown' href='#'>
                                            <i class='fa fa-wrench'></i>
                                            </a>";

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

            if (ShowCollapseButton) output.Content.AppendHtml(collapseTemplate);

            //output.Content.AppendHtml(template);
            if (modalContext.TitleOptions != null)
            {
              
               

                output.Content.AppendHtml(dropdownTemplate);
                output.Content.AppendHtml("<ul class='dropdown-menu dropdown-user'>");
                output.Content.AppendHtml(modalContext.DropDownOptions);
                output.Content.AppendHtml("</ul>");
               

            }
            if (ShowCloseButton) output.Content.AppendHtml(closeTemplate);

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
    [RestrictChildren("Drop-Down")]
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

    [HtmlTargetElement("Drop-Down", ParentTag = "panel-title-options")]
    public class DropDownOptionHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var modalContext = (EBoxPanelContext)context.Items[typeof(EboxPanelHelper)];
            modalContext.DropDownOptions = childContent;


            output.SuppressOutput();
        }
    }


    [HtmlTargetElement("Drop-Down-Items", ParentTag = "Drop-Down")]
    public class DropDownItemsHelper : TagHelper
    {
        public string id { get; set; }
        public string href { get; set; } = "#";
        
        public string text { get; set; } = "Nuevo Item";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
         
            output.TagName = "li";

            var itemTemplate = $"<a id='{id}' href='{href}' class='dropdown-item'>{text}</a>";

            output.PreContent.SetHtmlContent(itemTemplate);
            
            await base.ProcessAsync(context, output);

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

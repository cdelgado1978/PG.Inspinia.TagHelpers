using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace pms.Helpers.Modal
{

    
    [HtmlTargetElement("Inspinia-modal")]
    [RestrictChildren( "modal-body", "modal-footer")]
    public class ModalTagHelper : TagHelper
    {

        public string Id { get; set; }

        [HtmlAttributeName("Title")]
        public string Title { get; set; }

        /// <summary>
        /// Tamaño del formulario ( lg | sm )
        /// </summary>
        [HtmlAttributeName("Modal-Size")] 
        public string ModalSize { get; set; } = "lg";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {

            var modalContext = new ModalContext();
            context.Items.Add(typeof(ModalTagHelper), modalContext);

            await output.GetChildContentAsync();

            var template = $@"
                    <div class='modal-dialog modal-{ModalSize}'>
                        <div class='modal-content'>
                        <div class='modal-header'>
                            <button type='button' class='close' data-dismiss='modal'><span aria-hidden='true'>×</span>
                            </button>
                            <h4 class='modal-title' id='myModalLabel'>{Title}</h4>
                        </div>
                        <div class='modal-body'>
                    ";


            output.TagName = "div";

            
            output.Attributes.SetAttribute("role", "dialog");
            output.Attributes.SetAttribute("id", Id);
            output.Attributes.SetAttribute("tabindex", "-1");
            output.Attributes.SetAttribute("aria-hidden", "true");

            var classNames = "modal inmodal fade";

            if (output.Attributes.ContainsName("class"))
            {
                classNames = $"{output.Attributes["class"].Value} {classNames}";
            }

            output.Attributes.SetAttribute("class", classNames);

            output.Content.AppendHtml(template);

            if (modalContext.Body != null)
            {
                output.Content.AppendHtml(modalContext.Body);
            }
            output.Content.AppendHtml("</div>");
            if (modalContext.Footer != null)
            {
                output.Content.AppendHtml("<div class='modal-footer'>");
                output.Content.AppendHtml(modalContext.Footer);
                output.Content.AppendHtml("</div>");
            }

            output.Content.AppendHtml("</div></div>");
        }
    }


    [HtmlTargetElement("modal-body", ParentTag = "Inspinia-modal")]
    public class ModalBodyTagHelper : TagHelper
    {
        public string Id { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("id", Id);
            var childContent = await output.GetChildContentAsync();
            var modalContext = (ModalContext)context.Items[typeof(ModalTagHelper)];

            
            modalContext.Body = childContent;

            output.SuppressOutput();
        }
    }

    [HtmlTargetElement("modal-footer", ParentTag = "Inspinia-modal")]
    public class ModalFooterTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var modalContext = (ModalContext)context.Items[typeof(ModalTagHelper)];
            modalContext.Footer = childContent;

            output.SuppressOutput();
        }
    }
}

using Microsoft.AspNetCore.Html;

namespace PG.Inspinia.TagHelpers.Modal
{
    public class ModalContext
    {
        
        public IHtmlContent Body { get; set; }
        public IHtmlContent Footer { get; set; }

    }
}
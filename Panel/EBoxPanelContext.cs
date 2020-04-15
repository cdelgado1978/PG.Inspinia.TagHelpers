using Microsoft.AspNetCore.Html;

namespace PG.Inspinia.TagHelpers
{
    public class EBoxPanelContext
    {
        public IHtmlContent TitleOptions { get; set; }

        public IHtmlContent DropDownOptions { get; set; }
        public IHtmlContent Content { get; set; }

        public IHtmlContent Footer { get; set; }

    }
}
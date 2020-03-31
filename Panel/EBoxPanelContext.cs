using Microsoft.AspNetCore.Html;

namespace pms.Helpers
{
    public class EBoxPanelContext
    {
        public IHtmlContent TitleOptions { get; set; }
        public IHtmlContent Content { get; set; }

        public IHtmlContent Footer { get; set; }

    }
}
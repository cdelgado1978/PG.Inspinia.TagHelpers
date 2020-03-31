using Microsoft.AspNetCore.Html;

namespace pms.Helpers.Modal
{
    public class ModalContext
    {
        
        public IHtmlContent Body { get; set; }
        public IHtmlContent Footer { get; set; }

    }
}
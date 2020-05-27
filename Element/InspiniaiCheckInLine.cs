using Microsoft.AspNetCore.Razor.TagHelpers;

namespace PG.Inspinia.TagHelpers
{
    [HtmlTargetElement("Inspinia-iCheck-Inline")]

    public class InspiniaiCheckInLine: TagHelper
    {
        public string id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }

        public string Class { get; set; } = "icheckbox_square-green";



        public bool Disabled { get; set; }

        public bool Checked { get; set; }

         //<label class="i-checks"> 
         //     <div class="icheckbox_square-green" style="position: relative;">
         //         <input type = "checkbox" value="option1" style="position: absolute; opacity: 0;">
         //         <ins class="iCheck-helper" style="position: absolute; top: 0%; left: 0%; display: block; width: 100%; height: 100%; margin: 0px; padding: 0px; background: rgb(255, 255, 255); border: 0px; opacity: 0;">
         //         </ins>
         //     </div>a
         //</label>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var _disabled = (Disabled) ? "disabled=''" : "";
            var _checked = (Checked) ? "checked=''" : "";
            var _id = (!string.IsNullOrEmpty(id)) ? $"id='{id}'" : "";
            var _name = (!string.IsNullOrEmpty(Name)) ? $"name='{Name}'" : "";

            output.TagName = "label";
            output.Attributes.Add("class", "i-checks px-2");

            var iCheckInLineTemplate = $@"<div class='{Class.Trim()} {_checked} {_disabled}' style='position: relative;'>
                                                <input type='checkbox' {_checked} {_disabled} {_id.Trim()} {_name.Trim()} value='{Value.Trim()}' style='position: absolute; opacity: 0;'>
                                                <ins class='iCheck-helper' style='position: absolute; top: 0%; left: 0%; display: block; width: 100%; height: 100%; margin: 0px; padding: 0px; background: rgb(255, 255, 255); border: 0px; opacity: 0;'></ins>
                                        </div> {Text.Trim()}
                                    ";

            output.PreContent.SetHtmlContent(iCheckInLineTemplate);

            base.Process(context, output);
        }
    }
                                
}

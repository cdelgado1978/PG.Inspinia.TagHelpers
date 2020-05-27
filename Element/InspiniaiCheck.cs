using Microsoft.AspNetCore.Razor.TagHelpers;

namespace PG.Inspinia.TagHelpers
{

    [HtmlTargetElement("Inspinia-iCheck")]
    public class InspiniaiCheck: TagHelper
    {
        public string id { get; set; }
        public string Name { get; set; }

        public string Value { get; set; }
        public string Text { get; set; }


        public string Class { get; set; } = "icheckbox_square-green";

        public bool Disabled { get; set; } 

        public bool Checked { get; set; }
        //<div class="i-checks"><label> <div class="icheckbox_square-green disabled" style="position: relative;"><input type = "checkbox" value="" disabled="" style="position: absolute; opacity: 0;"><ins class="iCheck-helper" style="position: absolute; top: 0%; left: 0%; display: block; width: 100%; height: 100%; margin: 0px; padding: 0px; background: rgb(255, 255, 255); border: 0px; opacity: 0;"></ins></div> <i></i> Option four disabled</label></div>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var _disabled = (Disabled) ? "disabled=''" : "";
            var _checked = (Checked) ? "checked=''" : "";
            var _id = (!string.IsNullOrEmpty(id)) ? $"id='{id}'" : "";
            var _name = (!string.IsNullOrEmpty(Name)) ? $"name='{Name}'" : "";

            output.TagName = "div";
            output.Attributes.Add("class", "i-checks");

            var iCheckTemplate = $@"<label>
                                            <div class='{Class} {_disabled} {_checked}' style='position: relative; '>
                                                <input type='checkbox' value='{Value}' {_disabled} {_checked} {_id} {_name} style='position: absolute; opacity: 0; '/>
                                                <ins class='iCheck-helper' style='position: absolute; top: 0 %; left: 0 %; display: block; width: 100 %; height: 100 %; margin: 0px; padding: 0px; background: rgb(255, 255, 255); border: 0px; opacity: 0; '>
                                                </ins>
                                            </div>
                                            <i></i> {Text}
                                    </label>
                                    ";

            output.PreContent.SetHtmlContent(iCheckTemplate);

            base.Process(context, output);
        }
    }
                                
}

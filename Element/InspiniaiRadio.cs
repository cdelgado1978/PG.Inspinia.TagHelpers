using Microsoft.AspNetCore.Razor.TagHelpers;

namespace PG.Inspinia.TagHelpers
{
    [HtmlTargetElement("Inspinia-iRadio")]
    public class InspiniaiRadio : TagHelper
    {
        public string id { get; set; }
        public string Name { get; set; }
        
        public string value { get; set; }

        public string text { get; set; }

        public string Class { get; set; } = "iradio_square-green";

        public bool Disabled { get; set; }

        public bool Checked { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            
            var _disabled = (Disabled) ? "disabled=''" : "";
            var _checked = (Checked) ? "checked=''" : "";
            var _id = (!string.IsNullOrEmpty(id)) ? $"id='{id}'" : "";
            var _name = (!string.IsNullOrEmpty(Name)) ? $"name='{Name}'" : "";

            var iRadioTemplate = $@"<div class='i-checks'>
                                        <label> 
                                            <div class='{Class} {_checked} {_disabled} ' style='position: relative;'>
                                                <input type='radio' {_checked} {_disabled}  {_id} {_name} value='{value}'  style='position: absolute; opacity: 0;'/>
                                                <ins class='iCheck-helper' style='position: absolute; top: 0%; left: 0%; display: block; width: 100%; height: 100%; margin: 0px; padding: 0px; background: rgb(255, 255, 255); border: 0px; opacity: 0;'>
                                                </ins>
                                            </div> 
                                            <i></i> {text}
                                        </label>
                                    </div>";


            base.Process(context, output);
        }
    }
                                
}

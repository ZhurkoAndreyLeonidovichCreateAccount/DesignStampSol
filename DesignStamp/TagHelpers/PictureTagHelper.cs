using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.TagHelpers
{
    public class PictureTagHelper : TagHelper
    {
        [HtmlTargetElement(tag: "img", Attributes = "pic-action, pic-controller, pic-name")]
        public class ImageTagHelper : TagHelper
        {
            public string PicAction { get; set; }
            public string PicController { get; set; }
            public string PicName { get; set; }
           
            LinkGenerator _linkGenerator;
            public ImageTagHelper(LinkGenerator linkGenerator)
            {
                _linkGenerator = linkGenerator;
            }
            public override void Process(TagHelperContext context,
            TagHelperOutput output)
            {
                var uri = _linkGenerator.GetPathByAction(PicAction,
                PicController);
                //if (PicName != "1")
                    uri = uri + $"?name={PicName}";
                output.Attributes.Add("src", uri);


            }

        }
    }
}

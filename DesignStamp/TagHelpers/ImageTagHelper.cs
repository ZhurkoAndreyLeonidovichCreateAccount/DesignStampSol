using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.TagHelpers
{
    [HtmlTargetElement(tag: "img", Attributes = "img-action, img-controller, img-name")]
    public class ImageTagHelper : TagHelper
    {
        public string ImgName { get; set; }
        public string ImgAction { get; set; }
        public string ImgController { get; set; }
        //public string ImgName { get; set; }
        LinkGenerator _linkGenerator;
        public ImageTagHelper(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }
        public override void Process(TagHelperContext context,
        TagHelperOutput output)
        {
            var uri = _linkGenerator.GetPathByAction(ImgAction,
            ImgController);
            if (ImgName != "1")
            {
                uri = uri + $"?name={ImgName}";
            }

            output.Attributes.Add("src", uri);


        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFlowX.Domain.Entities
{
    public class SocialMedia
    {
        public int SocialMediaId { get; set; }
        public string SocialMediaTitle { get; set; }
        public string Url { get; set; }
        public string IconUrl { get; set; }
    }
}

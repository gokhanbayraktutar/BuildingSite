﻿using System.Collections.Generic;

namespace BuildingSite.Model.EntityModels
{
    public class ViewModel
    {
       public List<AdminModel> AdminModels { get; set; }

       public SiteConstantModel SiteConstantModel { get; set; }

       public AdminModel AdminModel { get; set; }

       public List<OurServiceModel> ourServiceModels { get; set; }

        public List<SliderModel> sliderModels { get; set; }
    }
}

using BuildingSite.Model.EntityModels.Base;

namespace BuildingSite.Model.EntityModels
{
    public class SliderModel : EntityModel
    {
        public string Picture { get; set; }

        public string Header { get; set; }

        public string Content { get; set; }

        public bool Active { get; set; }

        public int Siralama { get; set; }
    }
}

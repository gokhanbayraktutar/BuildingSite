using BuildingSite.Model.EntityModels.Base;

namespace BuildingSite.Model.EntityModels
{
    public class ContactPageModel : EntityModel
    {
        public string Telefon { get; set; }
        public string Faks { get; set; }
        public string Gsm { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Adres { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Linkedin { get; set; }
    }
}

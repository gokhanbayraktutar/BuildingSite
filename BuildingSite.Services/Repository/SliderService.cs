using BuildingSite.Contracts.IRepository;
using BuildingSite.Data.Context;
using BuildingSite.Data.Entities;
using BuildingSite.Model.EntityModels;
using BuildingSite.Services.Repository.Base;

namespace BuildingSite.Services.Repository
{
    public class SliderService : Service<Slider, SliderModel>, ISliderService
    {
        private DataContext _context;

        public SliderService(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}

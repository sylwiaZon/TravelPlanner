using TravelPlanner.Core.DomainModels;
using DbToSeeItem = TravelPlanner.Core.DataBaseModels.ToSeeItem;
using DomainToSeeItem = TravelPlanner.Core.DomainModels.ToSeeItem;

namespace TravelPlanner.Services.Converters
{
    public class ToSeeItemConverter
    {
        public static DomainToSeeItem ToDomainToSeeItem(DbToSeeItem item, Poi poi)
        {
            return new DomainToSeeItem
            {
                Id = item.Id,
                Checked = item.Checked,
                Name = item.Name,
                Poi = poi
            };
        }

        public static DbToSeeItem ToDbToSeeItem(DomainToSeeItem item)
        {
            return new DbToSeeItem
            {
                Id = item.Id,
                Checked = item.Checked,
                Name = item.Name
            };
        }
    }
}

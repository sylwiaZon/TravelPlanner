using DomainToDoItem = TravelPlanner.Core.DomainModels.ToDoItem;
using DbToDoItem = TravelPlanner.Core.DataBaseModels.ToDoItem;

namespace TravelPlanner.Services.Converters
{
    public class ToDoItemConverter
    {
        public static DomainToDoItem ToDomainToDoItem(DbToDoItem item)
        {
            return new DomainToDoItem
            {
                Id = item.Id,
                Checked = item.Checked,
                Name = item.Name
            };
        }

        public static DbToDoItem ToDbToDoItem(DomainToDoItem item)
        {
            return new DbToDoItem
            {
                Id = item.Id,
                Checked = item.Checked,
                Name = item.Name
            };
        }
    }
}

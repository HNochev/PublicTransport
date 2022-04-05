using PublicTransport.Core.Models.Lines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Contracts
{
    public interface ILineService
    {
        public Guid CreateStop(string name, int minutesFromPreviousStop);

        public Guid CreateLine(string name, string description, bool isActive, string userId);

        public List<LinesListingModel> AllWithNotActive();

        public List<LinesListingModel> AllActive();

        public bool IsActive(Guid id);

        public bool ActivateDeactivate(Guid id);

        public bool Edit(Guid id, string name, string description);

        public LineEditFormModel EditViewData(Guid id);

        public IEnumerable<LineStopModel> AllStops();

        public IEnumerable<LineStopModel> AllAddedStops(Guid id);

        public bool AddLineStop(Guid lineId, Guid stopId);

        public LinesListingModel GetLineInfo(Guid id);

        public bool RemoveLineStop(Guid stopId, Guid lineId);

        public Guid GetLineId(Guid id);

        public IEnumerable<StopsListingModel> AllCreatedStops();

        public bool DeleteStop(Guid id);

        public IEnumerable<LineHoursModel> GetAllHoursForLine(Guid id);

        public bool AddStartingHourToLine(Guid id, DateTime hour);
    }
}

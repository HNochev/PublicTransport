using PublicTransport.Core.Contracts;
using PublicTransport.Core.Models.Lines;
using PublicTransport.Infrastructure.Data;
using PublicTransport.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransport.Core.Services
{
    public class LineService : ILineService
    {
        private readonly ApplicationDbContext data;

        public LineService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public Guid CreateStop(string name, int minutesFromPreviousStop)
        {
            var newStop = new Stop
            {
                Name = name,
                MinutesFromPreviousStop = minutesFromPreviousStop,
            };

            this.data.Stops.Add(newStop);
            this.data.SaveChanges();

            return newStop.Id;
        }

        public Guid CreateLine(string name, string description, bool isActive, string userId)
        {
            var newLine = new Line
            {
                Name = name,
                Description = description,
                IsActive = isActive,
                UserId = userId,
            };

            this.data.Lines.Add(newLine);
            this.data.SaveChanges();

            return newLine.Id;
        }

        public List<LinesListingModel> AllWithNotActive()
        {
            return this.data
                 .Lines
                 .Select(x => new LinesListingModel
                 {
                     Id = x.Id,
                     Name = x.Name,
                     Description = x.Description,
                     IsActive = x.IsActive,
                 })
                 .OrderBy(x => x.Name)
                 .ToList();
        }

        public List<LinesListingModel> AllActive()
        {
            return this.data
                 .Lines
                 .Where(x => x.IsActive)
                 .Select(x => new LinesListingModel
                 {
                     Id = x.Id,
                     Name = x.Name,
                     Description = x.Description,
                     IsActive = x.IsActive,
                 })
                 .OrderBy(x => x.Name)
                 .ToList();
        }

        public bool IsActive(Guid id)
        {
            return this.data
                .Lines
                .Where(x => x.Id == id)
                .Select(x => x.IsActive)
                .First();
        }

        public bool ActivateDeactivate(Guid id)
        {
            var lineData = this.data.Lines.Find(id);

            if (lineData == null)
            {
                return false;
            }
            if (lineData.IsActive)
            {
                lineData.IsActive = false;
            }
            else
            {
                lineData.IsActive = true;
            }

            this.data.SaveChanges();
            return true;
        }

        public bool Edit(Guid id, string name, string description)
        {
            var lineData = this.data.Lines.Find(id);

            if (lineData == null)
            {
                return false;
            }

            lineData.Name = name;
            lineData.Description = description;

            this.data.SaveChanges();

            return true;
        }

        public LineEditFormModel EditViewData(Guid id)
        {
            return this.data.Lines
                .Where(x => x.Id == id)
                .Select(x => new LineEditFormModel
                {
                    Name = x.Name,
                    Description = x.Description,
                })
                .First();
        }
    }
}

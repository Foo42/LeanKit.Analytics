﻿using System.Linq;
using LeanKit.Data.SQL;
using LeanKit.Utilities.DateAndTime;

namespace LeanKit.ReleaseManager.Models
{
    public class CycleTimeViewModelFactory : IBuildCycleTimeViewModels
    {
        private readonly ITicketRepository _ticketRepository;

        public CycleTimeViewModelFactory(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public CycleTimeViewModel Build()
        {
            var tickets = _ticketRepository.GetAll().Tickets;

            return new CycleTimeViewModel
            {
                Tickets = tickets.Select(t => new CycleTimeTicketItem
                    {
                        Id = t.Id,
                        ExternalId = t.ExternalId,
                        Title = t.Title,
                        StartedFriendlyText = t.Started.ToFriendlyText("dd MMM yyyy", " HH:mm"),
                        Release = new CycleTimeReleaseViewModel {},
                        FinishedFriendlyText = t.Finished.ToFriendlyText("dd MMM yyyy", " HH:mm"),
                        Duration = t.CycleTime.Days + " Day" + (t.CycleTime.Days != 1 ? "s" : "")
                    })
            };
        }
    }

    public class CycleTimeReleaseViewModel
    {
        public string Name { get; set; }

        public int Id { get; set; }
    }
}
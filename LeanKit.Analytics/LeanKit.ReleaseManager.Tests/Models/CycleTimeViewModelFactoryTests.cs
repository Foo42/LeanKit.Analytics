﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeanKit.Data;
using LeanKit.Data.SQL;
using LeanKit.ReleaseManager.Models;
using NUnit.Framework;

namespace LeanKit.ReleaseManager.Tests.Models
{
    [TestFixture]
    public class CycleTimeViewModelFactoryTests : ITicketRepository
    {
        private Ticket _ticketReturnedFromDb;

        [Test]
        public void SetsTicketId()
        {
            const int expectedId = 12345;

            _ticketReturnedFromDb = new Ticket
                {
                    CycleTime = new WorkDuration(),
                    Id = expectedId
                };

            ITicketRepository ticketRepository = this;

            var cycleTimeViewModelFactory = new CycleTimeViewModelFactory(ticketRepository);
            var cycleTimeViewModel = cycleTimeViewModelFactory.Build();

            Assert.That(cycleTimeViewModel.Tickets.First().Id, Is.EqualTo(expectedId));
        }

        [Test]
        public void SetsTicketExternalId()
        {
            const string expectedExternalId = "R-1234";

            _ticketReturnedFromDb = new Ticket
            {
                CycleTime = new WorkDuration(),
                ExternalId = expectedExternalId
            };

            ITicketRepository ticketRepository = this;

            var cycleTimeViewModelFactory = new CycleTimeViewModelFactory(ticketRepository);
            var cycleTimeViewModel = cycleTimeViewModelFactory.Build();

            Assert.That(cycleTimeViewModel.Tickets.First().ExternalId, Is.EqualTo(expectedExternalId));
        }

        [Test]
        public void SetsTicketTitle()
        {
            const string expectedTitle = "Example Ticket";

            _ticketReturnedFromDb = new Ticket
            {
                CycleTime = new WorkDuration(),
                Title = expectedTitle
            };

            ITicketRepository ticketRepository = this;

            var cycleTimeViewModelFactory = new CycleTimeViewModelFactory(ticketRepository);
            var cycleTimeViewModel = cycleTimeViewModelFactory.Build();

            Assert.That(cycleTimeViewModel.Tickets.First().Title, Is.EqualTo(expectedTitle));
        }

        [Test]
        public void SetsTicketStartedFriendlyDate()
        {
            const string expectedStarted = "Today 10:00";

            _ticketReturnedFromDb = new Ticket
            {
                CycleTime = new WorkDuration(),
                Started = DateTime.Now.Date.AddHours(10)
            };

            ITicketRepository ticketRepository = this;

            var cycleTimeViewModelFactory = new CycleTimeViewModelFactory(ticketRepository);
            var cycleTimeViewModel = cycleTimeViewModelFactory.Build();

            Assert.That(cycleTimeViewModel.Tickets.First().StartedFriendlyText, Is.EqualTo(expectedStarted));
        }

        [Test]
        public void SetsTicketFinishedFriendlyDate()
        {
            const string expectedFinished = "Today 10:00";

            _ticketReturnedFromDb = new Ticket
            {
                CycleTime = new WorkDuration(),
                Finished = DateTime.Now.Date.AddHours(10)
            };

            ITicketRepository ticketRepository = this;

            var cycleTimeViewModelFactory = new CycleTimeViewModelFactory(ticketRepository);
            var cycleTimeViewModel = cycleTimeViewModelFactory.Build();

            Assert.That(cycleTimeViewModel.Tickets.First().FinishedFriendlyText, Is.EqualTo(expectedFinished));
        }

        [Test]
        public void SetsTicketDurationToOneDay()
        {
            const string expectedDuration = "1 Day";

            _ticketReturnedFromDb = new Ticket { CycleTime = new WorkDuration { Days = 1 } };

            ITicketRepository ticketRepository = this;

            var cycleTimeViewModelFactory = new CycleTimeViewModelFactory(ticketRepository);
            var cycleTimeViewModel = cycleTimeViewModelFactory.Build();

            Assert.That(cycleTimeViewModel.Tickets.First().Duration, Is.EqualTo(expectedDuration));
        }

        [Test]
        public void SetsTicketDurationToTwoDays()
        {
            const string expectedDuration = "2 Days";

            _ticketReturnedFromDb = new Ticket { CycleTime = new WorkDuration { Days = 2 } };

            ITicketRepository ticketRepository = this;

            var cycleTimeViewModelFactory = new CycleTimeViewModelFactory(ticketRepository);
            var cycleTimeViewModel = cycleTimeViewModelFactory.Build();

            Assert.That(cycleTimeViewModel.Tickets.First().Duration, Is.EqualTo(expectedDuration));
        }

        public void Save(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public AllTicketsForBoard GetAll()
        {
            return new AllTicketsForBoard
                {
                    Tickets = new List<Ticket>()
                        {
                            _ticketReturnedFromDb
                        }
                };
        }
    }
}
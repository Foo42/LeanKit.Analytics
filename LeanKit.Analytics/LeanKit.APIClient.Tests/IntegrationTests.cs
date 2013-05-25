﻿using System.Linq;
using LeanKit.APIClient.API;
using NUnit.Framework;

namespace LeanKit.APIClient.Tests
{
    [TestFixture]
    class IntegrationTests
    {
        private const string USERNAME = "";
        private const string PASSWORD = "";
        private const string ACCOUNT = "";
        private const string BOARD_ID = "";

        [Test]
        public void SetsBoardId()
        {
            var apiCaller = new ApiCaller
            {
                Account = ACCOUNT,
                BoardId = BOARD_ID,
                Credentials = new ApiCredentials
                {
                    Username = USERNAME,
                    Password = PASSWORD
                }
            };

            var leankitBoard = apiCaller.GetBoard();

            Assert.That(leankitBoard.Id, Is.Not.EqualTo(0));
        }

        [Test]
        public void GetArchive()
        {
            var apiCaller = new ApiCaller
            {
                Account = ACCOUNT,
                BoardId = BOARD_ID,
                Credentials = new ApiCredentials
                {
                    Username = USERNAME,
                    Password = PASSWORD
                }
            };

            var archiveLanes = apiCaller.GetBoardArchive();

            Assert.That(archiveLanes, Is.Not.EqualTo(0));
        }

        [Test]
        public void SetsCardHistory()
        {
            var apiCaller = new ApiCaller
            {
                Account = ACCOUNT,
                BoardId = BOARD_ID,
                Credentials = new ApiCredentials
                {
                    Username = USERNAME,
                    Password = PASSWORD
                }
            };

            var leankitBoard = apiCaller.GetCardHistory(40816485);

            Assert.That(leankitBoard.First().CardId, Is.Not.EqualTo(0));
        }
    }
}

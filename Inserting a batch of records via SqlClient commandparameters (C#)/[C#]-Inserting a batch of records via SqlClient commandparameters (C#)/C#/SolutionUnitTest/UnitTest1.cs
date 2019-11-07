using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsvReaderLibrary;
using BackEnd;
using System.Linq;

namespace SolutionUnitTest
{
    /// <summary>
    /// Make sure to run CreateDatabase.sql followed
    /// by CreateTable.sql as the test rely on having
    /// a specific database and table.
    /// 
    /// Also in BackEnd.SqlConnection you need to change the server name
    /// to a server that exists on your machine.
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Validate reading a csv file into a list
        /// </summary>
        [TestMethod]
        public void ReadPlayerFile_VerifyCountOfPlayers()
        {
            var fileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Players.csv");
            var ops = new ReadMLB_Pleayers();
            var players = ops.ReaderPlayersFromFile(fileName);

            Assert.IsTrue(players.Count == 1000, 
                "Explected 1000 players");

        }
        /// <summary>
        /// Validate reading csv file into a list followed by inserting data read in
        /// into a SQL-Server database table.
        /// </summary>
        [TestMethod]
        public void InsertRecords()
        {
            var bOperations = new BackEndDataOperations();
            bOperations.TruncatePlayersTable();

            var fileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
                "Players.csv");

            var csvOps = new ReadMLB_Pleayers();
            var opsData = new DataOperations();
            var players = csvOps.ReaderPlayersFromFile(fileName);

            // check the insert method was successful
            Assert.IsTrue(opsData.InsertRecordsFromTextFileImport(players),
                "Insert of records failed");

            // validate all players where inserted as their id field (primary key should have a value not 0.
            Assert.IsTrue(!players.Any(p => p.id == 0),
                "One or more records not inserted");

            Assert.IsTrue(bOperations.GetPlayerCount() == 1000,
                "Expected 1000 records");

            
        }
    }
}

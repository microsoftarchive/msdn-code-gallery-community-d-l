using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using BackEnd;

namespace CsvReaderLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// File read in via
    /// https://joshclose.github.io/CsvHelper/
    /// </remarks>
    public class ReadMLB_Pleayers : BaseExceptionProperties
    {
        /// <summary>
        /// Used to learn about import errors with the csv reader
        /// </summary>
        private List<string> errorLines;
        /// <summary>
        /// Read a comma delimited file into a list of a specfic class
        /// </summary>
        /// <param name="pFileName"></param>
        /// <returns></returns>
        public List<Player> ReaderPlayersFromFile(string pFileName)
        {
            var playerList = new List<Player>();

            try
            {
                errorLines = new List<string>();
                using (TextReader readFile = new StreamReader(pFileName))
                {
                    var csv = new CsvReader(readFile);
                    csv.Configuration.BadDataFound = context =>  
                    {
                        errorLines.Add($"Bad data found on row '{context.RawRow}");
                    };

                    csv.Configuration.HasHeaderRecord = false;

                    var record = new PlayerPartial();
                    var records = csv.EnumerateRecords(record);


                    playerList = records.Select(p => new Player()
                    {
                        Name = p.Name,
                        Age = p.Age,
                        Height = p.Height,
                        Position = p.Position,
                        Team = p.Team,
                        Weight = p.Weight
                    }).ToList();

                }
            }
            catch (Exception ex)
            {
                mHasException = true;
                mLastException = ex;
            }

            return playerList;
        }
    }
}

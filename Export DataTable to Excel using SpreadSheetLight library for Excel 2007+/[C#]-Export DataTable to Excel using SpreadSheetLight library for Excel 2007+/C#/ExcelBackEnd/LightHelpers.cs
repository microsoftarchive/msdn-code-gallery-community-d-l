using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelBackEnd
{
    class LightHelpers
    {
        /// <summary>
        /// Determine if a sheet exists in the specified excel file
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="pSheetName"></param>
        /// <returns></returns>
        public bool SheetExists(string pFileName, string pSheetName)
        {
            using (SLDocument doc = new SLDocument(pFileName))
            {
                return doc.GetSheetNames(false).Any((sheetName) => sheetName.ToLower() == pSheetName.ToLower());
            }
        }
        /// <summary>
        /// Add a new sheet if it does not currently exists.
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="pSheetName"></param>
        /// <returns></returns>
        public bool AddNewSheet(string pFileName, string pSheetName)
        {
            using (SLDocument doc = new SLDocument(pFileName))
            {
                if (!(doc.GetSheetNames(false).Any((sheetName) => sheetName.ToLower() == pSheetName.ToLower())))
                {
                    doc.AddWorksheet(pSheetName);
                    doc.Save();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Remove a sheet if it exists.
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="pSheetName"></param>
        /// <returns></returns>
        public bool RemoveWorkSheet(string pFileName, string pSheetName)
        {
            using (SLDocument doc = new SLDocument(pFileName))
            {
                var workSheets = doc.GetSheetNames(false);
                if (workSheets.Any((sheetName) => sheetName.ToLower() == pSheetName.ToLower()))
                {
                    if (workSheets.Count > 1)
                    {
                        var sheet = doc.GetSheetNames().FirstOrDefault((sName) => sName.ToLower() != pSheetName.ToLower());
                        doc.SelectWorksheet(doc.GetSheetNames().FirstOrDefault((sName) => sName.ToLower() != pSheetName.ToLower()));
                    }
                    else if (workSheets.Count == 1)
                    {
                        throw new Exception("Can not delete the sole worksheet");
                    }

                    doc.DeleteWorksheet(pSheetName);
                    doc.Save();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Get sheet names in an Excel file
        /// </summary>
        /// <param name="pFileName"></param>
        /// <returns></returns>
        public List<string> SheetNames(string pFileName)
        {
            using (SLDocument doc = new SLDocument(pFileName))
            {
                return doc.GetSheetNames(false);
            }
        }
    }
}

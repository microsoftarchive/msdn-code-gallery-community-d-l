using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEFAULT
{
    class LUISResponse
    {
        public string query { get; set; }
        public TopScoringIntent topScoringIntent { get; set; }
        public Entities[] entities { get; set; }
        public Dialog dialog { get; set; }
    }
    class TopScoringIntent
    {
        public string intent { get; set; }
        public string score { get; set; }
        public Actions[] actions { get; set; }
    }
    class Actions
    {
        public string triggered { get; set; }
        public string name { get; set; }
        public Parameters[] parameters { get; set; }
    }
    class Parameters
    {
        public string name { get; set; }
        public string required { get; set; }
        public Value[] value { get; set; }
    }
    class Value
    {
        public string entity { get; set; }
        public string type { get; set; }
    }

    class Entities
    {
        public string entity { get; set; }
        public string type { get; set; }
        public string startIndex { get; set; }
        public string endIndex { get; set; }
        public string score { get; set; }
        public Resolution resolution { get; set; }
    }
    class Resolution
    {
        public string date { get; set; }
    }
    class Dialog
    {
        public string prompt { get; set; }
        public string parameterName { get; set; }
        public string contextId { get; set; }
        public string status { get; set; }
    }
}

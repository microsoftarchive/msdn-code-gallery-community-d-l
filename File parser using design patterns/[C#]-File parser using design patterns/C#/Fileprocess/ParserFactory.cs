using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fileprocess
{
    public enum ParserType
    {
        CSV,
        PIPE,
        Semicolon,
        EXCEL,
        Tab
    }
    public abstract class GenericFactory<TEnity>
    {
        public abstract TEnity GetObject(string type);
    }

    /// <summary>
    /// 
    /// </summary>
    public class ParserFactory : GenericFactory<BaseParser>
    {

        Dictionary<string, BaseParser> parsers = new Dictionary<string, BaseParser>();
        /// <summary>
        /// Load the assembly dynamically which are inheriting from baseparser class.
        /// We can add any number of classes which inherit from baseparser
        /// </summary>

        public ParserFactory()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            
           Type[] types=   assembly.GetTypes();
           foreach(Type type in types)
           {
               if( type.IsSubclassOf(typeof(BaseParser)) && (!type.IsAbstract))
               {
                    BaseParser parser= Activator.CreateInstance(type) as BaseParser ;
                    parsers.Add(parser.ToString(), parser);
               }
           }
                                              


           
           
        }
        public override BaseParser GetObject(string type)
        {
            return parsers[type];
        }
    }

    
}

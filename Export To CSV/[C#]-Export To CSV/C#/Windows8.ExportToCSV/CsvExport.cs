namespace Windows8.ExportToCSV
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using Windows.Storage;

    public class CsvExport<T> where T : class
    {
        private const string ListSeparator = ";";

        public IList<T> Objects;

        public CsvExport(IList<T> objects)
        {
            Objects = objects;
        }

        public string Export()
        {
            return Export(true);
        }

        public string Export(bool includeHeaderLine)
        {

            var sb = new StringBuilder();
           
            //Get properties using reflection.
           var propertyInfos = typeof(T).GetTypeInfo();

            if (includeHeaderLine)
            {
                //add header line.
                foreach (var propertyInfo in propertyInfos.DeclaredProperties)
                {
                    sb.Append(propertyInfo.Name).Append(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                }
                sb.Remove(sb.Length - 1, 1).AppendLine();
            }

            //add value for each property.
            foreach (T obj in Objects)
            {
                foreach (var propertyInfo in propertyInfos.DeclaredProperties)
                {
                    sb.Append(MakeValueCsvFriendly(propertyInfo.GetValue(obj, null))).Append(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                }

                sb.Remove(sb.Length - 1, 1).AppendLine();
            }
            
            return sb.ToString();
        }

        //export to a file.
        public async void ExportToFile(string path)
        {
           var storageFolder = KnownFolders.DocumentsLibrary;
           var file = await storageFolder.CreateFileAsync(path, CreationCollisionOption.ReplaceExisting);
           await FileIO.WriteTextAsync(file, Export());
        }

        //export as binary data.
        public byte[] ExportToBytes()
        {
            return Encoding.UTF8.GetBytes(Export());
        }

        //get the csv value for field.
        private string MakeValueCsvFriendly(object value)
        {
            if (value == null) return "";
           
            if (value is DateTime)
            {
                if (((DateTime)value).TimeOfDay.TotalSeconds == 0)
                    return ((DateTime)value).ToString("yyyy-MM-dd");
                return ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
            }
            string output = value.ToString();

            if (output.Contains(",") || output.Contains("\""))
                output = '"' + output.Replace("\"", "\"\"") + '"';

            return output;

        }
    }
}

namespace BackEnd
{
    public class SqlConnectionProperties : BaseExceptionProperties
    {
        public string ServerName { get { return "KARENS-PC"; } }
        public string InitialCatalog { get { return "ForumExample"; } }
        public string ConnectionString {
            get
            {
                return $"Data Source={ServerName};Initial Catalog={InitialCatalog};Integrated Security=True";
            } }

    }
}

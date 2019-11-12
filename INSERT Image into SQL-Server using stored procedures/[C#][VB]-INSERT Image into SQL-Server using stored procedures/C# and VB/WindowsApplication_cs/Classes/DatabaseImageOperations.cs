using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace WindowsApplication_cs.Classes
{
    public enum Success
    {
        /// <summary>
        /// Successfully completed
        /// </summary>
        Okay,
        /// <summary>
        /// Something went wrong
        /// </summary>
        OhSnap
    }

    public class DatabaseImageOperations
    {
        /// <summary>
        /// NOTE: This points to your database server
        /// </summary>
        private static string databaseServer = "KARENS-PC";
        /// <summary>
        /// NOTE: Name of database containing required tables
        /// </summary>
        static string defaultCatalog = "NORTHWND_NEW.MDF";
        string _ConnectionString = $"Data Source={databaseServer};Initial Catalog={defaultCatalog};Integrated Security=True";
        private string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
            set
            {
                _ConnectionString = value;
            }
        }
        /// <summary>
        /// Indicates a method just executed throw an exception
        /// </summary>
        public bool HasError { get; set; }
        /// <summary>
        /// Works in tangent with HasError
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// Determines if there are any records
        /// </summary>
        /// <returns></returns>
        /// <remarks>not used, was for use during writing code for the code sample</remarks>
        public bool HasRecords()
        {
            bool result = true;
            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn, CommandText = "SELECT COUNT(ImageID) FROM ImageData" })
                {
                    cn.Open();
                    result = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
            return result;
        }
        /// <summary>
        /// Given a valid image converts it to a byte array
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        /// <remarks>
        /// Suitable for saving a file to disk
        /// </remarks>
        public byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        /// <summary>
        /// Save image to the sql-server database table
        /// </summary>
        /// <param name="Image">Valid image</param>
        /// <param name="Description">Information to describe the image</param>
        /// <param name="Identifier">New primary key</param>
        /// <returns></returns>
        public Success InsertImage(Image Image, string Description, ref int Identifier)
        {

            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn, CommandText = "SaveImage", CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.Add("@img", SqlDbType.Image).Value = ImageToByte(Image);
                    cmd.Parameters.Add("@description", SqlDbType.Text).Value = Description;

                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@new_identity", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output });
                    try
                    {
                        cn.Open();
                        Identifier = Convert.ToInt32(cmd.ExecuteScalar());
                        return Success.Okay;
                    }
                    catch (Exception ex)
                    {
                        HasError = true;
                        ErrorMessage = ex.Message;
                        return Success.OhSnap;
                    }
                }
            }
        }
        /// <summary>
        /// Insert image where ImageByes is a byte array from a valid image
        /// </summary>
        /// <param name="ImageBytes">Byte array </param>
        /// <param name="Description">used to describe the image</param>
        /// <param name="Identifier">New primary key</param>
        /// <returns></returns>
        public Success InsertImage(byte[] ImageBytes, string Description, ref int Identifier)
        {

            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn, CommandText = "SaveImage", CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.Add("@img", SqlDbType.Image).Value = ImageBytes;
                    cmd.Parameters.Add("@description", SqlDbType.Text).Value = string.IsNullOrWhiteSpace(Description) ? "None" : Description;

                    cmd.Parameters.Add(new SqlParameter { ParameterName = "@new_identity", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output });
                    try
                    {
                        cn.Open();
                        Identifier = Convert.ToInt32(cmd.ExecuteScalar());
                        return Success.Okay;
                    }
                    catch (Exception ex)
                    {
                        HasError = true;
                        ErrorMessage = ex.Message;
                        return Success.OhSnap;
                    }
                }
            }
        }
        /// <summary>
        /// Set image passed in parameter 2 to bytes returned from image field of Indentifier or
        /// on error or key not found an error message is set and can be read back by the caller
        /// </summary>
        /// <param name="Identifier">primry key to locate</param>
        /// <param name="inBoundImage">Image to set from returned bytes in database table of found record</param>
        /// <returns>Success</returns>
        /// <remarks>
        /// An alternative is to return the image rather than success as done now
        /// </remarks>
        public Success GetImage(int Identifier, ref Image inBoundImage, ref string Description)
        {
            DataTable dtResults = new DataTable();
            Success SuccessType = 0;

            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn, CommandText = "ReadImage", CommandType = CommandType.StoredProcedure })
                {

                    cmd.Parameters.Add("@imgId", SqlDbType.Int).Value = Identifier;

                    try
                    {

                        cn.Open();
                        dtResults.Load(cmd.ExecuteReader());

                        if (dtResults.Rows.Count == 1)
                        {
                            MemoryStream ms = new MemoryStream((byte[])(dtResults.Rows[0]["ImageData"]));
                            Description = Convert.ToString(dtResults.Rows[0]["Description"]);
                            inBoundImage = Image.FromStream(ms);
                            SuccessType = Success.Okay;
                        }
                        else
                        {
                            HasError = true;
                            ErrorMessage = $"{Identifier} not located";
                            SuccessType = Success.OhSnap;
                        }
                    }
                    catch (Exception ex)
                    {
                        HasError = true;
                        ErrorMessage = ex.Message;
                        SuccessType = Success.OhSnap;
                    }
                }
            }

            return SuccessType;

        }
        /// <summary>
        /// Get an image in the database table by primary key
        /// </summary>
        /// <param name="Identifier"></param>
        /// <param name="inBoundImage"></param>
        /// <returns></returns>
        /// <remarks>
        /// Not used, here for you if needed to get a single image, has been tested and works
        /// </remarks>
        public Success GetImage(int Identifier, ref Image inBoundImage)
        {
            string Description = "";
            return GetImage(Identifier, ref inBoundImage, ref Description);
        }
        /// <summary>
        /// Return all records in our table
        /// </summary>
        /// <returns></returns>
        public DataTable DataTable()
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (SqlCommand cmd = new SqlCommand { Connection = cn, CommandText = "ReadAllRecords", CommandType = CommandType.StoredProcedure })
                {
                    cn.Open();
                    dt.Load(cmd.ExecuteReader());
                }
            }

            return dt;

        }

    }
}

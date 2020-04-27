using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class LikePassFunctions
    {
        DBConnect objDB = new DBConnect();
        public LikePassFunctions()
        {

        }


        public void updateLikes(int UserID, int addID)
        {
            //Add current profile to like
            List<int> likeList;
            SqlCommand objCommand = new SqlCommand();
            //objCommand  = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetLikes";

            objCommand.Parameters.AddWithValue("@UserId", UserID);

            objDB.GetDataSetUsingCmdObj(objCommand);
            Byte[] byteArray;
            //objDB.GetField("Likes", 0) != System.DBNull.Value

            byteArray = (Byte[])objDB.GetField("Likes", 0);







            BinaryFormatter deSerializer = new BinaryFormatter();

            MemoryStream memStream = new MemoryStream(byteArray);


            try
            {
                likeList = (List<int>)deSerializer.Deserialize(memStream);
            }
            catch
            {
                likeList = new List<int>();
            }


            likeList.Add(addID);

            BinaryFormatter serializer = new BinaryFormatter();

            MemoryStream stream = new MemoryStream();

            Byte[] Store;

            serializer.Serialize(stream, likeList);

            Store = memStream.ToArray();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_StoreLikes";

            objCommand.Parameters.AddWithValue("@UserId", UserID);
            objCommand.Parameters.AddWithValue("@Likes", Store);
            objDB.DoUpdateUsingCmdObj(objCommand);
        }

        public void updatePass(int UserID, int addID)
        {
            //Add current profile to dislike
            SqlCommand objCommand = new SqlCommand();
            //objCommand  = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetPass";

            objCommand.Parameters.AddWithValue("@UserId", UserID);

            objDB.GetDataSetUsingCmdObj(objCommand);



            Byte[] byteArray = (Byte[])objDB.GetField("Passes", 0);



            BinaryFormatter deSerializer = new BinaryFormatter();

            MemoryStream memStream = new MemoryStream(byteArray);



            List<int> passList;
            try
            {
                passList = (List<int>)deSerializer.Deserialize(memStream);
            }
            catch
            {
                passList = new List<int>();
            }

            passList.Add(addID);

            BinaryFormatter serializer = new BinaryFormatter();

            MemoryStream stream = new MemoryStream();

            Byte[] Store;

            serializer.Serialize(stream, passList);

            Store = memStream.ToArray();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_StorePass";

            objCommand.Parameters.AddWithValue("@UserId", UserID);
            objCommand.Parameters.AddWithValue("@Pass", Store);
            objDB.DoUpdateUsingCmdObj(objCommand);
        }
        public List<int> getLikes(int UserID)
        {
            SqlCommand objCommand = new SqlCommand();
            //objCommand  = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetLikes";

            objCommand.Parameters.AddWithValue("@UserId", UserID);

            objDB.GetDataSetUsingCmdObj(objCommand);



            Byte[] byteArray = (Byte[])objDB.GetField("Likes", 0);



            BinaryFormatter deSerializer = new BinaryFormatter();

            MemoryStream memStream = new MemoryStream(byteArray);



            List<int> likeList = (List<int>)deSerializer.Deserialize(memStream);
            return likeList;
        }

        public List<int> getPasses(int UserID)
        {
            //Add current profile to dislike
            SqlCommand objCommand = new SqlCommand();
            //objCommand  = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetPass";

            objCommand.Parameters.AddWithValue("@UserId", UserID);

            objDB.GetDataSetUsingCmdObj(objCommand);



            Byte[] byteArray = (Byte[])objDB.GetField("Passes", 0);



            BinaryFormatter deSerializer = new BinaryFormatter();

            MemoryStream memStream = new MemoryStream(byteArray);



            List<int> passList = (List<int>)deSerializer.Deserialize(memStream);
            return passList;
        }
    }
}

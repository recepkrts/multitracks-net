using System;
using System.Data.SqlClient;
using System.Data;
using Mtdata;


public partial class PageToSync_artistDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int artistID = Convert.ToInt32(Request.QueryString["artistID"]);
        try
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MultiTracksDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {   
                connection.Open();

                SqlCommand command = new SqlCommand("GetArtistDetails", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter artistIDParam = new SqlParameter("@artistId", artistID);
                command.Parameters.Add(artistIDParam);

               

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string imageUrl = (string)reader["imageURL"];
                            string title = (string)reader["title"];

                            titleLabel.Text = title;
                            imageControl.ImageUrl = imageUrl;
                        }
                    }
                    else
                    {
                        // No rows returned
                        // Display error message or handle the situation as needed
                    }
                }
            }
        }
        catch (Exception ex)
        {
            string error = "Bağlantı hatası: " + ex.Message;
        }
    }
}
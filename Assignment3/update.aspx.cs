using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//add lib.
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;   //to use rges for the date

namespace Assignment3
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection cnDB = new SqlConnection();
        DataTable movieTable = new DataTable();
        DataTable genreTable = new DataTable();
        DataTable directorTable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            var cstr = System.Configuration.ConfigurationManager.ConnectionStrings["DB"];
            string strConn = cstr.ConnectionString;
            cnDB = new SqlConnection(strConn);
            if (!IsPostBack)
            {
                LoadTables();
                loadDropDownList();
            }
        }

        protected void LoadTables() {
            cnDB.Open();
            movieTable.Clear();
            string movieSQL = "select * from Movie";
            using (SqlCommand cmd = new SqlCommand(movieSQL, cnDB))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                movieTable.Load(dr);
                dr.Close();
            }
            genreTable.Clear();
            string genreSQL = "select * from Genre";
            using (SqlCommand cmd = new SqlCommand(genreSQL, cnDB))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                genreTable.Load(dr);
                dr.Close();
            }
            directorTable.Clear();
            string directorSQL = "select * from Director";
            using (SqlCommand cmd = new SqlCommand(directorSQL, cnDB))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                directorTable.Load(dr);
                dr.Close();
            }

            cnDB.Close();
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            LoadTables(); //to get the updated data in the table

            bool invalid = false;
            bool found = false;

            //if (movieID.Value.Length > 10) { Response.Write("<script>alert('rrrr');</script>"); }

            if (movieID.Value.Length > 10    || movieTitle.Value == ""   || movieReleaseDate.Value == "" ||
                genreID.Value.Length > 10    || genreType.Value == ""    || 
                directorID.Value.Length > 10 || directorName.Value == "" || directorNationality.Value == "")
            {
                invalid = true;
                Response.Write("<script>alert('wrong input');</script>");
            }

            //checking the date's pattern
            string sPattern = "[0-9]{4}-[0-9]{2}-[0-9]{2}";
            if (!Regex.IsMatch(movieReleaseDate.Value, sPattern)) {
                Response.Write("<script>alert('The date format is wrong, please make sure it is YYYY-MM-DD');</script>");
                invalid = true;
            }

            //check if the movie ID is already there
            for (int crow = 0; crow < movieTable.Rows.Count; crow++)
            {
                if (movieTable.Rows[crow][0].ToString() == movieID.Value)
                {
                    found = true;
                    Response.Write("<script>alert('Movie ID exists');</script>"); 
                }
            }

            if (!invalid && !found) {
                update();
                Response.Write("<script>alert('Movie has been added successfully!');</script>");
                LoadTables();    //load the tables again with the added movie
                loadDropDownList();
            }
        }

        protected void update() {
            cnDB.Open();
            string genresql = "Insert into Genre (GenreID, GenreType) Values (@gID, @gT)";
            using (SqlCommand cmd = new SqlCommand(genresql, cnDB))
            {
                // set up all parameters
                cmd.Parameters.Add("@gID", SqlDbType.VarChar);
                cmd.Parameters["@gID"].Value = genreID.Value;
                cmd.Parameters.Add("@gT", SqlDbType.VarChar);
                cmd.Parameters["@gT"].Value = genreType.Value;
                cmd.ExecuteNonQuery();
            }
            string directorsql = "Insert into Director (DirectorID, DirectorName, DirectorNationality) Values (@dID, @dN, @dNa)";
            using (SqlCommand cmd = new SqlCommand(directorsql, cnDB))
            {
                // set up all parameters
                cmd.Parameters.Add("@dID", SqlDbType.VarChar);
                cmd.Parameters["@dID"].Value = directorID.Value;
                cmd.Parameters.Add("@dN", SqlDbType.VarChar);
                cmd.Parameters["@dN"].Value = directorName.Value;
                cmd.Parameters.Add("@dNa", SqlDbType.VarChar);
                cmd.Parameters["@dNa"].Value = directorNationality.Value;
                cmd.ExecuteNonQuery();
            }
            string moviesql = "Insert into Movie (MovieID, MovieTitle, ReleaseDate, GenreID, DirectorID) Values (@mID, @mT, @mRD, @gID, @dID)";
            using (SqlCommand cmd = new SqlCommand(moviesql, cnDB))
            {
                // set up all parameters
                cmd.Parameters.Add("@mID", SqlDbType.VarChar);
                cmd.Parameters["@mID"].Value = movieID.Value;
                cmd.Parameters.Add("@mT", SqlDbType.VarChar);
                cmd.Parameters["@mT"].Value = movieTitle.Value;
                cmd.Parameters.Add("@mRD", SqlDbType.VarChar);
                cmd.Parameters["@mRD"].Value = movieReleaseDate.Value;
                cmd.Parameters.Add("@gID", SqlDbType.VarChar);
                cmd.Parameters["@gID"].Value = genreID.Value;
                cmd.Parameters.Add("@dID", SqlDbType.VarChar);
                cmd.Parameters["@dID"].Value = directorID.Value;
                cmd.ExecuteNonQuery();
            }
            cnDB.Close();
        }

        protected void loadDropDownList() {
            UpdateDropDownList.DataSource = movieTable;
            UpdateDropDownList.DataTextField = "MovieTitle";
            UpdateDropDownList.DataValueField = "MovieID";
            UpdateDropDownList.DataBind();
        }

        protected void UpdateDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ask how to remove this
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            cnDB.Open();
            string deleteSQL = "delete from Movie where MovieID = @mID";
            using (SqlCommand cmd = new SqlCommand(deleteSQL, cnDB))
            {
                cmd.Parameters.Add("@mID", SqlDbType.VarChar);
                cmd.Parameters["@mID"].Value = UpdateDropDownList.SelectedValue;
                cmd.ExecuteNonQuery();
            }
            cnDB.Close();
            Response.Write("<script>alert('Movie has been deleted successfully!');</script>");
            //update the table list and the drop down after removing something
            LoadTables();
            loadDropDownList();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//add lib.
using System.Data;
using System.Data.SqlClient;

namespace Assignment3
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection cnDB = new SqlConnection();
        DataTable genreTable = new DataTable();
        DataTable directorNameTable = new DataTable();
        DataTable directorTable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            var cstr = System.Configuration.ConfigurationManager.ConnectionStrings["DB"];
            string strConn = cstr.ConnectionString;
            cnDB = new SqlConnection(strConn);
            if (!IsPostBack)
            {
                loadDirectorDropDownList();
            }
        }

        protected void GenreButton_Click(object sender, EventArgs e)
        {
            cnDB.Open();
            string inject = "";
            string sql = "SELECT Movie.MovieTitle, Movie.ReleaseDate, Genre.GenreType FROM Genre INNER JOIN " +
                    "Movie ON Genre.GenreID = Movie.GenreID  where GenreType = @gT";
            if (genreRadioButtons.SelectedValue == "Action") { inject = "Action"; }
            else if (genreRadioButtons.SelectedValue == "Comedy") { inject = "Comedy"; }
            else if (genreRadioButtons.SelectedValue == "Drama") { inject = "Drama"; }

            using (SqlCommand cmd = new SqlCommand(sql, cnDB))
            {
                cmd.Parameters.Add("@gT", SqlDbType.VarChar);
                cmd.Parameters["@gT"].Value = inject;

                SqlDataReader dr = cmd.ExecuteReader();
                genreTable.Clear();
                genreTable.Load(dr);
                dr.Close();
            }
            cnDB.Close();

            GenreGridView.DataSource = genreTable;
            GenreGridView.DataBind();
        }

        protected void DirectorButton_Click(object sender, EventArgs e)
        {
            //ask how to remove this
        }



        protected void loadDirectorDropDownList()
        {
            cnDB.Open();

            string sql = "select distinct directorName from Director";
            using (SqlCommand cmd = new SqlCommand(sql, cnDB))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                directorNameTable.Clear();
                directorNameTable.Load(dr);
                dr.Close();
            }

            cnDB.Close();

            directorDropDownList.DataSource = directorNameTable;
            directorDropDownList.DataTextField = "directorName";
            directorDropDownList.DataValueField = "directorName";
            directorDropDownList.DataBind();
        }

        protected void directorDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDirectorGridView();
            DirectorGridView.DataSource = directorTable;
            DirectorGridView.DataBind();
        }

        protected void loadDirectorGridView()
        {
            cnDB.Open();
            string inject = "";
            string sql = "SELECT Movie.MovieTitle, Movie.ReleaseDate, Director.DirectorName " +
                            "FROM Director INNER JOIN Movie ON Director.DirectorID = Movie.DirectorID where directorName = @dName";
            if (directorDropDownList.SelectedValue == "Paul Thomas") { inject = "Paul Thomas"; }
            else if (directorDropDownList.SelectedValue == "Darren Aronofsky") { inject = "Darren Aronofsky"; }
            else if (directorDropDownList.SelectedValue == "David Fincher") { inject = "David Fincher"; }

            using (SqlCommand cmd = new SqlCommand(sql, cnDB))
            {
                cmd.Parameters.Add("@dName", SqlDbType.VarChar);
                cmd.Parameters["@dName"].Value = inject;

                SqlDataReader dr = cmd.ExecuteReader();
                directorTable.Clear();
                directorTable.Load(dr);
                dr.Close();
            }
            cnDB.Close();
        }
    }
}
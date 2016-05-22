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
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection cnDB = new SqlConnection();
        DataTable table = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            var cstr = System.Configuration.ConfigurationManager.ConnectionStrings["DB"];
            string strConn = cstr.ConnectionString;
            cnDB = new SqlConnection(strConn);


            if (!IsPostBack)
            {
                LoadTable();
                LoadDropDown();
            }
        }
        protected void LoadTable() {
            cnDB.Open();
            string sql = "select * from Movie";
            using (SqlCommand cmd = new SqlCommand(sql, cnDB))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                table.Load(dr);
                dr.Close();
            }
            cnDB.Close();
        }

        protected void LoadDropDown() {
            IndexDropDownList.DataSource = table;
            IndexDropDownList.DataTextField = "MovieTitle";
            IndexDropDownList.DataValueField = "MovieID";
            IndexDropDownList.DataBind();
        }

        protected void LoadDetailsView() {
            cnDB.Open();
            DataTable detailsViewTable = new DataTable();
            string sql = "SELECT Director.DirectorID, Director.DirectorName, Director.DirectorNationality, Movie.MovieID, Movie.MovieTitle, Movie.ReleaseDate, Movie.GenreID, Genre.GenreType" +
                          " FROM     Director INNER JOIN" +
                  " Movie ON Director.DirectorID = Movie.DirectorID INNER JOIN" +
                  " Genre ON Movie.GenreID = Genre.GenreID where Movie.MovieID = @ID";
            using (SqlCommand cmd = new SqlCommand(sql, cnDB))
            {
                cmd.Parameters.Add("@ID", SqlDbType.VarChar);
                cmd.Parameters["@id"].Value = IndexDropDownList.SelectedValue;

                SqlDataReader dr = cmd.ExecuteReader();
                detailsViewTable.Load(dr);
                dr.Close();
            }
            cnDB.Close();
            IndexDetailsView.DataSource = detailsViewTable;
            IndexDetailsView.DataBind();
        }

        protected void IndexDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDetailsView();
        }

    }
}
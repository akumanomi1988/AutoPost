using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.Presentation.Desktop.Controllers
{
    internal static class YTCategories
    {
        internal static DataTable Get()
        {
            var dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Name", typeof(string));

            dt.Rows.Add("1", "Film & Animation");
            dt.Rows.Add("2", "Autos & Vehicles");
            dt.Rows.Add("10", "Music");
            dt.Rows.Add("15", "Pets & Animals");
            dt.Rows.Add("17", "Sports");
            dt.Rows.Add("18", "Short Movies");
            dt.Rows.Add("19", "Travel & Events");
            dt.Rows.Add("20", "Gaming");
            dt.Rows.Add("21", "Videoblogging");
            dt.Rows.Add("22", "People & Blogs");
            dt.Rows.Add("23", "Comedy");
            dt.Rows.Add("24", "Entertainment");
            dt.Rows.Add("25", "News & Politics");
            dt.Rows.Add("26", "Howto & Style");
            dt.Rows.Add("27", "Education");
            dt.Rows.Add("28", "Science & Technology");
            dt.Rows.Add("29", "Nonprofits & Activism");
            dt.Rows.Add("30", "Movies");
            dt.Rows.Add("31", "Anime/Animation");
            dt.Rows.Add("32", "Action/Adventure");
            dt.Rows.Add("33", "Classics");
            dt.Rows.Add("34", "Comedy");
            dt.Rows.Add("35", "Documentary");
            dt.Rows.Add("36", "Drama");
            dt.Rows.Add("37", "Family");
            dt.Rows.Add("38", "Foreign");
            dt.Rows.Add("39", "Horror");
            dt.Rows.Add("40", "Sci-Fi/Fantasy");
            dt.Rows.Add("41", "Thriller");
            dt.Rows.Add("42", "Shorts");
            dt.Rows.Add("43", "Shows");
            dt.Rows.Add("44", "Trailers");

            return dt;
        }
        internal static string GetID(string Category)
        {
            var dt = Get();
            var dv = dt.DefaultView;

            dv.RowFilter = $"Name = '{Category}'"; // Asegúrate de manejar correctamente las comillas simples en el nombre de la categoría

            if (dv.Count > 0)
            {
                DataRow row = dv[0].Row; // Obtener la primera fila que coincida con el filtro
                return row["ID"].ToString() ?? "0"; // Devolver el valor del ID
            }
            else
            {
                return "-1";
            }
        }

    }
}

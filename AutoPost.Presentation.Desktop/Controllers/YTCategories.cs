using System.Data;

namespace AutoPost.Presentation.Desktop.Controllers
{
    internal static class YTCategories
    {
        internal static DataTable Get()
        {
            DataTable dt = new();
            _ = dt.Columns.Add("ID", typeof(string));
            _ = dt.Columns.Add("Name", typeof(string));

            _ = dt.Rows.Add("1", "Film & Animation");
            _ = dt.Rows.Add("2", "Autos & Vehicles");
            _ = dt.Rows.Add("10", "Music");
            _ = dt.Rows.Add("15", "Pets & Animals");
            _ = dt.Rows.Add("17", "Sports");
            _ = dt.Rows.Add("18", "Short Movies");
            _ = dt.Rows.Add("19", "Travel & Events");
            _ = dt.Rows.Add("20", "Gaming");
            _ = dt.Rows.Add("21", "Videoblogging");
            _ = dt.Rows.Add("22", "People & Blogs");
            _ = dt.Rows.Add("23", "Comedy");
            _ = dt.Rows.Add("24", "Entertainment");
            _ = dt.Rows.Add("25", "News & Politics");
            _ = dt.Rows.Add("26", "Howto & Style");
            _ = dt.Rows.Add("27", "Education");
            _ = dt.Rows.Add("28", "Science & Technology");
            _ = dt.Rows.Add("29", "Nonprofits & Activism");
            _ = dt.Rows.Add("30", "Movies");
            _ = dt.Rows.Add("31", "Anime/Animation");
            _ = dt.Rows.Add("32", "Action/Adventure");
            _ = dt.Rows.Add("33", "Classics");
            _ = dt.Rows.Add("34", "Comedy");
            _ = dt.Rows.Add("35", "Documentary");
            _ = dt.Rows.Add("36", "Drama");
            _ = dt.Rows.Add("37", "Family");
            _ = dt.Rows.Add("38", "Foreign");
            _ = dt.Rows.Add("39", "Horror");
            _ = dt.Rows.Add("40", "Sci-Fi/Fantasy");
            _ = dt.Rows.Add("41", "Thriller");
            _ = dt.Rows.Add("42", "Shorts");
            _ = dt.Rows.Add("43", "Shows");
            _ = dt.Rows.Add("44", "Trailers");

            return dt;
        }
        internal static string GetID(string Category)
        {
            DataTable dt = Get();
            DataView dv = dt.DefaultView;

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

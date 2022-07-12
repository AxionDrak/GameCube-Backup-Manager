using System.Data;
using System.Text;

namespace GCBM
{
    internal class ExportDataTableToHTML
    {
        protected string ExportDatatableToHtml(DataTable dt)
        {
            var strHTMLBuilder = new StringBuilder();
            strHTMLBuilder.Append("<html >");
            strHTMLBuilder.Append("<!doctype html>");
            strHTMLBuilder.Append("<html class=\"no-js\" lang=\"en\" dir=\"ltr\">");
            strHTMLBuilder.Append("<head>");
            strHTMLBuilder.Append("<meta charset=\"utf-8\">");
            strHTMLBuilder.Append("<meta http-equiv=\"x-ua-compatible\" content=\"ie=edge\">");
            strHTMLBuilder.Append("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
            strHTMLBuilder.Append("<title>GameCube Backups</title>");
            strHTMLBuilder.Append("<link rel=\"stylesheet\" href=\"css/foundation.css\">");
            strHTMLBuilder.Append("<link rel=\"stylesheet\" href=\"css/app.css\">");
            strHTMLBuilder.Append("<link rel=\"preconnect\" href=\"https://fonts.googleapis.com\">");
            strHTMLBuilder.Append("<link rel=\"preconnect\" href=\"https://fonts.googleapis.com\">");
            strHTMLBuilder.Append("<link rel=\"preconnect\" href=\"https://fonts.gstatic.com\" crossorigin>");
            strHTMLBuilder.Append(
                "<link href=\"https://fonts.googleapis.com/css2?family=Raleway:wght@100&display=swap\" rel=\"stylesheet\">");
            strHTMLBuilder.Append(
                "<link href=\"https://fonts.googleapis.com/css2?family=Open+Sans:wght@300&display=swap\" rel=\"stylesheet\">");
            strHTMLBuilder.Append("<style>");
            strHTMLBuilder.Append("@font-face {");
            strHTMLBuilder.Append("font-family: \"OpenSans\";");
            strHTMLBuilder.Append("src: url(\"./resources/OpenSans-Light.ttf\");");
            strHTMLBuilder.Append("}");
            strHTMLBuilder.Append("@font-face {");
            strHTMLBuilder.Append("font-family: \"Raleway\";");
            strHTMLBuilder.Append("src: url(\"./resources/Raleway-Thin.ttf\");");
            strHTMLBuilder.Append("}");
            strHTMLBuilder.Append("</style>");
            strHTMLBuilder.Append("</head>");
            strHTMLBuilder.Append("<body>");
            strHTMLBuilder.Append("<header class=\"grid-container\">");
            strHTMLBuilder.Append("<div class=\"grid-x grid-padding-x\">");
            strHTMLBuilder.Append("<div class=\"large-12 cell\">");
            strHTMLBuilder.Append("<h1>GameCube Backups</h1>");
            strHTMLBuilder.Append("</div>");
            strHTMLBuilder.Append("</div>");
            strHTMLBuilder.Append("</header>");
            strHTMLBuilder.Append("<div class=\"container\">");
            strHTMLBuilder.Append("<table>");
            strHTMLBuilder.Append("<tr >");
            foreach (DataColumn myColumn in dt.Columns)
            {
                strHTMLBuilder.Append("<td >");
                strHTMLBuilder.Append(myColumn.ColumnName);
                strHTMLBuilder.Append("</td>");
            }

            strHTMLBuilder.Append("</tr>");
            foreach (DataRow myRow in dt.Rows)
            {
                strHTMLBuilder.Append("<tr >");
                foreach (DataColumn myColumn in dt.Columns)
                {
                    strHTMLBuilder.Append("<td >");
                    strHTMLBuilder.Append(myRow[myColumn.ColumnName]);
                    strHTMLBuilder.Append("</td>");
                }

                strHTMLBuilder.Append("</tr>");
            }

            //Close tags.
            strHTMLBuilder.Append("</table>");
            strHTMLBuilder.Append("<script src=\"js/vendor/jquery.js\"></script>");
            strHTMLBuilder.Append("<script src=\"js/vendor/what - input.js\"></script>");
            strHTMLBuilder.Append("<script src=\"js/vendor/foundation.js\"></script>");
            strHTMLBuilder.Append("<script src=\"js/app.js\"></script>");
            strHTMLBuilder.Append("</body>");
            strHTMLBuilder.Append("</body><footer><span>&copy;2022 Sean Johnson</span></footer>");
            strHTMLBuilder.Append("</html>");
            var Htmltext = strHTMLBuilder.ToString();
            return Htmltext;
        }
    }
}
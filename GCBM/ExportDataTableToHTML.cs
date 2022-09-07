using System.Data;
using System.Text;

namespace GCBM;

internal class ExportDataTableToHTML
{
    protected string ExportDatatableToHtml(DataTable dt)
    {
        var strHTMLBuilder = new StringBuilder();
        _ = strHTMLBuilder.Append("<html >");
        _ = strHTMLBuilder.Append("<!doctype html>");
        _ = strHTMLBuilder.Append("<html class=\"no-js\" lang=\"en\" dir=\"ltr\">");
        _ = strHTMLBuilder.Append("<head>");
        _ = strHTMLBuilder.Append("<meta charset=\"utf-8\">");
        _ = strHTMLBuilder.Append("<meta http-equiv=\"x-ua-compatible\" content=\"ie=edge\">");
        _ = strHTMLBuilder.Append("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
        _ = strHTMLBuilder.Append("<title>GameCube Backups</title>");
        _ = strHTMLBuilder.Append("<link rel=\"stylesheet\" href=\"css/foundation.css\">");
        _ = strHTMLBuilder.Append("<link rel=\"stylesheet\" href=\"css/app.css\">");
        _ = strHTMLBuilder.Append("<link rel=\"preconnect\" href=\"https://fonts.googleapis.com\">");
        _ = strHTMLBuilder.Append("<link rel=\"preconnect\" href=\"https://fonts.googleapis.com\">");
        _ = strHTMLBuilder.Append("<link rel=\"preconnect\" href=\"https://fonts.gstatic.com\" crossorigin>");
        _ = strHTMLBuilder.Append(
            "<link href=\"https://fonts.googleapis.com/css2?family=Raleway:wght@100&display=swap\" rel=\"stylesheet\">");
        _ = strHTMLBuilder.Append(
            "<link href=\"https://fonts.googleapis.com/css2?family=Open+Sans:wght@300&display=swap\" rel=\"stylesheet\">");
        _ = strHTMLBuilder.Append("<style>");
        _ = strHTMLBuilder.Append("@font-face {");
        _ = strHTMLBuilder.Append("font-family: \"OpenSans\";");
        _ = strHTMLBuilder.Append("src: url(\"./resources/OpenSans-Light.ttf\");");
        _ = strHTMLBuilder.Append("}");
        _ = strHTMLBuilder.Append("@font-face {");
        _ = strHTMLBuilder.Append("font-family: \"Raleway\";");
        _ = strHTMLBuilder.Append("src: url(\"./resources/Raleway-Thin.ttf\");");
        _ = strHTMLBuilder.Append("}");
        _ = strHTMLBuilder.Append("</style>");
        _ = strHTMLBuilder.Append("</head>");
        _ = strHTMLBuilder.Append("<body>");
        _ = strHTMLBuilder.Append("<header class=\"grid-container\">");
        _ = strHTMLBuilder.Append("<div class=\"grid-x grid-padding-x\">");
        _ = strHTMLBuilder.Append("<div class=\"large-12 cell\">");
        _ = strHTMLBuilder.Append("<h1>GameCube Backups</h1>");
        _ = strHTMLBuilder.Append("</div>");
        _ = strHTMLBuilder.Append("</div>");
        _ = strHTMLBuilder.Append("</header>");
        _ = strHTMLBuilder.Append("<div class=\"container\">");
        _ = strHTMLBuilder.Append("<table>");
        _ = strHTMLBuilder.Append("<tr >");
        foreach (DataColumn myColumn in dt.Columns)
        {
            _ = strHTMLBuilder.Append("<td >");
            _ = strHTMLBuilder.Append(myColumn.ColumnName);
            _ = strHTMLBuilder.Append("</td>");
        }

        _ = strHTMLBuilder.Append("</tr>");
        foreach (DataRow myRow in dt.Rows)
        {
            _ = strHTMLBuilder.Append("<tr >");
            foreach (DataColumn myColumn in dt.Columns)
            {
                _ = strHTMLBuilder.Append("<td >");
                _ = strHTMLBuilder.Append(myRow[myColumn.ColumnName]);
                _ = strHTMLBuilder.Append("</td>");
            }

            _ = strHTMLBuilder.Append("</tr>");
        }

        //Close tags.
        _ = strHTMLBuilder.Append("</table>");
        _ = strHTMLBuilder.Append("<script src=\"js/vendor/jquery.js\"></script>");
        _ = strHTMLBuilder.Append("<script src=\"js/vendor/what - input.js\"></script>");
        _ = strHTMLBuilder.Append("<script src=\"js/vendor/foundation.js\"></script>");
        _ = strHTMLBuilder.Append("<script src=\"js/app.js\"></script>");
        _ = strHTMLBuilder.Append("</body>");
        _ = strHTMLBuilder.Append("</body><footer><span>&copy;2022 Sean Johnson</span></footer>");
        _ = strHTMLBuilder.Append("</html>");
        var Htmltext = strHTMLBuilder.ToString();
        return Htmltext;
    }
}
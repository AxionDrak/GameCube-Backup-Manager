using System;
using System.Data;
using System.IO;
using System.Linq;

namespace GCBM;

internal static class DataTableToCSV
{
    public static void ToCSV(this DataTable dtDataTable, string strFilePath)
    {
        var sw = new StreamWriter(strFilePath, false);
        //headers    
        for (var i = 0; i < dtDataTable.Columns.Count; i++)
        {
            sw.Write(dtDataTable.Columns[i]);
            if (i < dtDataTable.Columns.Count - 1) sw.Write(",");
        }

        sw.Write(sw.NewLine);
        foreach (DataRow dr in dtDataTable.Rows)
        {
            for (var i = 0; i < dtDataTable.Columns.Count; i++)
            {
                if (!Convert.IsDBNull(dr[i]))
                {
                    var value = dr[i].ToString();
                    if (value.Contains(','))
                    {
                        value = string.Format("\"{0}\"", value);
                        sw.Write(value);
                    }
                    else
                    {
                        sw.Write(dr[i].ToString());
                    }
                }

                if (i < dtDataTable.Columns.Count - 1) sw.Write(",");
            }

            sw.Write(sw.NewLine);
        }

        sw.Close();
    }
}
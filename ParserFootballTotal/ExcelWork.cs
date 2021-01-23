using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Style.XmlAccess;
using System.Drawing;

namespace ParserFootballTotal
{
    class ExcelWork
    {
        public static ExcelNamedStyleXml getExcelStyle(string nameFont, int sizeFont, string color, ExcelNamedStyleXml style)
        {
            style.Style.Font.Name = nameFont;
            style.Style.Font.Size = sizeFont;
            style.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            style.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            style.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            style.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            style.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            if (color != "")
            {
                style.Style.Fill.PatternType = ExcelFillStyle.Solid;
                style.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(color));
            }

            return style;
        }



        //in future, need to add a func deleteemptyrows for sort, and sort itself
    }
}

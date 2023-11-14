using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace FedoreevOrganization
{
    internal class Excel
    {
        public static void excelReportProducts(List<reportProducts> report, string fileName)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            if (report != null)
            {
                Workbook wb = excelApp.Workbooks.Open(fileName,
                                                     0,
                                                     false,
                                                     5,
                                                     "",
                                                     "",
                                                     false,
                                                     XlPlatform.xlWindows,
                                                     "",
                                                     true,
                                                     false,
                                                     0,
                                                     true,
                                                     false,
                                                     false);
                Worksheet ws = wb.Sheets[1];
                ws.Cells[1][1] = "Продукт";
                ws.Cells[2][1] = "Закантрактованных";
                ws.Cells[3][1] = "Оплаченных";
                ws.Cells[4][1] = "Закантр./Оплач.";
                for (int i = 0; i < report.Count; i++)
                {
                    ws.Cells[1][i + 2] = report[i].name;
                    ws.Cells[2][i + 2] = report[i].numOfContracted;
                    ws.Cells[3][i + 2] = report[i].numOfPayed;
                    if(report[i].numOfPayed == 0)
                        ws.Cells[4][i + 2] = 0;
                    else
                        ws.Cells[4][i + 2] = Convert.ToDouble(report[i].numOfContracted) / Convert.ToDouble(report[i].numOfPayed);
                }

                wb.Save();
                wb.Close();
            }
        }
        public static void excelReportClients(List<reportClients> report, string fileName)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            if (report != null)
            {
                Workbook wb = excelApp.Workbooks.Open(fileName,
                                                     0,
                                                     false,
                                                     5,
                                                     "",
                                                     "",
                                                     false,
                                                     XlPlatform.xlWindows,
                                                     "",
                                                     true,
                                                     false,
                                                     0,
                                                     true,
                                                     false,
                                                     false);
                Worksheet ws = wb.Sheets[1];
                ws.Cells[1][1] = "Клиенты";
                ws.Cells[2][1] = "Продукты";
                ws.Cells[3][1] = "Кол-во доставленных";
                ws.Cells[4][1] = "Необходимо доставить";
                for (int i = 0; i < report.Count; i++)
                {
                    ws.Cells[1][i + 2] = report[i].clientName;
                    ws.Cells[2][i + 2] = report[i].productName;
                    ws.Cells[3][i + 2] = report[i].numOfDeliverys;
                    ws.Cells[4][i + 2] = report[i].numOfPayedButNotDelivery;
                }

                wb.Save();
                wb.Close();
            }
        }
        public static void excelReportContract(List<reportContract> report, string fileName)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            if (report != null)
            {
                Workbook wb = excelApp.Workbooks.Open(fileName,
                                                     0,
                                                     false,
                                                     5,
                                                     "",
                                                     "",
                                                     false,
                                                     XlPlatform.xlWindows,
                                                     "",
                                                     true,
                                                     false,
                                                     0,
                                                     true,
                                                     false,
                                                     false);
                Worksheet ws = wb.Sheets[1];
                ws.Cells[1][1] = "Продукт";
                ws.Cells[2][1] = "Количество";
                ws.Cells[3][1] = "Общая сумма";
                for (int i = 0; i < report.Count; i++)
                {
                    ws.Cells[1][i + 2] = report[i].productName;
                    ws.Cells[2][i + 2] = report[i].amount;
                    ws.Cells[3][i + 2] = report[i].summ;
                }

                wb.Save();
                wb.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace CardCenter.PageBase
{
    public class ExcelHelper
    {

        /// <summary>
        /// 获取EXCEL数组
        /// </summary>
        /// <param name="dt"></param>       
        public static byte[] GetExcelFileByte(DataSet ds)
        {
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();

            //设置样式
            NPOI.SS.UserModel.ICellStyle style1 = book.CreateCellStyle();
            NPOI.SS.UserModel.IFont font1 = book.CreateFont();
            style1.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            font1.IsBold = true;
            style1.SetFont(font1);
            NPOI.SS.UserModel.ICellStyle style2 = book.CreateCellStyle();
            style2.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;

            byte[] fileByte = null;
            for (int k = 0; k < ds.Tables.Count; k++)
            {
                try
                {
                    DataTable dt = ds.Tables[k];
                    if (null != dt && dt.Rows.Count > 0)
                    {

                        if (dt.TableName == null || dt.TableName == "")
                        {
                            dt.TableName = "Sheet1";
                        }
                        NPOI.SS.UserModel.ISheet sheet = book.CreateSheet(dt.TableName);
                        sheet.DefaultColumnWidth = 20;
                        NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            row.CreateCell(i).SetCellValue(dt.Columns[i].ColumnName);
                            row.Cells[i].CellStyle = style1;
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            NPOI.SS.UserModel.IRow row2 = sheet.CreateRow(i + 1);
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                row2.CreateCell(j).SetCellValue(Convert.ToString(dt.Rows[i][j]));
                                row2.Cells[j].CellStyle = style2;
                            }
                        }
                       
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

            try
            {
                // 写入到客户端  
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    book.Write(ms);
                    fileByte = ms.GetBuffer();
                    //using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    //{
                    //    byte[] data = ms.ToArray();
                    //    fs.Write(data, 0, data.Length);
                    //    fs.Flush();
                    //}

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (null != book)
                {
                    book.Close();
                    book = null;
                }
            }
            return fileByte;
        }
        /// <summary>
        /// 导出EXCEL
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="filePath"></param>
        public static void WriteExcel(DataTable dt, string filePath)
        {
            if (!string.IsNullOrEmpty(filePath) && null != dt && dt.Rows.Count > 0)
            {
                NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
                try
                {


                    NPOI.SS.UserModel.ISheet sheet = book.CreateSheet(dt.TableName);

                    NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        row.CreateCell(i).SetCellValue(dt.Columns[i].ColumnName);
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        NPOI.SS.UserModel.IRow row2 = sheet.CreateRow(i + 1);
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            row2.CreateCell(j).SetCellValue(Convert.ToString(dt.Rows[i][j]));
                        }
                    }
                    // 写入到客户端  
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        book.Write(ms);
                        using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                        {
                            byte[] data = ms.ToArray();
                            fs.Write(data, 0, data.Length);
                            fs.Flush();
                        }
                        book = null;
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
                finally
                {
                    book.Close();
                    book = null;
                }
            }
        }
    }
}

using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace CSPN.helper
{
    public class ExcelHelper
    {
        /// <summary>
        /// 读入Excel的数据 在DataGridView中显示
        /// </summary>
        /// <param name="dgv">显示内容的DataTable的名称</param>
        public void setExcel(DataTable dt)
        {
            //选择创建文件的路径
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel 97-2003工作簿|*.xls|Excel 工作簿|*.xlsx";
            save.Title = "请选择要导出数据的位置";
            save.FileName = "";
            if (save.ShowDialog() == DialogResult.OK)
            {
                string fileName = save.FileName;
                //把读取到的数据写入到Excel中
                //创建workbook对象
                IWorkbook wk = null;
                if (save.FilterIndex == 1)
                {
                    wk = new HSSFWorkbook();
                }
                else
                {
                    wk = new XSSFWorkbook();
                }
                ISheet sheet = wk.CreateSheet("人井监控管理系统");
                int index = 0;
                // 添加表头
                IRow row = sheet.CreateRow(0);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ICell cell = row.CreateCell(index);
                    cell.SetCellType(CellType.String);
                    cell.SetCellValue(dt.Columns[i].ColumnName);
                    index++;
                }
                // 添加数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    index = 0;
                    row = sheet.CreateRow(i + 1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ICell cell = row.CreateCell(index);
                        cell.SetCellType(CellType.String);
                        cell.SetCellValue(dt.Rows[i][j].ToString());
                        index++;
                    }
                }
                // 写入
                MemoryStream ms = new MemoryStream();
                try
                {
                    wk.Write(ms);
                    wk = null;
                    using (FileStream fs = new FileStream(save.FileName, FileMode.Create, FileAccess.Write))
                    {
                        byte[] data = ms.ToArray();
                        fs.Write(data, 0, data.Length);
                        fs.Flush();
                    }
                    MessageBox.Show("导出成功", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(ex.Message, ex);
                    MessageBox.Show("导出失败，文件可能正在使用中", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    ms.Close();
                }
            }
        }
    }
}

using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSPN.helper
{
    public class ExcelHelper
    {
        /// <summary>
        /// 读入Excel的数据 在DataGridView中显示
        /// </summary>
        /// <param name="dgv">显示内容的DataGridView的名称</param>
        public void setExcel(DataGridView dgv)
        {
            //总可见列数，总可见行数
            int colCount = dgv.Columns.GetColumnCount(DataGridViewElementStates.Visible);
            int rowCount = dgv.Rows.GetRowCount(DataGridViewElementStates.Visible);
            //dataGridView 没有数据提示
            if (dgv.Rows.Count == 0 || rowCount == 0)
            {
                MessageBox.Show("表中没有数据", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //选择创建文件的路径
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel Files (*.xls,*.xlsx)|*.xls;*.xlsx";
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
                    ISheet sheet = wk.CreateSheet("CSPN");
                    int index = 0;
                    // 添加表头
                    IRow row = sheet.CreateRow(0);
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        if (dgv.Columns[i].Visible)  //不导出隐藏的列
                        {
                            ICell cell = row.CreateCell(index);
                            cell.SetCellType(CellType.String);
                            cell.SetCellValue(dgv.Columns[i].HeaderText);
                            index++;
                        }
                    }
                    // 添加数据
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        index = 0;
                        row = sheet.CreateRow(i + 1);
                        for (int j = 0; j < dgv.ColumnCount; j++)
                        {
                            if (dgv.Columns[j].Visible)  //不导出隐藏的列
                            {
                                ICell cell = row.CreateCell(index);
                                cell.SetCellType(CellType.String);
                                cell.SetCellValue(dgv[j, i].Value.ToString());
                                index++;
                            }
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
                        ms.Dispose();
                    }
                }
            }
        }
    }
}

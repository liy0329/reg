using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace MTHIS.common
{
    class DataGridViewUtils
    {
        /// <summary>
        /// 使datagridview的指定列为只读:new string[] { "state" }
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="noReadOnlyColumnNames"></param>
        public static void setDataGridViewReadOnlyTarget(DataGridView dgv, string[] readOnlyColumnNames)
        {
            List<string> columnNames = getDataGridViewColumnNames(dgv, true);
            if (columnNames.Count <= 0)
                return;

            bool flag = readOnlyColumnNames != null && readOnlyColumnNames.Length > 0;
            foreach (string columnName in columnNames)
            {
                if (flag && readOnlyColumnNames.Contains(columnName))
                    dgv.Columns[columnName].ReadOnly = true;
                else
                    dgv.Columns[columnName].ReadOnly = false;
            }
        }
        /// <summary>
        /// 使datagridview为只读，而指定列取消只读:new string[] { "state" }
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="noReadOnlyColumnNames"></param>
        public static void setDataGridViewReadOnlyCancelTarget(DataGridView dgv, string[] noReadOnlyColumnNames)
        {
            List<string> columnNames = getDataGridViewColumnNames(dgv, true);
            if (columnNames.Count <= 0)
                return;

            bool flag = noReadOnlyColumnNames != null && noReadOnlyColumnNames.Length > 0;
            foreach (string columnName in columnNames)
            {
                if (flag && noReadOnlyColumnNames.Contains(columnName))
                    dgv.Columns[columnName].ReadOnly = false;
                else
                    dgv.Columns[columnName].ReadOnly = true;
            }
        }

        /// <summary>
        /// 设置datagridview的显示列为自动列宽且不可排序
        /// </summary>
        /// <param name="dgv"></param>
        public static void setAutoWithNotSort(DataGridView dgv, bool isAutoWith, bool isNotSort)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    if (isAutoWith)
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    if (isNotSort)
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }

        /// <summary>
        /// 获取所有列名
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="isOnlyVisible">是否仅获取Visible为true的</param>
        /// <returns></returns>
        public static List<string> getDataGridViewColumnNames(DataGridView dgv, bool isOnlyVisible)
        {
            List<string> list = new List<string>();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (isOnlyVisible)
                {
                    if (column.Visible)
                    {
                        list.Add(column.Name);
                    }
                }
                else
                {
                    list.Add(column.Name);
                }
            }
            return list;
        }

        /// <summary>
        /// 清空数据源为DataTable的DataGridView
        /// </summary>
        /// <param name="dgv"></param>
        public static void clearDataGridViewForDataTable(DataGridView dgv)
        {
            DataTable dt = dgv.DataSource as DataTable;
            if (dt == null)
                return;
            dt.Rows.Clear();
            dgv.DataSource = dt;
            dgv.ClearSelection();
        }

        /// <summary>
        /// 为datagridview添加绘制编号事件
        /// </summary>
        /// <param name="dgv"></param>
        public static void paintRowNumber(DataGridView dgv)
        {
            dgv.RowPostPaint += delegate(object sender, DataGridViewRowPostPaintEventArgs e)
            {
                System.Drawing.Rectangle rectangle =
                    new System.Drawing.Rectangle(e.RowBounds.Location.X
                            , e.RowBounds.Location.Y
                            , dgv.RowHeadersWidth - 4
                            , e.RowBounds.Height);

                TextRenderer.DrawText(e.Graphics,
                        (e.RowIndex + 1).ToString(),
                        dgv.RowHeadersDefaultCellStyle.Font,
                        rectangle,
                        dgv.RowHeadersDefaultCellStyle.ForeColor,
                        TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
            };
        }

        /// <summary>
        /// 定位当前行为最后一行
        /// </summary>
        /// <param name="dgv"></param>
        public static void setLastRowIsCurrent(DataGridView dgv, bool isSelectRow)
        {
            int rowNum = dgv.Rows.Count;
            if (rowNum > 0)
            {
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (col.Visible)
                    {
                        dgv.CurrentCell = dgv.Rows[rowNum - 1].Cells[col.Index];
                        if (isSelectRow || dgv.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
                            dgv.CurrentRow.Selected = true;
                        break;
                    }
                }
            }
        }

    }
}

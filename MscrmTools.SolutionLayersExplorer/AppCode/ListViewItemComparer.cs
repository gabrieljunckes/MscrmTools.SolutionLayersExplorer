﻿using System.Collections;
using System.Windows.Forms;

namespace MscrmTools.SolutionLayersExplorer.AppCode
{
    /// <summary>
    /// Compares two listview items for sorting
    /// </summary>
    internal class ListViewItemComparer : IComparer
    {
        #region Variables

        /// <summary>
        /// Index of sorting column
        /// </summary>
        private readonly int col;

        /// <summary>
        /// Sort order
        /// </summary>
        private readonly SortOrder innerOrder;

        private bool isNumericColumn = false;

        #endregion Variables

        #region Constructors

        /// <summary>
        /// Initializes a new instance of class ListViewItemComparer
        /// </summary>
        public ListViewItemComparer()
        {
            col = 0;
            innerOrder = SortOrder.Ascending;
        }

        /// <summary>
        /// Initializes a new instance of class ListViewItemComparer
        /// </summary>
        /// <param name="column">Index of sorting column</param>
        /// <param name="order">Sort order</param>
        public ListViewItemComparer(int column, SortOrder order)
        {
            col = column;
            innerOrder = order;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Compare tow objects
        /// </summary>
        /// <param name="x">object 1</param>
        /// <param name="y">object 2</param>
        /// <returns></returns>
        public int Compare(object x, object y)
        {
            return Compare((ListViewItem)x, (ListViewItem)y);
        }

        /// <summary>
        /// Compare tow listview items
        /// </summary>
        /// <param name="x">Listview item 1</param>
        /// <param name="y">Listview item 2</param>
        /// <returns></returns>
        public int Compare(ListViewItem x, ListViewItem y)
        {
            isNumericColumn = int.TryParse(x.SubItems[col].Text, out int _);

            if (isNumericColumn)
            {
                if (innerOrder == SortOrder.Ascending)
                {
                    return int.Parse(x.SubItems[col].Text) > int.Parse(y.SubItems[col].Text) ? 1 : 0;
                }

                return int.Parse(y.SubItems[col].Text) > int.Parse(x.SubItems[col].Text) ? 1 : 0;
            }
            else
            {
                if (innerOrder == SortOrder.Ascending)
                {
                    return string.CompareOrdinal(x.SubItems[col].Text, y.SubItems[col].Text);
                }

                return string.CompareOrdinal(y.SubItems[col].Text, x.SubItems[col].Text);
            }
        }

        #endregion Methods
    }
}
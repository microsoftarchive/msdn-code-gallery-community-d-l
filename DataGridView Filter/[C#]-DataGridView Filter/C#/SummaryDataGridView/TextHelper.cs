using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace SummaryDataGridView
{
    public static class TextHelper
    {
        public static StringAlignment TranslateAligment(HorizontalAlignment aligment)
        {
            if (aligment == HorizontalAlignment.Left)
                return StringAlignment.Near;
            else if (aligment == HorizontalAlignment.Right)
                return StringAlignment.Far;
            else
                return StringAlignment.Center;
        }

        public static HorizontalAlignment TranslateGridColumnAligment(DataGridViewContentAlignment aligment)
        {
            if (aligment == DataGridViewContentAlignment.BottomLeft || aligment == DataGridViewContentAlignment.MiddleLeft || aligment == DataGridViewContentAlignment.TopLeft)
                return HorizontalAlignment.Left;
            else if (aligment == DataGridViewContentAlignment.BottomRight || aligment == DataGridViewContentAlignment.MiddleRight || aligment == DataGridViewContentAlignment.TopRight)
                return HorizontalAlignment.Right;
            else
                return HorizontalAlignment.Left;
        }

        public static TextFormatFlags TranslateAligmentToFlag(HorizontalAlignment aligment)
        {
            if (aligment == HorizontalAlignment.Left)
                return TextFormatFlags.Left;
            else if (aligment == HorizontalAlignment.Right)
                return TextFormatFlags.Right;
            else
                return TextFormatFlags.HorizontalCenter;
        }

        public static TextFormatFlags TranslateTrimmingToFlag(StringTrimming trimming)
        {
            if (trimming == StringTrimming.EllipsisCharacter)
                return TextFormatFlags.EndEllipsis;
            else if (trimming == StringTrimming.EllipsisPath)
                return TextFormatFlags.PathEllipsis;
            if (trimming == StringTrimming.EllipsisWord)
                return TextFormatFlags.WordEllipsis;
            if (trimming == StringTrimming.Word)
                return TextFormatFlags.WordBreak;
            else
                return TextFormatFlags.Default;
        }
    }
}

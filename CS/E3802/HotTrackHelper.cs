using System;
using System.Collections.Generic;

using System.Text;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.ViewInfo;
using System.Drawing;
using DevExpress.XtraEditors.ViewInfo;

namespace treelist
{
    class HotTrackHelper
    {
        TreeList Tree;
        TreeListNode hotNode;


        public HotTrackHelper(TreeList treeList)
        {
            
            Attach(treeList);
        }
        public void Attach(TreeList treeList)
        {
            Tree = treeList;
            Tree.CustomDrawNodeIndent += new CustomDrawNodeIndentEventHandler(Tree_CustomDrawNodeIndent);
            Tree.CustomDrawNodeCell += new CustomDrawNodeCellEventHandler(Tree_CustomDrawNodeCell);
            Tree.MouseMove += new System.Windows.Forms.MouseEventHandler(Tree_MouseMove);

            Tree.OptionsSelection.EnableAppearanceFocusedCell = false;

        }

        void Tree_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            TreeListHitTest hi = Tree.ViewInfo.GetHitTest(e.Location);
            {
                if (hotNode != hi.Node)
                {
                    Tree.RefreshNode(hotNode);
                    hotNode = hi.Node;
                    Tree.RefreshNode(hotNode);

                }
            }
        }

        void Tree_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            DrawBackGround(e.Node, e);
        }

        void Tree_CustomDrawNodeIndent(object sender, CustomDrawNodeIndentEventArgs e)
        {
            DrawBackGround(e.Node, e);
            e.Handled = true;
        }

        void DrawBackGround(TreeListNode node, CustomDrawEventArgs e)
        {
            if (hotNode != node && !node.Focused) return;
            SimpleButton backButton = new SimpleButton();
            Tree.FindForm().Controls.Add(backButton);

            RowInfo ri = Tree.ViewInfo.RowsInfo[node];
            backButton.Bounds = ri.Bounds;
            Bitmap bm = new Bitmap(backButton.Width, backButton.Height);
            backButton.DrawToBitmap(bm, new Rectangle(0, 0, bm.Width, bm.Height));
            Rectangle rec = Rectangle.Intersect(ri.Bounds, e.Bounds);
            rec.Offset(-ri.Bounds.X, -ri.Bounds.Y);
            e.Graphics.DrawImage(bm, e.Bounds, rec, GraphicsUnit.Pixel);
            Tree.FindForm().Controls.Remove(backButton);
        }
        public void Detach()
        {
            Tree.CustomDrawNodeIndent += new CustomDrawNodeIndentEventHandler(Tree_CustomDrawNodeIndent);
            Tree.CustomDrawNodeCell += new CustomDrawNodeCellEventHandler(Tree_CustomDrawNodeCell);
            Tree.MouseMove += new System.Windows.Forms.MouseEventHandler(Tree_MouseMove);
            Tree.OptionsSelection.EnableAppearanceFocusedCell = true;

        }

    }
}

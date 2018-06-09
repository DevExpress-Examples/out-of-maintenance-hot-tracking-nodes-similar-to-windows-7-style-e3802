using System;
using System.Collections.Generic;

using System.Text;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.ViewInfo;
using System.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;

namespace treelist
{
    class HotTrackHelper
    {
        TreeList fTreeList;
        TreeListNode hotNode;
        SkinEditorButtonPainter customButtonPainter;
        EditorButtonObjectInfoArgs args;

        public HotTrackHelper(TreeList treeList)
        {
            Attach(treeList);
        }
        public void Attach(TreeList treeList)
        {
            fTreeList = treeList;
            fTreeList.CustomDrawNodeIndent += new CustomDrawNodeIndentEventHandler(Tree_CustomDrawNodeIndent);
            fTreeList.CustomDrawNodeCell += new CustomDrawNodeCellEventHandler(Tree_CustomDrawNodeCell);
            fTreeList.MouseMove += new System.Windows.Forms.MouseEventHandler(Tree_MouseMove);

            fTreeList.OptionsSelection.EnableAppearanceFocusedCell = false;
            CreateButtonInfoArgs();
            CreateButtonPainter();
        }

        private void CreateButtonInfoArgs() {
            EditorButton btn = new EditorButton(ButtonPredefines.Glyph);
            
            args = new EditorButtonObjectInfoArgs(btn, new DevExpress.Utils.AppearanceObject());
            args.Transparent = true;
        }
        private void CreateButtonPainter() {
            customButtonPainter = new SkinEditorButtonPainter(DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel);
        }
        void Tree_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            TreeListHitTest hi = fTreeList.ViewInfo.GetHitTest(e.Location);
            {
                if (hotNode != hi.Node)
                {
                    fTreeList.RefreshNode(hotNode);
                    hotNode = hi.Node;
                    fTreeList.RefreshNode(hotNode);
                }
            }
        }
        void Tree_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            DrawBackground(e.Node, e);
        }
        void Tree_CustomDrawNodeIndent(object sender, CustomDrawNodeIndentEventArgs e)
        {
            DrawBackground(e.Node, e);
            e.Handled = true;
        }
        void DrawBackground(TreeListNode node, CustomDrawEventArgs e)
        {
            if (hotNode != node && !node.Focused) return;
            SetUpButtonInfoArgs(e);
            customButtonPainter.DrawObject(args);
        }
        private void SetUpButtonInfoArgs(CustomDrawEventArgs e) {
            args.Cache = e.Cache;
            args.Bounds = e.Bounds;
            args.State = DevExpress.Utils.Drawing.ObjectState.Hot;
        }
        public void Detach()
        {
            fTreeList.CustomDrawNodeIndent -= new CustomDrawNodeIndentEventHandler(Tree_CustomDrawNodeIndent);
            fTreeList.CustomDrawNodeCell -= new CustomDrawNodeCellEventHandler(Tree_CustomDrawNodeCell);
            fTreeList.MouseMove -= new System.Windows.Forms.MouseEventHandler(Tree_MouseMove);
            fTreeList.OptionsSelection.EnableAppearanceFocusedCell = true;
            fTreeList = null;
        }
    }
}

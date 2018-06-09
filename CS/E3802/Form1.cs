using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.Utils;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Diagnostics;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.ViewInfo;


namespace treelist
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        BindingList<Record> dataSource;
        private void Form1_Load(object sender, EventArgs e)
        {
            dataSource = CreateObjectSource(5,5);
            treeList1.DataSource = dataSource ;
            treeList1.ExpandAll();
            HotTrackHelper helper = new HotTrackHelper(treeList1);
        }

        BindingList<Record> CreateObjectSource(int master, int child)
        {
            int count = 0;
            BindingList<Record> list = new BindingList<Record>();
            for (int i = 1; i < master; i++)
            {
                count++;
                int parentId = count;
                list.Add(new Record( count,  0 ,"root" + i));
                for (int j = 1; j< child; j++)
                {
                    count++;
                    list.Add(new Record(count, parentId, "Child" + j));
                }
            }
            count = master;
            return list;
        }

        class Record
        {
            string _value;
            int _id;
            int _parentID;
            public string Value { get{return _value;} set{_value = value;} }
            public int ID { get { return _id; } set { _id = value;} }
            public int ParentID { get { return _parentID; } set { _parentID = value; } }

            public Record(int id, int parentId, string value)
            {
                _id = id;
                _parentID = parentId;
                _value = value;
            }
        }
    }
}

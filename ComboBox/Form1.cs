using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComboBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> sList = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                sList.Add($"Test{i}");
            }

            //Winform
            cbTest01.DataSource = sList;
            cbTest01.SelectedIndex = 3;

            //Devexpress normal combobox edit
            comboBoxEditNormal.Properties.Items.Clear();
            ComboBoxEditCustomized.Properties.Items.Clear();
            for (int i = 0; i < sList.Count; i++)
            {
                comboBoxEditNormal.Properties.Items.Add(sList[i]);
                ComboBoxEditCustomized.Properties.Items.Add(sList[i]);
            }


            //Cutomize normal combobox edit
            ComboBoxEditCustomized.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            //Image combobox
            icbTest.Properties.Items.Clear();
            icbTest2.Properties.Items.Clear();
            //icbTest.Properties.SmallImages = GetImageList(); //Not working
            icbTest.Properties.LargeImages = imageCollection1; //use this instead
            icbTest.Properties.NullText = "";
            EnableImageComboBoxEdit(icbTest);
            for (int i = 0; i < 2; i++)
            {
                ImageComboBoxItem item = new ImageComboBoxItem();
                item.Description = "Desc_"+i;
                item.ImageIndex = i;
                item.Value = item.Description; //This must have, otherwise value can't be selected
                icbTest.Properties.Items.Add(item);
                icbTest2.Properties.Items.Add(item);
            }
            icbTest.ShowToolTips = true;
            icbTest.MouseMove += IcbTest_MouseMove;
            icbTest.KeyDown += IcbTest_KeyDown;


            //Set test2 property
            icbTest2.Properties.TextEditStyle = TextEditStyles.Standard;
            icbTest2.Properties.NullText = "";

            InitCustomTextImageComboBox();

        }

        private void InitCustomTextImageComboBox()
        {
            CustomTextImageComboBoxEdit.Properties.Items.Clear();
            CustomTextImageComboBoxEdit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            CustomTextImageComboBoxEdit.Properties.NullText = "";
            CustomTextImageComboBoxEdit.Properties.LargeImages = imageCollection1; //Set image source

            for (int i = 0; i < 2; i++)
            {
                ImageComboBoxItem item = new ImageComboBoxItem();
                item.Description = "Item_" + i;
                item.ImageIndex = i;
                item.Value = item.Description; //This must have, otherwise value can't be selected
                CustomTextImageComboBoxEdit.Properties.Items.Add(item);
            }

            CustomTextImageComboBoxEdit.CustomDisplayText += CustomTextImageComboBoxEdit_CustomDisplayText;

        }

        private void CustomTextImageComboBoxEdit_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (e.Value == null) return;
            

            if (e.Value.ToString().StartsWith("Item_"))
            {
                e.DisplayText = e.Value.ToString() + "2333";
            }
        }

        private void EnableImageComboBoxEdit(ImageComboBoxEdit imageComboBox)
        {
            //Forcely set text editor
            FieldInfo field = imageComboBox.Properties.GetType().GetField("fTextEditStyle", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            if (field != null) field.SetValue(imageComboBox.Properties, TextEditStyles.Standard);
        }

        private void IcbTest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                icbTest.SelectedIndex = -1;
            }
        }



        /// <summary>
        /// Not working 
        /// </summary>
        /// <returns></returns>
        private List<Image> GetImageList()
        {
            List<Image> images = new List<Image>();
            images.Add(Properties.Resources.Heart_Monitor);
            images.Add(Properties.Resources.RingDarkBlue);
            return images;
        }

        private void IcbTest_MouseMove(object sender, MouseEventArgs e)
        {
            icbTest.ToolTip = e.Y.ToString();
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            List<string> sList = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                sList.Add($"ABC{i}");
            }

            cbTest01.DataSource= sList;
            cbTest01.SelectedIndex = -1;
        }

        private void ComboBoxEditCustomized_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

namespace Serialization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bSerialize_Click(object sender, EventArgs e)
        {
            var testValue = new Test();
            testValue.IntValue = 1;
            testValue.StrValue = "abc";
            for (int i = 0; i < 3; i++)
            {
                testValue.TagReasons.Add($"Reason_{i+1}",i+1);
            }

            string sSerial = csPublic.SerializeObjectIgnoreNull(testValue);
        }
    }
}
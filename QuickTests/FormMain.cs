using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickTests
{
    public partial class FormMain : Form
    {
        bool IsDebug { get; set; }
        public bool UIExit => this == null || this.IsDisposed || this.Disposing;
        public FormMain()
        {
            InitializeComponent();
            InitVariabes();
            InitOperation();
        }


        /// <summary>
        /// Not triggerring
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Form1_Load(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            this.Visible = true;

#if DEBUG
            //Not working in custom controls, only in forms
            IsDebug = true;
#endif
        }


        private void InitVariabes()
        {
            this.KeyPreview = true; //Must set to receive key down events
            csPublic.LED = new csLED(this, 1500, 4);
        }

        private void InitCOntrols()
        {

        }

        private void InitOperation()
        {
            this.PreviewKeyDown += Form1_PreviewKeyDown;

            System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();
            t1.Interval = 100;
            t1.Tick += T1_Tick;
            t1.Enabled = true;
        }

        private void T1_Tick(object sender, EventArgs e)
        {
            var t1 = sender as System.Windows.Forms.Timer;
            if (UIExit) return;
            t1.Enabled = false;

            if (csPublic.LED.SignalState)
            {
                bLEDGreen.BackColor = Color.Green;
            }
            else
            {
                bLEDGreen.BackColor = Color.Transparent;
            }

            t1.Enabled = true;
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Debug.WriteLine("Form1_PreviewKeyDown");

            if (e.Control && e.KeyCode == Keys.S)
            {
                Debug.WriteLine("Control+S");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(1);
            }

            watch.Stop();
            Debug.WriteLine($"Elipsed:{watch.ElapsedMilliseconds}");
        }


        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        protected override void OnLoad(EventArgs eventArgs)
        {
            Debug.WriteLine("OnLoad Trigger");
        }


        bool[] bitData = new bool[32];

        private void button2_Click(object sender, EventArgs e)
        {
            //Prepare data
            bitData[0] = true;
            bitData[1] = true;
            bitData[31] = true;


            string s = csHex.BoolArray32ToHexString(bitData);

            bitData = csHex.HexStringToBoolArray32(s);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Prepare data
            bitData[0] = true;
            bitData[1] = true;
            //bitData[31] = true;

            uint iSignal = csHex.BoolArrayToUInt32(bitData);

            bitData = csHex.Uint32ToBoolArray(iSignal);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 3; i++)
            {
                Student s = new Student() { Age = i + 1, Name = (i + 1).ToString() };
                students.Add(s);
            }

            DoSth(students);

            foreach (var item in students)
            {
                Debug.WriteLine($"Name:{item.Name},Age:{item.Age}");
            }
        }

        private void DoSth(List<Student> students)
        {
            foreach (var student in students)
            {
                student.Age += 10;
            }

            Student s = new Student() { Age = 999, Name = "Last" };
            students.Add(s);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine("Form1_KeyDown");

            if (e.Control && e.KeyCode == Keys.S)
            {
                Debug.WriteLine("Control+S");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Same both not accurent, but good enough

            float fValue = 101.23f;
            fValue = fValue % 100;

            double dValue = -101.23f;
            dValue = fValue % 100;


        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<Student> slist = new List<Student>();

            for (int i = 0; i < 5; i++)
            {
                Student s = new Student();
                s.Name = $"s{i}";
                s.Age = i;
                slist.Add(s);
            }

            slist.RemoveAt(0);

            foreach (var s in slist)
            {
                Debug.WriteLine(s.Name);
            }

            Debug.WriteLine("----");
            var a = slist[0];

            slist.Remove(a);

            foreach (var s in slist)
            {
                Debug.WriteLine(s.Name);
            }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Overwrite, base class object call will use new property instead of the base property.
            //New, base class object call will use base property.
            //Both overwrite/new will use the newly defined method if call from child class intead of the base class.


            A objectA;
            B objectB = new B();
            C objectC = new C();

            Console.WriteLine(objectB.Hello(null)); // 2
            Console.WriteLine(objectC.Hello()); // 3

            objectA = objectB;

            Console.WriteLine(objectA.Hello()); // 1

            objectA = objectC;

            Console.WriteLine(objectA.Hello()); // 3
        }


        class A
        {
            public virtual int Hello()
            {
                return 1;
            }
        }

        class B : A
        {
            new public int Hello(object newParam)
            {
                return 2;
            }
        }

        class C : A
        {
            public override int Hello()
            {
                return 3;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            List<Student> slist = new List<Student>();

            for (int i = 0; i < 5; i++)
            {
                Student s = new Student();
                s.Name = $"s{i}";
                s.Age = i;
                slist.Add(s);
            }

            Student sTemp = slist[0].Copy();
            slist[0].Description = "Updated";
            Debug.WriteLine(sTemp.Description);

            sTemp.Copy();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string s = "\\r";
            string s1 = s.Replace(@"\\", @"\");
            string sA = s + '\r';
            //Below works perfect
            string sReg = Regex.Unescape(s);
            string sReg1 = Regex.Unescape("");
            string sReg2 = Regex.Unescape("\\r\\n");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Prepare data
            bool[] bitData1 = new bool[16];
            bitData1[0] = true;
            bitData1[1] = true;
            //bitData[31] = true;

            UInt16 iSignal = csHex.BoolArrayToUInt16(bitData1);

            bitData = csHex.UInt16ToBoolArray(iSignal);
        }

        private void bFolders_Click(object sender, EventArgs e)
        {
            string sPath = null;

            if (csPublic.IsValidPath(sPath))
            {
                Debug.WriteLine("Valid Path.");
            }
        }


        StudentEvent sEvent = new StudentEvent();
        private void bEvents_Click(object sender, EventArgs e)
        {
            sEvent.NameChanged += SEvent_NameChanged;
            sEvent.AgeChanged += SEvent_AgeChanged;

        }

        private void SEvent_AgeChanged()
        {
            Debug.WriteLine($"Age changed to {sEvent.Age}");
            sEvent.Name = (sEvent.Age + 1).ToString();
        }

        private void SEvent_NameChanged()
        {
            Debug.WriteLine($"Name changed to {sEvent.Name}");
            sEvent.Age = 123;
        }

        private void bSetName_Click(object sender, EventArgs e)
        {
            sEvent.Name = tbName.Text;
        }

        private void bSetAge_Click(object sender, EventArgs e)
        {
            sEvent.Age = int.Parse(tbAge.Text);
        }

        private void bArray_Click(object sender, EventArgs e)
        {
            var data = CreateData(100);
            //Get a new collection index from 10-99
            var data1 = data.Skip(10);
            var data2 = data.Take(1000).ToList();
        }

        private List<Student> CreateData(int iCount)
        {
            List<Student> slist = new List<Student>();

            for (int i = 0; i < iCount; i++)
            {
                Student s = new Student();
                s.Name = $"s{i}";
                s.Age = i;
                slist.Add(s);
            }

            return slist;
        }

        private void bTake_Click(object sender, EventArgs e)
        {

        }

        private void bTakeTest1_Click(object sender, EventArgs e)
        {
            var data = CreateData(130);
            for (int i = 0; i < data.Count; i += 50)
            {
                var tempData = data.Skip(i).Take(50).ToList();

                foreach (Student item in tempData)
                {
                    Debug.WriteLine(item.Age);
                }
            }
        }

        private void bUpdateOne_Click(object sender, EventArgs e)
        {
            var data = CreateData(100);
            var s1 = data[0];
            s1.Class = "faskdjhfkashdfksadhfkshdf";
            Debug.WriteLine(data[0].Class);
        }

        private void bFloat_Click(object sender, EventArgs e)
        {
            float fA = 3.33f;
            var x = 2 + fA / 3;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }



        public int? abc1 { get; set; }
        public Test1? abc { get; set; }
        private void bEnumTest_Click(object sender, EventArgs e)
        {

        }

        public enum Test1
        {
            do1,
            do2
        }

        private void bList_Click(object sender, EventArgs e)
        {
            var students = CreateData(10);

            //case 1, value changed
            var s1 = students[0];
            s1.Age = 111;

            //Case 2 , value changed
            object o1 = s1;
            var s2 = (Student)o1;
            s2.Age = 222;

            //Case 3: value changed
            DoChangeValue(s1);

            DoChangeValue2(s1);
        }

        private void DoChangeValue(object o1)
        {
            var s2 = (Student)o1;
            s2.Age = 333;
        }

        private void DoChangeValue2(object o1)
        {
            dynamic s2;
            s2 = (Student)o1;
            s2.Age = 555;
        }

        private void bSpeed_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Restart();
            var data = CreateData(10000000);
            watch.Stop();
            Debug.WriteLine($"CreateData {watch.ElapsedMilliseconds}");
            watch.Restart();
            var find = data.Where(a => a.Age > 10000).ToList(); //Make another copy (Time consuming, 200ms)
            watch.Stop();
            Debug.WriteLine($"Data find {watch.ElapsedMilliseconds}");
            watch.Restart();
            var find2 = data.Where(a => a.Age > 10000); //Directly get reference (Fast, 0ms)
            watch.Stop();
            Debug.WriteLine($"Data find2 {watch.ElapsedMilliseconds}");
            Debug.WriteLine("Finish");
        }

        private void bIntShift_Click(object sender, EventArgs e)
        {
            long x = 123456789;
            x >>= 3; //Value changed

            //Only convert last 8 bits
            int iTest1 = 257;
            byte b1 = (byte)iTest1;

        }

        private void Form1_Shown_1(object sender, EventArgs e)
        {
            int x = 333;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var students = new List<Student>();

            for (int i = 0; i < 5; i++)
            {
                Student s1 = new Student();
                s1.Name = "x" + i + 1;
                s1.Age = i;
                students.Add(s1);
            }


            var sList = students.Where(i => i.Age > 2).ToList();
            //Value changed in original list
            for (int i = 0; i < sList.Count; i++)
            {
                var s2 = sList[i];
                s2.Description = "haha";
            }

            var abc = students;
        }

        private void bGroupList_Click(object sender, EventArgs e)
        {
            List<List<string>> listGroup = new List<List<string>>();
            for (int i = 0; i < 3; i++)
            {
                List<string> listString = new List<string>();
                for (int j = 0; j < 5; j++)
                {
                    string sValue = $"Group_{i}_Value_{j}";
                    listString.Add(sValue);
                }
                listGroup.Add(listString);
            }

            var currentList = listGroup[2];

            var newList= new List<string>();
            for (int i = 0; i < 2; i++)
            {
                string sValue = $"RowX_V_{i}";
                newList.Add(sValue);
            }
            currentList = newList;

            //CHeck value (Value not changed!!!), make sure to directly set instead
            var updatedList = listGroup[2];
        }

        private void bFirst_Click(object sender, EventArgs e)
        {
            //Prepare data
            var students = new List<Student>();
            for (int i = 0; i < 5; i++)
            {
                Student s1 = new Student();
                s1.Name = "x" + i + 1;
                s1.Age = i;
                students.Add(s1);
            }


            //Init data
            var data1 = students.FirstOrDefault(s=>s.Name=="x21");
            var data2 = students.First(s=>s.Name=="x21");
            var data3 = students.FirstOrDefault(s => s.Name == "dfsfsfd");
            var data4 = students.First(s => s.Name == "dfdfsfdsf");//Exception
        }

        private void bConvert_Click(object sender, EventArgs e)
        {
            string sTestCode = "FFFF";
            string sA=csHex.StringToHexString(sTestCode);
            string sCRC= csHex.ToCRC16(sTestCode);
        }

        private void bInt2Hex_Click(object sender, EventArgs e)
        {
            int iNumber = 15500;
            string sNumber = iNumber.ToString("X4");
        }

        private void bHex2Int_Click(object sender, EventArgs e)
        {
            string sNumber = "3C8C";
            int iNUmber= int.Parse(sNumber, System.Globalization.NumberStyles.HexNumber);
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            List<string> sList=new List<string>() {"111","2222","333","111","111" };
            var list2= sList.Distinct();



        }

        private void button13_Click(object sender, EventArgs e)
        {
            Dictionary<int, string> dictTest = new Dictionary<int, string>();
            for (int i = 0; i < 5; i++)
            {
                dictTest.Add(i,$"Value{i}");
            }

            dictTest.Add(-1,"Value3");

            foreach (var item in dictTest)
            {
                Debug.WriteLine(item.Value);
            }
        }
    }


}

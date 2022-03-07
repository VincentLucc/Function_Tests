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
    public partial class Form1 : Form
    {
        bool IsDebug { get; set; }
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true; //Must set to receive key down events
            this.PreviewKeyDown += Form1_PreviewKeyDown;
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

        private async void Form1_Load(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            this.Visible = true;

#if DEBUG
            //Not working in custom controls, only in forms
            IsDebug = true;
#endif
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Visible = false;
        }


        bool[] bitData = new bool[32];
                
        private void button2_Click(object sender, EventArgs e)
        {
            //Prepare data
            bitData[0] = true;
            bitData[1] = true;
            bitData[31] = true;


            string s =csByteConvert.BoolArrayToHexString(bitData);

            bitData=csByteConvert.HexStringToBoolArray(s);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Prepare data
            bitData[0] = true;
            bitData[1] = true;
            //bitData[31] = true;

            uint iSignal = csByteConvert.BoolArrayToUInt32(bitData);

            bitData = csByteConvert.Uint32ToBoolArray(iSignal);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 3; i++)
            {
                Student s = new Student() { Age=i+1,Name=(i+1).ToString()};
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

            if (e.Control&&e.KeyCode==Keys.S)
            {
                Debug.WriteLine("Control+S");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Same both not accurent, but good enough

            float fValue = 101.23f;
            fValue = fValue % 100;

            double dValue= -101.23f;
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
            string s1 = s.Replace(@"\\",@"\");
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

            UInt16 iSignal = csByteConvert.BoolArrayToUInt16(bitData1);

            bitData = csByteConvert.UInt16ToBoolArray(iSignal);
        }
    }
}

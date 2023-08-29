using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using _CommonCode_Framework;

namespace QuickTests
{
    public partial class FormMain : Form
    {
        bool IsDebug { get; set; }
        public bool UIExit => this == null || this.IsDisposed || this.Disposing;

        public string TimeStringDebug => DateTime.Now.ToString("HH':'mm':'ss':'fff");

        #region Performance
        Dictionary<string, string> DictPerformSource = new Dictionary<string, string>();
        Dictionary<string, Student> DictStudentSource = new Dictionary<string, Student>();
        DataTable dtPerformanceSource = new DataTable();
        List<string> lPerfSource = new List<string>();
        List<Student> lStudents = new List<Student>();
        List<List<string>> llSource = new List<List<string>>();
        List<string[]> lArraySource = new List<string[]>();
        Stopwatch watchPerformance = new Stopwatch();
        HashSet<string> hashPerfSource = new HashSet<string>();
        Queue<string> queuePerfSource = new Queue<string>();
        int iStartBase = 1000000; //Index start base
        #endregion Performance
        csEncryption encryption = new csEncryption();

        public FormMain()
        {
            this.Load += new System.EventHandler(this.FormMain_Load_1);
            InitializeComponent();
            InitVariabes();
            InitOperation();
        }

        /// <summary>
        /// IF this is not trigger, check if an "OnLoad" override method exist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load_1(object sender, EventArgs e)
        {
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

            var newList = new List<string>();
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
            var data1 = students.FirstOrDefault(s => s.Name == "x21");
            var data2 = students.First(s => s.Name == "x21");
            var data3 = students.FirstOrDefault(s => s.Name == "dfsfsfd");
            var data4 = students.First(s => s.Name == "dfdfsfdsf");//Exception
        }

        private void bConvert_Click(object sender, EventArgs e)
        {
            string sTestCode = "FFFF";
            string sA = csHex.StringToHexString(sTestCode);
            string sCRC = csHex.ToCRC16(sTestCode);
        }

        private void bInt2Hex_Click(object sender, EventArgs e)
        {
            int iNumber = 15500;
            string sNumber = iNumber.ToString("X4");
        }

        private void bHex2Int_Click(object sender, EventArgs e)
        {
            string sNumber = "3C8C";
            int iNUmber = int.Parse(sNumber, System.Globalization.NumberStyles.HexNumber);

        }

        private void button12_Click(object sender, EventArgs e)
        {
            List<string> sList = new List<string>() { "111", "2222", "333", "111", "111" };
            var list2 = sList.Distinct();



        }

        private void button13_Click(object sender, EventArgs e)
        {
            Dictionary<int, string> dictTest = new Dictionary<int, string>();
            for (int i = 0; i < 5; i++)
            {
                dictTest.Add(i, $"Value{i}");
            }

            dictTest.Add(-1, "Value3");

            foreach (var item in dictTest)
            {
                Debug.WriteLine(item.Value);
            }
        }

        private void bSubString_Click(object sender, EventArgs e)
        {
            string sTest = "BC";
            string s1 = sTest.Substring(1, sTest.Length - 2); //Substring length can be 0
        }

        private void bStringSplit_Click(object sender, EventArgs e)
        {
            //Split input can be empty, but not null
            string sTest = "";
            var result = sTest.Split(new string[] { "|" }, StringSplitOptions.None);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Student s1 = new Student() { Name = "123" };
            var s2 = s1.DeepCopyBySerialize();
            s1.Name = "333";
            var xxx = s2.Name;
        }

        private void bEnum01_Click(object sender, EventArgs e)
        {
            SampleEnumTest test01 = SampleEnumTest.DEF;

            var result = EnumHelper<SampleEnumTest>.GetDescriptions();
        }

        private void bReference_Click(object sender, EventArgs e)
        {
            Student s1 = new Student() { Name = "123" };
            var s2 = s1;
            var value = s2.Name;
            s2 = null;
            var value2 = s1.Name;
        }


        private void button16_Click(object sender, EventArgs e)
        {
            LoopEvent += FormMain_LoopEvent;
            LoopEventTimer.Start();
        }



        private void FormMain_LoopEvent()
        {
            //Thread.Sleep(3500);
        }

        int iCount = 0;
        public delegate void loopEventAction();
        public event loopEventAction LoopEvent;
        bool IsTimerLooping;
        private void LoopEventTimer_Tick(object sender, EventArgs e)
        {
            if (IsTimerLooping) return;
            IsTimerLooping = true;

            Debug.WriteLine("Timer Start:" + TimeStringDebug);
            LoopEvent?.Invoke();
            Debug.WriteLine(TimeStringDebug + ":" + iCount++);

            IsTimerLooping = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            LoopEvent -= FormMain_LoopEvent;
            LoopEventTimer.Stop();
        }


        public delegate void nullEventAction();
        public event nullEventAction nullEvent;
        private void button19_Click(object sender, EventArgs e)
        {
            nullEvent += FormMain_nullEvent;
        }

        private void FormMain_nullEvent()
        {
            Debug.WriteLine(csPublic.TimeString);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (nullEvent != null)
            {
                nullEvent = null;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            nullEvent?.Invoke();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Student s1 = new Student() { Name = "s1" };
            Student s2 = new Student();
            Student.StaticText = "600";
            s2 = s1;

            if (s2 == s1)
            {
                Debug.WriteLine("Do Sth");
            }

            s1 = new Student();
            string sName = s2.Name; //Value stayed


        }

        private void bSortedList_Click(object sender, EventArgs e)
        {
            Dictionary<string, KeyValuePair<int, DateTime>> pairs = new Dictionary<string, KeyValuePair<int, DateTime>>();


        }



        private void bPrepareData_Click(object sender, EventArgs e)
        {
            PreparePerformanceData(false);
        }

        private void bPreparewithKey_Click(object sender, EventArgs e)
        {
            PreparePerformanceData(true);
        }

        private void PreparePerformanceData(bool withKey)
        {
            //Init variables
            DictPerformSource.Clear();
            dtPerformanceSource.Rows.Clear();
            dtPerformanceSource.PrimaryKey = null;
            dtPerformanceSource.Columns.Clear();
            lPerfSource.Clear();

            int iRecordCount = 100000;

            //Create list string data 6ms
            watchPerformance.Restart();
            for (int i = iStartBase; i < iStartBase + iRecordCount; i++)
            {
                lPerfSource.Add(i.ToString());
            }
            watchPerformance.Stop();
            Debug.WriteLine($"Create list string record:{lPerfSource.Count}, time:{watchPerformance.ElapsedMilliseconds}.");

            //Create list class data 
            watchPerformance.Restart();
            for (int i = iStartBase; i < iStartBase + iRecordCount; i++)
            {
                var stu = new Student(i);
                lStudents.Add(stu);
            }
            watchPerformance.Stop();
            Debug.WriteLine($"Create list students record:{lStudents.Count}, time:{watchPerformance.ElapsedMilliseconds}.");

            //Create list-list
            watchPerformance.Restart();
            for (int i = iStartBase; i < iStartBase + iRecordCount; i++)
            {
                var stu = new Student(i);
                List<string> values = new List<string>();
                for (int j = 0; j < 4; j++)
                {
                    values.Add($"Stu_{i}");
                    values.Add(i.ToString());
                    values.Add($"Record_{i}");
                }
                llSource.Add(values);
            }
            watchPerformance.Stop();
            Debug.WriteLine($"Create List-List record:{llSource.Count}, time:{watchPerformance.ElapsedMilliseconds}.");


            //Create list-Array
            watchPerformance.Restart();
            for (int i = iStartBase; i < iStartBase + iRecordCount; i++)
            {
                string[] nodes = new string[4];
                nodes[0] = $"Stu_{i}";
                nodes[1] = i.ToString();
                nodes[2] = $"Record_{i}";
                lArraySource.Add(nodes);
            }
            watchPerformance.Stop();
            Debug.WriteLine($"Create List-Array record:{lArraySource.Count}, time:{watchPerformance.ElapsedMilliseconds}.");

            //Create hashset 19ms
            watchPerformance.Restart();
            for (int i = iStartBase; i < iStartBase + iRecordCount; i++)
            {
                hashPerfSource.Add(i.ToString());
            }
            watchPerformance.Stop();
            Debug.WriteLine($"Create hashset-string record:{hashPerfSource.Count}, time:{watchPerformance.ElapsedMilliseconds}.");

            //Create queue
            watchPerformance.Restart();
            for (int i = iStartBase; i < iStartBase + iRecordCount; i++)
            {
                queuePerfSource.Enqueue(i.ToString());
            }
            watchPerformance.Stop();
            Debug.WriteLine($"Create queue-string record:{queuePerfSource.Count}, time:{watchPerformance.ElapsedMilliseconds}.");

            //Create dictionary data 29ms
            watchPerformance.Restart();
            for (int i = iStartBase; i < iStartBase + iRecordCount; i++)
            {
                DictPerformSource.Add(i.ToString(), $"Record_{i}");
            }
            watchPerformance.Stop();
            Debug.WriteLine($"Create dictionary string record:{DictPerformSource.Count}, time:{watchPerformance.ElapsedMilliseconds}.");

            //Create dictionary data students
            watchPerformance.Restart();
            for (int i = iStartBase; i < iStartBase + iRecordCount; i++)
            {
                var stu = new Student(i);
                DictStudentSource.Add(i.ToString(), stu);
            }
            watchPerformance.Stop();
            Debug.WriteLine($"Create dictionary student record:{DictStudentSource.Count}, time:{watchPerformance.ElapsedMilliseconds}.");


            //Create datatable data 137ms
            var nameColumn = dtPerformanceSource.Columns.Add(nameof(Student.Name), typeof(string));
            var valueColumn = dtPerformanceSource.Columns.Add(nameof(Student.Age), typeof(int));
            dtPerformanceSource.Columns.Add(nameof(Student.Description), typeof(string));
            dtPerformanceSource.Columns.Add(nameof(Student.Class), typeof(string));
            if (withKey)
            {
                //Primary key
                //注意，这只是合并的Key和Index, 实际只有一个Key与Index!!!!
                dtPerformanceSource.PrimaryKey = new DataColumn[] { nameColumn, valueColumn };
            }
            watchPerformance.Restart();
            for (int i = iStartBase; i < iStartBase + iRecordCount; i++)
            {
                var dataRow = dtPerformanceSource.NewRow();
                dataRow[nameof(Student.Name)] = $"Stu_{i}";
                dataRow[nameof(Student.Age)] = i;
                dataRow[nameof(Student.Description)] = $"Record_{i}";
                dtPerformanceSource.Rows.Add(dataRow);
            }

            watchPerformance.Stop();
            Debug.WriteLine($"Create data table record:{iRecordCount}, time:{watchPerformance.ElapsedMilliseconds}.");
        }

        private void bAddwithDucplicationCheck_Click(object sender, EventArgs e)
        {
            AddPerfData(AddDataType.DuplicationCheck);
        }


        private void AddPerfData(AddDataType addType, bool bStaticEnumerator = false)
        {
            //Init varibales
            int iAddCount = 1000;
            int iStart = 0;

            //Add list
            iStart = lPerfSource.Count + iStartBase;//Time consuming action
            watchPerformance.Restart();
            for (int i = iStart; i < iStart + iAddCount; i++)
            {
                //Order will be OK if no delete 
                string sNewKey = (i + 1).ToString();

                if (addType == AddDataType.DuplicationCheck)
                {
                    //Method 1, 689ms
                    //if (!lPerfSource.Contains(sNewKey)) lPerfSource.Add(sNewKey);

                    //Method 2, 1625ms
                    //if (!lPerfSource.Any(a=>a== sNewKey)) lPerfSource.Add(sNewKey);

                    //Method 3, 584ms (Use multiple cpu)
                    if (lPerfSource.AsParallel().FirstOrDefault(a => a == sNewKey) == null)
                    {
                        lPerfSource.Add(sNewKey);
                    }
                }
                else if (addType == AddDataType.Insert)
                {
                    //Get intert position
                    int iInsert = lPerfSource.Count / 2;
                    lPerfSource.Insert(iInsert, sNewKey);
                }

            }
            watchPerformance.Stop();
            Debug.WriteLine($"Add (List) record:{iAddCount}, Total:{lPerfSource.Count}, time:{watchPerformance.ElapsedMilliseconds}.");




            //Add hashset
            iStart = hashPerfSource.Count + iStartBase;
            watchPerformance.Restart();
            for (int i = iStart; i < iStart + iAddCount; i++)
            {
                //Order will be OK if no delete 
                string sNewKey = (i + 1).ToString();

                if (addType == AddDataType.DuplicationCheck)
                {
                    //Method 0 ms
                    if (!hashPerfSource.Contains(sNewKey))
                    {
                        hashPerfSource.Add(sNewKey);
                    }
                }
                else if (addType == AddDataType.Insert)
                {

                    hashPerfSource.Add(sNewKey);
                }
            }
            watchPerformance.Stop();
            if (addType == AddDataType.Insert) Debug.WriteLine("HasSetHas no order, directly add value.");
            Debug.WriteLine($"Add (HashSet) record:{iAddCount}, Total:{hashPerfSource.Count}, time:{watchPerformance.ElapsedMilliseconds}.");

            //Add dictionary
            iStart = DictPerformSource.Count + iStartBase;
            watchPerformance.Restart();
            for (int i = iStart; i < iStart + iAddCount; i++)
            {
                //Order will be OK if no delete 
                string sNewKey = (i + 1).ToString();

                //Method 1, 0ms
                if (!DictPerformSource.ContainsKey(sNewKey))
                {
                    DictPerformSource.Add(sNewKey, $"Add_{sNewKey}");
                }

                //Method 2, 0ms
                //if (!DictPerformSource.Keys.Contains(sNewKey))
                //{
                //    DictPerformSource.Add(sNewKey, $"Add_{sNewKey}");
                //}

                //method 3, 2691ms
                //if (!DictPerformSource.Any(a => a.Key == sNewKey))
                //{
                //    DictPerformSource.Add(sNewKey, $"Add_{sNewKey}");
                //}

            }
            watchPerformance.Stop();
            Debug.WriteLine($"Add dictionary record:{iAddCount}, Total:{DictPerformSource.Count}, time:{watchPerformance.ElapsedMilliseconds}.");

            //Add to datatable
            iStart = dtPerformanceSource.Rows.Count + iStartBase;
            var sSearchSource = dtPerformanceSource.AsEnumerable();
            watchPerformance.Restart();
            for (int i = iStart; i < iStart + iAddCount; i++)
            {
                string sNewName = (i + 1).ToString();

                if (addType == AddDataType.DuplicationCheck)
                {
                    //Add method 1: 9526 (No difference with or withou key column)
                    //if (!dtPerformanceSource.AsEnumerable().Any(row => row["Name"].ToString() == sNewName))
                    //{
                    //    var dataRow = dtPerformanceSource.NewRow();
                    //    dataRow["Name"] = sNewName;
                    //    dataRow["Value"] = $"Add_{sNewName}";
                    //    dtPerformanceSource.Rows.Add(dataRow);
                    //}

                    //Add method 2: 
                    //No key column: 350,152ms !!!!?
                    //With Key column: 32 ms !!!
                    if (dtPerformanceSource.Select($"Name='{sNewName}'").Count() == 0)
                    {
                        var dataRow = dtPerformanceSource.NewRow();
                        dataRow[nameof(Student.Name)] = sNewName;
                        dataRow[nameof(Student.Description)] = $"Add_{sNewName}";
                        dtPerformanceSource.Rows.Add(dataRow);
                    }

                    //Method 3:10893ms
                    //if (!sSearchSource.Any(row => row["Name"].ToString() == sNewName))
                    //{
                    //    var dataRow = dtPerformanceSource.NewRow();
                    //    dataRow["Name"] = sNewName;
                    //    dataRow["Value"] = $"Add_{sNewName}";
                    //    dtPerformanceSource.Rows.Add(dataRow);
                    //}

                    //Method 4: 9069ms
                    //if (!sSearchSource.AsParallel().Any(row => row["Name"].ToString() == sNewName))
                    //{
                    //    var dataRow = dtPerformanceSource.NewRow();
                    //    dataRow["Name"] = sNewName;
                    //    dataRow["Value"] = $"Add_{sNewName}";
                    //    dtPerformanceSource.Rows.Add(dataRow);
                    //}
                }
                else if (addType == AddDataType.Insert)
                {
                    var dataRow = dtPerformanceSource.NewRow();
                    dataRow[nameof(Student.Name)] = sNewName;
                    dataRow[nameof(Student.Description)] = $"Add_{sNewName}";
                    int iInsert = dtPerformanceSource.Rows.Count / 2;
                    dtPerformanceSource.Rows.InsertAt(dataRow, iInsert);
                }
            }
            watchPerformance.Stop();
            Debug.WriteLine($"Add datatable record:{iAddCount}, Total:{dtPerformanceSource.Rows.Count}, time:{watchPerformance.ElapsedMilliseconds}.");
        }

        private void bSort_Click(object sender, EventArgs e)
        {
            //Sort list students 
            watchPerformance.Restart();
            var sortedListTudents = lStudents.OrderByDescending(a => a.Name).DistinctBy(a => a.Name);
            sortedListTudents = lStudents.OrderByDescending(a => a.Age);
            watchPerformance.Stop();
            Debug.WriteLine($"Sort list student record:{lStudents.Count}, Time:{watchPerformance.ElapsedMilliseconds}.");

            //Sort dictionary students 
            watchPerformance.Restart();
            var sortedDictSTudents = DictStudentSource.OrderByDescending(a => a.Value.Name).DistinctBy(a => a.Value.Name);
            sortedDictSTudents = DictStudentSource.OrderByDescending(a => a.Value.Age);
            watchPerformance.Stop();
            Debug.WriteLine($"Sort dictionary student record:{DictStudentSource.Count}, Time:{watchPerformance.ElapsedMilliseconds}.");

            //Sort datatable students 
            watchPerformance.Restart();
            var sortedTableStudents = dtPerformanceSource.AsEnumerable().OrderBy(a => a.Field<int>(nameof(Student.Name))).DistinctBy(a => a.Field<int>(nameof(Student.Name))); ;
            sortedTableStudents = dtPerformanceSource.AsEnumerable().OrderBy(a => a.Field<int>(nameof(Student.Age)));
            watchPerformance.Stop();
            Debug.WriteLine($"Sort datatable student record:{dtPerformanceSource.Rows.Count}, Time:{watchPerformance.ElapsedMilliseconds}.");
        }

        private void bLinkedList_Click(object sender, EventArgs e)
        {

        }

        private void bInsert_Click(object sender, EventArgs e)
        {
            AddPerfData(AddDataType.Insert);
        }

        private void bRemoveData_Click(object sender, EventArgs e)
        {
            RemovePerfRecords();
        }


        private void RemovePerfRecords()
        {
            watchPerformance.Restart();
            //Hashset-String
            //10K:8024ms
            int iTotal = hashPerfSource.Count;
            while (hashPerfSource.Count > 0)
            {
                string sValue = hashPerfSource.First();
                hashPerfSource.Remove(sValue);
            }
            watchPerformance.Stop();
            Debug.WriteLine($"Remove (Hashset-String) record:Total:{iTotal}, time:{watchPerformance.ElapsedMilliseconds}.");

            //List-String
            //10K:1328ms
            iTotal = lPerfSource.Count;
            watchPerformance.Restart();
            while (lPerfSource.Count > 0)
            {
                lPerfSource.RemoveAt(0);
            }
            watchPerformance.Stop();
            Debug.WriteLine($"Remove (List-String) record:Total:{iTotal}, time:{watchPerformance.ElapsedMilliseconds}.");

            //Queue-string
            //10K:0ms
            iTotal = queuePerfSource.Count;
            watchPerformance.Restart();
            while (queuePerfSource.Count > 0)
            {
                queuePerfSource.Dequeue();
            }
            watchPerformance.Stop();
            Debug.WriteLine($"Remove (Queue-String) record:Total:{iTotal}, time:{watchPerformance.ElapsedMilliseconds}.");
        }

        private void bValueChange_Click(object sender, EventArgs e)
        {
            ModifyAllData();
        }

        private void ModifyAllData()
        {
            //Init variables
            int iCount = 0;

            //Modify list string
            iCount = lPerfSource.Count;
            watchPerformance.Restart();
            for (int i = 0; i < iCount; i++)
            {
                lPerfSource[i] = lPerfSource[i] + "_X";
            }
            watchPerformance.Stop();
            Debug.WriteLine($"Mofify (List-String) record:{iCount}, time:{watchPerformance.ElapsedMilliseconds}.");

            //Modify list stduent
            watchPerformance.Restart();
            iCount = lStudents.Count;
            for (int i = 0; i < iCount; i++)
            {
                var item = lStudents[i];
                item.Name = item.Name + "_X";
            }
            watchPerformance.Stop();
            Debug.WriteLine($"Mofify (List-Student) record:{iCount}, time:{watchPerformance.ElapsedMilliseconds}.");

            //Modify list-list
            watchPerformance.Restart();
            iCount = llSource.Count;
            for (int i = 0; i < iCount; i++)
            {
                var item = llSource[i];
                item[0] = item[0] + "_X";
            }
            watchPerformance.Stop();
            Debug.WriteLine($"Mofify (List-List) record:{iCount}, time:{watchPerformance.ElapsedMilliseconds}.");

            //Modify list-array
            watchPerformance.Restart();
            iCount = lArraySource.Count;
            for (int i = 0; i < iCount; i++)
            {
                var item = lArraySource[i];
                item[0] = item[0] + "_X";
            }
            watchPerformance.Stop();
            Debug.WriteLine($"Mofify (List-Array) record:{iCount}, time:{watchPerformance.ElapsedMilliseconds}.");

            //Modify data table
            watchPerformance.Restart();
            iCount = dtPerformanceSource.Rows.Count;
            for (int i = 0; i < iCount; i++)
            {
                var item = dtPerformanceSource.Rows[i];
                string sName = item.Field<string>(nameof(Student.Name)) + "_X";
                item[nameof(Student.Name)] = sName;
            }
            watchPerformance.Stop();
            Debug.WriteLine($"Mofify (Datatable Student) record:{iCount}, time:{watchPerformance.ElapsedMilliseconds}.");

            //Modify data table
            var enumRows = dtPerformanceSource.AsEnumerable();
            watchPerformance.Restart();
            foreach (DataRow row in enumRows)
            {
                string sName = row.Field<string>(nameof(Student.Name)) + "_X";
                row[nameof(Student.Name)] = sName;
            }
            Debug.WriteLine($"Mofify (Datatable Student) with Enum record:{enumRows.Count()}, time:{watchPerformance.ElapsedMilliseconds}.");
        }

        private void bLinqSOrt_Click(object sender, EventArgs e)
        {
            //Prepare fake data 
            List<Student> stuList = new List<Student>();
            List<int> stuOrders = new List<int>();
            int iIndex = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    iIndex++;
                    Student student = new Student()
                    {
                        Name = $"Stu{iIndex.ToString("d3")}",
                        Age = iIndex,
                        SeatOrder = j + 1,
                        Class = (i + 1).ToString("d3")
                    };

                    stuList.Add(student);
                    stuOrders.Add(iIndex);
                }

            }

            Debug.WriteLine($"Before:");
            foreach (var item in stuList)
            {
                Debug.WriteLine($"StuName:{item.Name},Seat:{item.SeatOrder},Class:{item.Class}");
            }
            Debug.WriteLine($"-------\r\n\r\n\r\n");

            var result1 = stuList.OrderByDescending(A => A.SeatOrder).ToList();
            var result2 = result1.OrderByDescending(a => a.Class).ToList();
            Debug.WriteLine($"After:");
            foreach (var item in result2)
            {
                Debug.WriteLine($"StuName:{item.Name},Seat:{item.SeatOrder},Class:{item.Class}");
            }
            Debug.WriteLine($"-------\r\n\r\n\r\n");


            //Sort by extra list of index
            var result3 = stuList.OrderByDescending(a => GetMatchedOrder(a)).ToString();
            Debug.WriteLine($"SOrt by extra:");
            foreach (var item in result2)
            {
                Debug.WriteLine($"StuName:{item.Name},Seat:{item.SeatOrder},Class:{item.Class}");
            }
            Debug.WriteLine($"-------\r\n\r\n\r\n");

            int GetMatchedOrder(Student stu)
            {
                int iStuIndex = stuList.IndexOf(stu);
                int iOrder = stuOrders[iStuIndex];
                return iOrder;
            }

        }

        private void button22_Click(object sender, EventArgs e)
        {
            List<string[]> strings = new List<string[]>();
            for (int i = 0; i < 10; i++)
            {
                string[] data = new string[3] { i.ToString(), i.ToString(), i.ToString() };
                strings.Add(data);
            }

            strings.Add(new string[] { "2", "2", "2" });
            strings.Add(new string[] { "5", "5", "5" });

            var row10 = strings[10];
            int iRowIndex = strings.IndexOf(row10);
            var newData = new string[] { "2", "2", "2" };
            iRowIndex = strings.IndexOf(newData);//Reference type!!!!
        }

        private void bEnumerator_Click(object sender, EventArgs e)
        {
            List<string> strings = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                strings.Add((i + 1).ToString());
            }

            //Current value is null by default, maust use "MoveNext" to get first value
            var enumerator = strings.AsEnumerable().GetEnumerator();
            while (enumerator.MoveNext())
            {
                string sCurrent = enumerator.Current;
                Debug.WriteLine(sCurrent);
            }
        }

        private void bBase16ToBase36_Click(object sender, EventArgs e)
        {

            bool isSUccess = csHex.HexStringToUlong("0F FF FF FF", out ulong uValue);


            string sHex = "FF FF FF FF F1";
            //sHex = "11 22 33 CR C0";
            string sBase36 = csHex.HexStringToBase36String(sHex);

            string sBase36Input = "ZZ ZZ ZZ ZZ";
            isSUccess = csHex.Base36StringToUlong(sBase36Input, out ulong uValue2);
            string sBase36Convert1 = csHex.Base36StringShift(sBase36, csHex.Base36_8_Half);
            string sBase36Convert2 = csHex.Base36StringShift(sBase36Convert1, -csHex.Base36_8_Half);

            string sHexFrom = csHex.Base36StringToHexString(sBase36Convert2);
        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            encryption.GenerateNew();
            string sHexKey = BitConverter.ToString(encryption.KeyByte).Replace("-", "");
            string sHexVector = BitConverter.ToString(encryption.VectorByte).Replace("-", "");
            var bKey = csHex.HexStringToHexByte(sHexKey);
            string sKeyBase64 = Convert.ToBase64String(bKey);
            bool isEqual = sKeyBase64 == encryption.KeyString;
            Debug.WriteLine(encryption.KeyString);
            Debug.WriteLine(encryption.VectorString);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string sOutput = encryption.EncryptToAesString(tbPlain.Text);
            tbEncryption.Text = sOutput;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            string sPlainText = encryption.DecryptAesFromBase64String(tbEncryption.Text);
            tbPlain.Text = sPlainText;
        }


    }



}




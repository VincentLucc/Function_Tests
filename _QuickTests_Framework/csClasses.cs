using _CommonCode_Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _QuickTests_Framework
{
    public class csClasses
    {

    }

    /// <summary>
    /// 抽象类：定义
    /// </summary>
    public abstract class csShape
    {
        public string Name { get; set; }

        public csShape()
        {
            Name = string.Empty;
        }

        /// <summary>
        /// Abstract class can't define a body
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// All abstract method must be used when inherit
        /// </summary>
        public abstract void DrawEmpty();

        public void Draw1()
        {
            Debug.WriteLine("Draw_1 Shape");
        }
    }

    /// <summary>
    /// 抽象类：使用
    /// </summary>
    public class csRectangle : csShape
    {

        public override void Draw()
        {
            Debug.WriteLine("Draw Shape");
        }

        public override void DrawEmpty()
        {
            Debug.WriteLine("Draw Shape");
        }

    }


    /// <summary>
    /// 接口：定义
    /// </summary>
    public interface Fruit
    {
        void Draw();
    }

    /// <summary>
    /// 接口：使用
    /// </summary>
    public class csApple : Fruit
    {
        public void Draw()
        {

        }


    }

    /// <summary>
    /// 虚方法
    /// </summary>
    public class csEmployee
    {
        public string NormalNewProperty { get; set; }= "csEmployee.Normal-New";

        public string NormalNewProperty_Call = "csEmployee.Normal-New-Call";

        public virtual string VirtualNewProperty { get; set; }= "csEmployee.Virtual-New";

        /// <summary>
        /// Allow new property contains get method
        /// </summary>
        public virtual string VirtualNewProperty_Call { get; set; } = "csEmployee.Virtual-New-Call";

        /// <summary>
        /// Not allowed!!!
        /// </summary>
        //public string NormalOverrideProperty { get; set; } = "csEmployee.Normal-Override";

        public virtual string VirtualOverrideProperty { get; set; } = "csEmployee.Virtual-Override";

        public void Show_Normal_New()
        {
            Debug.WriteLine("Employee: Normal Base Method");
        }

        public virtual void Show_Virtual_New()
        {
            Debug.WriteLine("Employee: Virtual Base Method");
        }

        /// <summary>
        /// 可以不使用
        /// </summary>
        public virtual void Show_Virtual_OverRide()
        {
            Debug.WriteLine("Employee: Override Base");
        }

        /// <summary>
        /// Not allowed
        /// </summary>
        public  void Show_Normal_OverRide()
        {
            Debug.WriteLine("Employee: Normal base override");
        }
    }

    public class csDeveloper : csEmployee
    {

        public new string NormalNewProperty = "csDeveloper.Normal-New";

        public new string NormalNewProperty_Call = "csDeveloper.Normal-New-Call";

        public new string VirtualNewProperty { get; set; } = "csDeveloper.Virtual-New";

        //public override string NormalOverrideProperty { get; set; } = "csDeveloper.Normal-Override";

        public override string VirtualOverrideProperty { get; set; } = "csDeveloper.Virtual-Override";

        public new string VirtualNewProperty_Call
        {
            get { return "csDeveloper.Virtual-New-Call"; }
        }

        public new void Show_Normal_New()
        {
            Debug.WriteLine("Developer: New method");
        }

 
        public new void Show_Virtual_New()
        {
            Debug.WriteLine("Developer: Virtual Method");
        }

        /// <summary>
        /// 可以不使用
        /// </summary>
        public override void Show_Virtual_OverRide()
        {
            Debug.WriteLine("Developer: Override inherit!");
        }


 
    }




}

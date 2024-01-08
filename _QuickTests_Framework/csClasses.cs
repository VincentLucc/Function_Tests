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
        public virtual void Draw1()
        {
            Debug.WriteLine("Virtual Base 1");
        }

        /// <summary>
        /// 可以不使用
        /// </summary>
        public virtual void Draw2()
        {
            Debug.WriteLine("Virtual Base 2");
        }
    }

    public class csDeveloper : csEmployee
    {
        public override void Draw1()
        {
            Debug.WriteLine("Virtual Developer 1");
        }

        /// <summary>
        /// Use new can have different method parameters
        /// If call a new method without specify the class type, will use base class method.
        /// If call a override method without specify the class type, will try to call the sub class method instead.
        /// </summary>
        public new void Draw2()
        {
            Debug.WriteLine("Virtual New Developer 1");
        }

    }




}

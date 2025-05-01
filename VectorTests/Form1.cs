using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Numerics;
using System.Diagnostics;

namespace VectorTests
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SimpleButton_Click(object sender, EventArgs e)
        {
            //Nuget install: System.Numerics.Vectors
            //Property；Enable code optimize
            //Property: buildX64

            float[] array1 = { 1, 2, 3, 4, 5, 6, 7, 8 };
            float[] array2 = { 8, 7, 6, 5, 4, 3, 2, 1 };
            float[] result = new float[array1.Length];

            if (!Vector.IsHardwareAccelerated)
            {
                MessageBox.Show("当前环境不支持 SIMD 加速。");
                return;
            }

            Trace.WriteLine("SIMD 硬件加速已启用！");

            //Get current supported vector length: 8250u->8
            // #SSE/ SSE2（128bits): [128/32(float)=4]
            // #AVX/ AVX2（256bits)：[256/32(float)=8]
            // #AVX-512（512bits)：[512/32(float)=16]
            int simdLength = Vector<float>.Count;

            for (int i = 0; i < array1.Length; i += simdLength)
            {
                Vector<float> v1 = new Vector<float>(array1, i);
                Vector<float> v2 = new Vector<float>(array2, i);
                (v1 + v2).CopyTo(result, i);
            }
        }
    }
}

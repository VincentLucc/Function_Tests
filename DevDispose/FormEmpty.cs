using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevDispose
{
    public partial class FormEmpty : DevExpress.XtraEditors.XtraForm
    {
        public DisposableObject TestObject { get; set; }

        public FormEmpty()
        {
            InitializeComponent();
        }

        private void FormEmpty_Load(object sender, EventArgs e)
        {
            TestObject=new DisposableObject();
            this.Disposed += FormEmpty_Disposed;
        }

        private void FormEmpty_Disposed(object sender, EventArgs e)
        {
            int a = 2;
            
        }
    }


    public class DisposableObject:IDisposable
    {

        // Flag: Has Dispose already been called?
        bool disposed = false;

        // Implement IDisposable.
        // Do not make this method virtual.
        // A derived class should not be able to override this method.
        public void Dispose()
        {
            Dispose(disposing: true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SuppressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                int x = 1;
            }

            disposed = true;
        }
    }
}
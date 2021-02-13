using System.Windows.Forms;

namespace JournalTrace.View.Layout
{
    internal interface ILayout
    {
        void LoadData(FormMain frm);

        Control GetControl();

        void Clean();
    }
}
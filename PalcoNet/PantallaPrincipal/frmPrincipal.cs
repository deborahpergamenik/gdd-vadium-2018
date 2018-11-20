using System.Windows.Forms;

namespace PalcoNet.PantallaPrincipal
{
    public partial class frmPrincipal : Form
    {
        private frmLogin _frmLogin;

        public frmPrincipal(frmLogin frmLogin)
        {
            InitializeComponent();
            _frmLogin = frmLogin;
        }
    }
}

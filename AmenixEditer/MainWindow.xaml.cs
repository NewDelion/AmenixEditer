using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace AmenixEditer
{
    public partial class MainWindow : MetroWindow
    {
        private ViewModel.MainViewModel vm = new ViewModel.MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            init();
        }

        #region //Initialize
        private void init()
        {
            DataContext = vm;
            textEditor.TextArea.Caret.PositionChanged += (sender, e) =>
            {
                vm.Column = textEditor.TextArea.Caret.Column;
                vm.Line = textEditor.TextArea.Caret.Line;
            };
            install_FindReplace();

            textEditor.Focus();
        }

        private FindReplace.FindReplaceMgr FRManager = null;
        private void install_FindReplace()
        {
            FRManager = new FindReplace.FindReplaceMgr();
            FRManager.CurrentEditor = new FindReplace.TextEditorAdapter(textEditor);
            FRManager.ShowSearchIn = false;
            FRManager.OwnerWindow = this;
            CommandBindings.Add(FRManager.FindBinding);
            CommandBindings.Add(FRManager.ReplaceBinding);
            CommandBindings.Add(FRManager.FindNextBinding);
        }
        #endregion
    }

    /*
    http://sourcechord.hatenablog.com/entry/2016/02/23/012511
    http://qiita.com/kabosu/items/11fa400bdd82395f59fb

    */
}

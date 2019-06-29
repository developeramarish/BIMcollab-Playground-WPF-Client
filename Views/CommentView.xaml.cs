using System.Windows.Controls;
using BIMcollab_BCF_WPF_MVVM.Model;
using BIMcollab_BCF_WPF_MVVM.ViewModel;

namespace BIMcollab_BCF_WPF_MVVM.Views
{
    /// <summary>
    /// Interaction logic for CommentView.xaml
    /// </summary>
    public partial class CommentView : UserControl
    {
        private readonly CommentViewModel commentViewModelObject;

        public CommentView()
        {
            this.InitializeComponent();

            this.commentViewModelObject = new CommentViewModel();
            this.DataContext = this.commentViewModelObject;
        }

        internal void ShowComments(Issue selectedIssue)
        {
            this.commentViewModelObject.ShowComments(selectedIssue);
        }
    }
}

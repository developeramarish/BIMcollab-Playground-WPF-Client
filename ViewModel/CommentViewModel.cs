using System.Collections.ObjectModel;
using BIMcollab_BCF_WPF_MVVM.Model;

namespace BIMcollab_BCF_WPF_MVVM.ViewModel
{
    internal class CommentViewModel
    {
        public ObservableCollection<Comment> Comments { get; set; }


        public CommentViewModel()
        {
            this.Comments = new ObservableCollection<Comment>();
        }

        public void ShowComments(Issue issue)
        {
            this.Comments.Clear();

            foreach (BC_Comment comment in issue.Comments)
            {
                this.Comments.Add(new Comment(comment));
            }
        }
    }
}

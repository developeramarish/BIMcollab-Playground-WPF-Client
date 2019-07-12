using System.Windows;
using System.Windows.Controls;
using BIMcollab_BCF_WPF_MVVM.Model;
using BIMcollab_BCF_WPF_MVVM.ViewModel;

namespace BIMcollab_BCF_WPF_MVVM.Views
{
    /// <summary>
    /// Interaction logic for EditIssueView.xaml
    /// </summary>
    public partial class EditIssueView : Window
    {
        private EditIssueAbstractViewModel editIssueViewModelObject;
        private readonly EditIssueConcreteViewModel editIssueConcreteViewModel;
        private readonly NewIssueConcreteViewModel newIssueConcreteViewModel;

        internal EditIssueView(Project activeProject)
        {
            this.InitializeComponent();

            this.editIssueConcreteViewModel = new EditIssueConcreteViewModel(activeProject);
            this.newIssueConcreteViewModel = new NewIssueConcreteViewModel(activeProject);
        }

        internal void EditIssue(Issue editedIssue)
        {
            this.editIssueViewModelObject = this.editIssueConcreteViewModel;
            
            this.editIssueViewModelObject.SetIssue(editedIssue);

            this.DataContext = this.editIssueViewModelObject;

            this.RefreshControls();
        }

        internal void NewIssue()
        {
            this.editIssueViewModelObject = this.newIssueConcreteViewModel;

            this.editIssueViewModelObject.CreateNewIssue();

            this.DataContext = this.editIssueViewModelObject;

            this.RefreshControls();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);

            e.Cancel = true;
            this.Hide();
        }

        private void ReopenButton_Click(object sender, RoutedEventArgs e)
        {
            this.editIssueViewModelObject.SetStatusActive();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.editIssueViewModelObject.SetStatusClosed();
        }

        private void ReactivateButton_Click(object sender, RoutedEventArgs e)
        {
            this.editIssueViewModelObject.SetStatusActive();
        }

        private void ResolveAndCloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.editIssueViewModelObject.SetStatusClosed();
        }

        private void ResolveButton_Click(object sender, RoutedEventArgs e)
        {
            this.editIssueViewModelObject.SetStatusResolved();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RefreshControls()
        {
            this.TitleTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateTarget();
        }
    }
}

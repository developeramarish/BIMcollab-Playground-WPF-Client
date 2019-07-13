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
            
            this.editIssueViewModelObject.EditIssue(editedIssue);

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
            this.Hide();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.editIssueViewModelObject.Save();
            this.Hide();
        }

        private void RefreshControls()
        {
            this.TitleTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateTarget();
            this.TitleTextBox.GetBindingExpression(IsEnabledProperty)?.UpdateTarget();
            this.DescriptionTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateTarget();
            this.DescriptionTextBox.GetBindingExpression(IsEnabledProperty)?.UpdateTarget();

            this.TypeComboBox.GetBindingExpression(ItemsControl.ItemsSourceProperty)?.UpdateTarget();
            this.TypeComboBox.GetBindingExpression(System.Windows.Controls.Primitives.Selector.SelectedIndexProperty)?.UpdateTarget();
            this.TypeComboBox.GetBindingExpression(IsEnabledProperty)?.UpdateTarget();

            this.AreaComboBox.GetBindingExpression(ItemsControl.ItemsSourceProperty)?.UpdateTarget();
            this.AreaComboBox.GetBindingExpression(System.Windows.Controls.Primitives.Selector.SelectedIndexProperty)?.UpdateTarget();
            this.AreaComboBox.GetBindingExpression(IsEnabledProperty)?.UpdateTarget();

            this.MilestoneComboBox.GetBindingExpression(ItemsControl.ItemsSourceProperty)?.UpdateTarget();
            this.MilestoneComboBox.GetBindingExpression(System.Windows.Controls.Primitives.Selector.SelectedIndexProperty)?.UpdateTarget();
            this.MilestoneComboBox.GetBindingExpression(IsEnabledProperty)?.UpdateTarget();

            this.PriorityComboBox.GetBindingExpression(ItemsControl.ItemsSourceProperty)?.UpdateTarget();
            this.PriorityComboBox.GetBindingExpression(System.Windows.Controls.Primitives.Selector.SelectedIndexProperty)?.UpdateTarget();
            this.PriorityComboBox.GetBindingExpression(IsEnabledProperty)?.UpdateTarget();

            this.AssignedComboBox.GetBindingExpression(ItemsControl.ItemsSourceProperty)?.UpdateTarget();
            this.AssignedComboBox.GetBindingExpression(System.Windows.Controls.Primitives.Selector.SelectedIndexProperty)?.UpdateTarget();
            this.AssignedComboBox.GetBindingExpression(IsEnabledProperty)?.UpdateTarget();

            this.VisibleComboBox.GetBindingExpression(ItemsControl.ItemsSourceProperty)?.UpdateTarget();
            this.VisibleComboBox.GetBindingExpression(System.Windows.Controls.Primitives.Selector.SelectedIndexProperty)?.UpdateTarget();
            this.VisibleComboBox.GetBindingExpression(IsEnabledProperty)?.UpdateTarget();
        }
    }
}

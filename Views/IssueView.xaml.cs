using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using BIMcollab_BCF_WPF_MVVM.Model;
using BIMcollab_BCF_WPF_MVVM.ViewModel;

namespace BIMcollab_BCF_WPF_MVVM.Views
{
    /// <summary>
    /// Interaction logic for IssueView.xaml
    /// </summary>
    public partial class IssueView : UserControl
    {
        private readonly IssueViewModel issueViewModelObject;
        private EditIssueView editIssueView;

        public IssueView()
        {
            this.InitializeComponent();

            this.issueViewModelObject = new IssueViewModel();
            this.DataContext = this.issueViewModelObject;
        }

        #region Events

        internal class SelectionChangedEventArgs : EventArgs
        {
            public SelectionChangedEventArgs(Issue issue)
            {
                this.SelectedIssue = issue;
            }

            public Issue SelectedIssue { get; }
        }

        internal delegate void OnSelectionChangedDelegate(SelectionChangedEventArgs args);

        internal event OnSelectionChangedDelegate SelectionChanged;

        #endregion

        internal void LoadIssues(Project activeProject)
        {
            this.issueViewModelObject.LoadIssues(activeProject);
            this.editIssueView = new EditIssueView(activeProject);
        }

        private void IssuesGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            int selectedRowIndex = this.IssuesGrid.SelectedIndex;
            this.SelectionChanged?.Invoke(new SelectionChangedEventArgs(this.issueViewModelObject.Issues[selectedRowIndex]));
        }

        private void PublishMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            this.issueViewModelObject.Publish();
            this.ShowMessageBox(this.issueViewModelObject.PublishMessage);
        }

        private void EditMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            int selectedRowIndex = this.IssuesGrid.SelectedIndex;

            editIssueView.EditIssue(this.issueViewModelObject.Issues[selectedRowIndex]);
            editIssueView.Show();
        }

        private void AddMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            editIssueView.NewIssue();
            editIssueView.Show();
        }

        private void ShowMessageBox(string message)
        {
            MessageBox.Show(message, "BIMcollab Playground");
        }
    }
}

﻿using System.Windows.Controls;
using BIMcollab_BCF_WPF_MVVM.Model;
using BIMcollab_BCF_WPF_MVVM.ViewModel;

namespace BIMcollab_BCF_WPF_MVVM.Views
{
    /// <summary>
    /// Interaction logic for IssueOverviewView.xaml
    /// </summary>
    public partial class IssueOverviewView : UserControl
    {
        private readonly IssueOverviewViewModel issueOverviewViewModelObject;

        public IssueOverviewView()
        {
            this.InitializeComponent();
            this.issueOverviewViewModelObject = new IssueOverviewViewModel();
            this.DataContext = this.issueOverviewViewModelObject;
        }

        internal void ShowIssueOverview(Issue selectedIssue)
        {
            this.issueOverviewViewModelObject.SetSelectedIssue(selectedIssue);
            this.IssuePreviewImage.Source = this.issueOverviewViewModelObject.Snapshot();
            this.IssueInformationLabel.Content = this.issueOverviewViewModelObject.IssueInformation();
        }
    }
}

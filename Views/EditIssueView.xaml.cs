﻿using System.Windows;
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
        }

        internal void NewIssue()
        {
            this.editIssueViewModelObject = this.newIssueConcreteViewModel;

            this.editIssueViewModelObject.CreateNewIssue();

            this.DataContext = this.editIssueViewModelObject;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);

            e.Cancel = true;
            this.Hide();
        }
    }
}
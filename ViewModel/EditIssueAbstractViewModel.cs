using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using BIMcollab_BCF_WPF_MVVM.Model;

namespace BIMcollab_BCF_WPF_MVVM.ViewModel
{
    internal abstract class EditIssueAbstractViewModel
    {
        private const uint BcIssueStatusActive = 0;
        private const uint BcIssueStatusResolved = 1;
        private const uint BcIssueStatusClosed = 2;

        protected Project activeProject;
        protected Issue issue;

        public List<string> Milestones
        {
            get { return this.activeProject.Milestones; }
        }

        public List<string> Areas
        {
            get { return this.activeProject.Areas; }
        }

        public List<string> Labels
        {
            get { return this.activeProject.Labels; }
        }

        public List<string> Types
        {
            get { return this.activeProject.Types; }
        }

        public List<string> Priorities
        {
            get { return this.activeProject.Priorities; }
        }

        public List<string> Users
        {
            get { return this.activeProject.Users; }
        }

        public List<string> Visibilities
        {
            get { return this.activeProject.Visibilities; }
        }

        public string Title { get; set; }

        public string Description
        {
            get { return this.issue.Description; }

            set { this.issue.Description = value; }
        }

        public string ActiveStatus
        {
            get { return this.GetActiveStatus(); }
        }

        public int ActiveType
        {
            get { return this.GetActiveType(); }
            set { this.issue.TypeID = (uint)value; }
        }

        public int ActiveMilestone
        {
            get { return this.GetActiveMilestone(); }
            set { this.issue.MilestoneID = (uint) value; }
        }

        public int ActiveArea
        {
            get { return this.GetActiveArea(); }
            set { this.issue.AreaID = (uint) value; }
        }

        public int ActivePriority
        {
            get { return this.GetActivePriority(); }
            set { this.issue.PriorityID = (uint) value; }
        }

        public int OwnerIndex
        {
            get { return this.GetOwnerIndex(); }
            set { this.issue.OwnerIndex = (uint)value; }
        }

        public int ActiveVisibility
        {
            get { return this.GetActiveVisibility(); }
            set { this.issue.VisibilityID = (uint) value; }
        }

        public Visibility ResolvedButtonVisible
        {
            get { return this.IsResolvedButtonVisible(); }
        }

        public Visibility ResolveAndCloseButtonVisible
        {
            get { return this.IsResolveAndCloseButtonVisible(); }
        }

        public Visibility CloseButtonVisible
        {
            get { return this.IsCloseButtonVisible(); }
        }

        public Visibility ReopenButtonVisible
        {
            get { return this.IsReopenButtonVisible(); }
        }

        public Visibility ReactivateButtonVisible
        {
            get { return this.IsReactivateButtonVisible(); }
        }

        public bool TypeComboBoxEnabled
        {
            get { return this.IsTypeComboBoxEnabled(); }
        }

        public bool AreaComboBoxEnabled
        {
            get { return this.IsAreaComboBoxEnabled(); }
        }

        public bool MilestoneComboBoxEnabled
        {
            get { return this.IsMilestoneComboBoxEnabled(); }
        }

        public bool PriorityComboBoxEnabled
        {
            get { return this.IsPriorityComboBoxEnabled(); }
        }

        public bool AssignedComboBoxEnabled
        {
            get { return this.IsAssignedComboBoxEnabled(); }
        }

        public bool VisibilityComboBoxEnabled
        {
            get { return this.IsVisibilityComboBoxEnabled(); }
        }

        public bool DesriptionTextBoxEnabled
        {
            get { return this.IsDescriptionTextBoxEnabled(); }
        }

        public bool TitleTextBoxEnabled
        {
            get { return this.IsTitleTextBoxEnabled(); }
        }

        public void SetIssue(Issue editedIssue)
        {
            this.issue = editedIssue;

            this.Title = this.issue.Title;
        }

        public void CreateNewIssue()
        {
            List<string> milestones = this.activeProject.Milestones;
            List<string> areas = this.activeProject.Areas;
            List<string> labels = this.activeProject.Labels;
            List<string> types = this.activeProject.Types;
            List<string> priorities = this.activeProject.Priorities;
            List<string> statuses = this.activeProject.Statuses;

            BC_Issue newIssue = this.activeProject.CreateIssue();

            this.issue = new Issue(newIssue, ref milestones, ref areas, ref labels, ref types, ref priorities, ref statuses);
        }

        public void SetStatusActive()
        {
            this.issue.StatusID = BcIssueStatusActive;
        }

        public void SetStatusClosed()
        {
            this.issue.StatusID = BcIssueStatusClosed;
        }

        public void SetStatusResolved()
        {
            this.issue.StatusID = BcIssueStatusResolved;
        }

        private Visibility IsResolvedButtonVisible()
        {
            bool resolvedButtonEnabled = this.issue.StatusID == BcIssueStatusActive &&
                                         this.issue.IsOperationAllowed((uint)BC_Operation.operationIssueChangeStatus, BcIssueStatusResolved) &&
                                         this.issue.IsOperationAllowed(BC_Operation.operationIssueChangeStatus);

            return resolvedButtonEnabled ? Visibility.Visible : Visibility.Collapsed;
        }

        private Visibility IsResolveAndCloseButtonVisible()
        {
            bool resolveAndCloseButtonEnabled = this.issue.StatusID == BcIssueStatusActive &&
                                                this.issue.IsOperationAllowed((uint)BC_Operation.operationIssueChangeStatus, BcIssueStatusClosed) &&
                                                this.issue.IsOperationAllowed(BC_Operation.operationIssueChangeStatus);

            return resolveAndCloseButtonEnabled ? Visibility.Visible : Visibility.Collapsed;
        }

        private Visibility IsCloseButtonVisible()
        {
            bool closeButtonEnabled = this.issue.StatusID == BcIssueStatusResolved &&
                                      this.issue.IsOperationAllowed((uint)BC_Operation.operationIssueChangeStatus, BcIssueStatusClosed) &&
                                      this.issue.IsOperationAllowed(BC_Operation.operationIssueChangeStatus);

            return closeButtonEnabled ? Visibility.Visible : Visibility.Collapsed;
        }

        private Visibility IsReopenButtonVisible()
        {
            bool reopenButtonEnabled = this.issue.StatusID == BcIssueStatusClosed &&
                                       this.issue.IsOperationAllowed((uint)BC_Operation.operationIssueChangeStatus, BcIssueStatusActive) &&
                                       this.issue.IsOperationAllowed(BC_Operation.operationIssueChangeStatus);

            return reopenButtonEnabled ? Visibility.Visible : Visibility.Collapsed;
        }

        private Visibility IsReactivateButtonVisible()
        {
            bool reactivateButtonEnabled = this.issue.StatusID == BcIssueStatusResolved &&
                                           this.issue.IsOperationAllowed((uint)BC_Operation.operationIssueChangeStatus, BcIssueStatusActive) &&
                                           this.issue.IsOperationAllowed(BC_Operation.operationIssueChangeStatus);

            return reactivateButtonEnabled ? Visibility.Visible : Visibility.Collapsed;
        }

        private bool IsTypeComboBoxEnabled()
        {
            return this.issue.IsOperationAllowed(BC_Operation.operationIssueChangeType);
        }

        private bool IsAreaComboBoxEnabled()
        {
            return this.issue.IsOperationAllowed(BC_Operation.operationIssueChangeArea);
        }

        private bool IsMilestoneComboBoxEnabled()
        {
            return this.issue.IsOperationAllowed(BC_Operation.operationIssueChangeMilestone);
        }

        private bool IsPriorityComboBoxEnabled()
        {
            return this.issue.IsOperationAllowed(BC_Operation.operationIssueChangePriority);
        }

        private bool IsAssignedComboBoxEnabled()
        {
            return this.issue.IsOperationAllowed(BC_Operation.operationIssueChangeOwner);
        }

        private bool IsVisibilityComboBoxEnabled()
        {
            return this.issue.IsOperationAllowed(BC_Operation.operationIssueChangeVisibility);
        }

        private bool IsDescriptionTextBoxEnabled()
        {
            return this.issue.IsOperationAllowed(BC_Operation.operationIssueChangeDescription);
        }

        private bool IsTitleTextBoxEnabled()
        {
            return this.issue.IsOperationAllowed(BC_Operation.operationIssueChangeTitle);
        }

        protected abstract string GetActiveStatus();

        protected abstract int GetActiveType();

        protected abstract int GetActiveMilestone();

        protected abstract int GetActiveArea();

        protected abstract int GetActivePriority();

        protected abstract int GetOwnerIndex();

        protected abstract int GetActiveVisibility();
    }
}

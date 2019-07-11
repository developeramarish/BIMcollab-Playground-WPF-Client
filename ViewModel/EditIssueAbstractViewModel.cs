using System.Collections.Generic;
using BIMcollab_BCF_WPF_MVVM.Model;

namespace BIMcollab_BCF_WPF_MVVM.ViewModel
{
    internal abstract class EditIssueAbstractViewModel
    {
        public string Title
        {
            get { return this.issue.Title; }

            set { this.issue.Title = value; }
        }

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

        protected Project activeProject;
        protected Issue issue;

        public void SetIssue(Issue editedIssue)
        {
            this.issue = editedIssue;
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

        protected abstract string GetActiveStatus();

        protected abstract int GetActiveType();

        protected abstract int GetActiveMilestone();

        protected abstract int GetActiveArea();

        protected abstract int GetActivePriority();

        protected abstract int GetOwnerIndex();

        protected abstract int GetActiveVisibility();
    }
}

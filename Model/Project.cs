using System.Collections.Generic;
using System.ComponentModel;

namespace BIMcollab_BCF_WPF_MVVM.Model
{
    internal class Project
    {
        private readonly BC_Project project;

        public Project(string username, string password)
        {
            var dataModel = BC_DataModel.GetInstance();

            dataModel.SetActiveUser(string.Empty,
                                    string.Empty,
                                    password,
                                    username,
                                    string.Empty);

            dataModel.Connect("playground.bimcollab.com",
                              "460C8E9C-20E4-4188-BCA2-8E34F464C026");

            dataModel.SelectProjectByIndex(0);

            this.project = dataModel.GetActiveProject();

            this.GetMilestones();
            this.GetAreas();
            this.GetLabels();
            this.GetTypes();
            this.GetPriorities();
            this.GetStatuses();
        }

        public string Title
        {
            get { return this.project.GetTitle(); }
        }

        public List<string> Milestones { get; private set; }

        public List<string> Areas { get; private set; }

        public List<string> Labels { get; private set; }

        public List<string> Types { get; private set; }

        public List<string> Priorities { get; private set; }

        public List<string> Statuses { get; private set; }

        #region Issues

        public uint GetNumberOfIssues()
        {
            return this.project.GetNumberOfIssues();
        }

        public BC_Issue GetIssueByIndex(uint index)
        {
            return this.project.GetIssueByIndex(index);
        }

        #endregion

        #region Milestones

        public uint GetNumberOfMilestones()
        {
            return this.project.GetNumberOfMilestones();
        }

        public string GetMilestoneLabelByIndex(uint index)
        {
            return this.project.GetMilestoneLabelByIndex(index);
        }

        public bool GetMilestoneActiveByIndex(uint index)
        {
            return this.project.GetMilestoneActiveByIndex(index);
        }

        #endregion

        #region Areas

        public uint GetNumberOfAreas()
        {
            return this.project.GetNumberOfAreas();
        }

        public string GetAreaLabelByIndex(uint index)
        {
            return this.project.GetAreaLabelByIndex(index);
        }

        public bool GetAreaActiveByIndex(uint index)
        {
            return this.project.GetAreaActiveByIndex(index);
        }

        #endregion

        #region Labels

        public uint GetNumberOfIssueLabels()
        {
            return this.project.GetNumberOfIssueLabels();
        }

        public string GetIssueLabelLabelByIndex(uint index)
        {
            return this.project.GetIssueLabelLabelByIndex(index);
        }

        public bool GetIssueLabelActiveByIndex(uint index)
        {
            return this.project.GetIssueLabelActiveByIndex(index);
        }

        #endregion

        #region Types

        public uint GetNumberOfIssueTypes()
        {
            return this.project.GetNumberOfIssueTypes();
        }

        public string GetIssueTypeLabelByIndex(uint index)
        {
            return this.project.GetIssueTypeLabelByIndex(index);
        }

        public bool GetIssueTypeActiveByIndex(uint index)
        {
            return this.project.GetIssueTypeActiveByIndex(index);
        }

        #endregion

        #region Priorities

        public uint GetNumberOfIssuePriorities()
        {
            return this.project.GetNumberOfIssuePriorities();
        }

        public string GetIssuePriorityLabelByIndex(uint index)
        {
            return this.project.GetIssuePriorityLabelByIndex(index);
        }

        public bool GetIssuePriorityActiveByIndex(uint index)
        {
            return this.project.GetIssuePriorityActiveByIndex(index);
        }

        #endregion

        #region Status

        public uint GetNumberOfIssueStatuses()
        {
            return this.project.GetNumberOfIssueStatuses();
        }

        public string GetIssueStatusLabelByIndex(uint index)
        {
            return this.project.GetIssueStatusLabelByIndex(index);
        }

        public bool GetIssueStatusActiveByIndex(uint index)
        {
            return this.project.GetIssueStatusActiveByIndex(index);
        }

        #endregion

        private void GetMilestones()
        {
            this.Milestones = new List<string>();
            uint numberOfStatuses = this.project.GetNumberOfMilestones();

            for (uint i = 0; i < numberOfStatuses; i++)
            {
                string status = this.project.GetMilestoneLabelByIndex(i);
                this.Milestones.Add(status);
            }
        }

        private void GetAreas()
        {
            this.Areas = new List<string>();
            uint numberOfAreas = this.project.GetNumberOfAreas();

            for (uint i = 0; i < numberOfAreas; i++)
            {
                string area = this.project.GetAreaLabelByIndex(i);
                this.Areas.Add(area);
            }
        }

        private void GetLabels()
        {
            this.Labels = new List<string>();
            uint numberOfLabels = this.project.GetNumberOfIssueLabels();

            for (uint i = 0; i < numberOfLabels; i++)
            {
                string label = this.project.GetIssueLabelLabelByIndex(i);
                this.Labels.Add(label);
            }
        }

        private void GetTypes()
        {
            this.Types = new List<string>();
            uint numberOfTypes = this.project.GetNumberOfIssueTypes();

            for (uint i = 0; i < numberOfTypes; i++)
            {
                string type = this.project.GetIssueTypeLabelByIndex(i);
                this.Types.Add(type);
            }
        }

        private void GetPriorities()
        {
            this.Priorities = new List<string>();
            uint numberOfPriorities = this.project.GetNumberOfIssuePriorities();

            for (uint i = 0; i < numberOfPriorities; i++)
            {
                string priority = this.project.GetIssuePriorityLabelByIndex(i);
                this.Priorities.Add(priority);
            }
        }

        private void GetStatuses()
        {
            this.Statuses = new List<string>();
            uint numberOfStatuses = this.project.GetNumberOfIssueStatuses();

            for (uint i = 0; i < numberOfStatuses; i++)
            {
                string status = this.project.GetIssueStatusLabelByIndex(i);
                this.Statuses.Add(status);
            }
        }
    }
}

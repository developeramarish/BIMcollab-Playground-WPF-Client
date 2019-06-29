using System.Collections.Generic;
using System.Collections.ObjectModel;
using BIMcollab_BCF_WPF_MVVM.Model;

namespace BIMcollab_BCF_WPF_MVVM.ViewModel
{
    internal class IssueViewModel
    {
        public ObservableCollection<Issue> Issues { get; set; }

        private Project activeProject;

        public IssueViewModel()
        {
            this.Issues = new ObservableCollection<Issue>();
        }

        public void LoadIssues(Project project)
        {
            this.activeProject = project;
            this.GetIssues();
        }

        private void GetIssues()
        {
            List<string> milestones = this.activeProject.Milestones;
            List<string> areas = this.activeProject.Areas;
            List<string> labels = this.activeProject.Labels;
            List<string> types = this.activeProject.Types;
            List<string> priorities = this.activeProject.Priorities;
            List<string> statuses = this.activeProject.Statuses;

            uint numberOfIssues = this.activeProject.GetNumberOfIssues();

            for (uint i = 0; i < numberOfIssues; i++)
            {
                BC_Issue issue = this.activeProject.GetIssueByIndex(i);
                this.Issues.Add(new Issue(issue, ref milestones, ref areas, ref labels, ref types, ref priorities, ref statuses));
            }
        }
    }
}

using BIMcollab_BCF_WPF_MVVM.Model;

namespace BIMcollab_BCF_WPF_MVVM.ViewModel
{
    internal class ProjectViewModel
    {
        public ProjectViewModel()
        {
            
        }

        public bool ConnectToProject(string username, string password)
        {
            if (this.IsAlreadyConnected())
            {
                return false;
            }

            if (username == string.Empty || password == string.Empty)
            {
                return false;
            }

            this.ActiveProject = new Project(username, password);
            return true;
        }

        public Project ActiveProject { get; private set; }

        public string ActiveProjectTitle
        {
            get { return this.ActiveProject.Title; }
        }

        private bool IsAlreadyConnected()
        {
            return this.ActiveProject != null;
        }
    }
}

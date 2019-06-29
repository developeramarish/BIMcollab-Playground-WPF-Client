using System;
using System.Windows;
using System.Windows.Controls;
using BIMcollab_BCF_WPF_MVVM.Model;
using BIMcollab_BCF_WPF_MVVM.ViewModel;

namespace BIMcollab_BCF_WPF_MVVM.Views
{
    /// <summary>
    /// Interaction logic for ProjectView.xaml
    /// </summary>
    public partial class ProjectView : UserControl
    {
        private readonly ProjectViewModel projectViewModelObject;

        public ProjectView()
        {
            this.InitializeComponent();

            this.projectViewModelObject = new ProjectViewModel();
            this.DataContext = this.projectViewModelObject;
        }

        #region Events

        internal class ConnectedEventArgs : EventArgs
        {
            public ConnectedEventArgs(Project project)
            {
                this.ActiveProject = project;
            }

            public Project ActiveProject { get; }
        }

        internal delegate void OnConnectedDelegate(ConnectedEventArgs args);

        internal event OnConnectedDelegate Connected;

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool connected = this.projectViewModelObject.ConnectToProject(this.UsernameTextBox.Text, this.PasswordBox.Password);

            if (connected)
            {
                this.UsernameTextBox.Text = string.Empty;
                this.PasswordBox.Password = string.Empty;
                this.InfoLabel.Content = $"Active project: {this.projectViewModelObject.ActiveProjectTitle}";

                this.Connected?.Invoke(new ConnectedEventArgs(this.projectViewModelObject.ActiveProject));
            }
        }
    }
}

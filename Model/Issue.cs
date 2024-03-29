﻿using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BIMcollab_BCF_WPF_MVVM.Model
{
    internal class Issue
    {
        private readonly BC_Issue issue;

        public Issue(BC_Issue issue,
                     ref List<string> milestones,
                     ref List<string> areas,
                     ref List<string> labels,
                     ref List<string> types,
                     ref List<string> priorities,
                     ref List<string> statuses)
        {
            this.issue = issue;

            this.Milestone = milestones[(int) this.MilestoneID];
            this.Area = areas[(int) this.AreaID];
            this.Type = types[(int) this.TypeID];
            this.Priority = priorities[(int) this.PriorityID];
            this.Status = statuses[(int) this.StatusID];
            this.Labels = this.CreateLabels(ref labels);
        }

        public uint MilestoneID
        {
            get { return this.issue.GetMilestone(); }

            set
            {
                if (!this.issue.IsOperationAllowed(BC_Operation.operationIssueChangeMilestone))
                {
                    return;
                }

                if (this.issue.GetMilestone() != value)
                {
                    this.issue.SetMilestone(value);
                }
            }
        }

        public string Milestone { get; set; }

        public uint AreaID
        {
            get { return this.issue.GetArea(); }

            set
            {
                if (!this.issue.IsOperationAllowed(BC_Operation.operationIssueChangeArea))
                {
                    return;
                }

                if (this.issue.GetArea() != value)
                {
                    this.issue.SetArea(value);
                }
            }
        }

        public string Area { get; set; }

        public uint TypeID
        {
            get { return this.issue.GetIssueType(); }

            set
            {
                if (!this.issue.IsOperationAllowed(BC_Operation.operationIssueChangeType))
                {
                    return;
                }

                if (this.issue.GetIssueType() != value)
                {
                    this.issue.SetIssueType(value);
                }
            }
        }

        public string Type { get; set; }

        public uint PriorityID
        {
            get { return this.issue.GetPriority(); }

            set
            {
                if (!this.issue.IsOperationAllowed(BC_Operation.operationIssueChangePriority))
                {
                    return;
                }

                if (this.issue.GetPriority() != value)
                {
                    this.issue.SetPriority(value);
                }
            }
        }

        public string Priority { get; set; }

        public uint StatusID
        {
            get { return this.issue.GetStatus(); }

            set
            {
                if (!this.issue.IsOperationAllowed(BC_Operation.operationIssueChangeStatus))
                {
                    return;
                }

                if (this.issue.GetStatus() != value)
                {
                    this.issue.SetStatus(value);
                }
            }
        }

        public string Status { get; set; }

        public string Title
        {
            get { return this.issue.GetTitle(); }

            set
            {
                if (!this.issue.IsOperationAllowed(BC_Operation.operationIssueChangeTitle))
                {
                    return;
                }

                if (this.issue.GetTitle() != value)
                {
                    this.issue.SetTitle(value);
                }
            }
        }

        public string Description
        {
            get { return this.issue.GetDescription(); }

            set
            {
                if (!this.issue.IsOperationAllowed(BC_Operation.operationIssueChangeDescription))
                {
                    return;
                }

                if (this.issue.GetDescription() != value)
                {
                    this.issue.SetDescription(value);
                }
            }
        }

        public string Modified
        {
            get { return this.issue.GetModifiedOn(); }
        }

        public string Owner
        {
            get { return this.issue.GetOwner().GetName(); }
        }

        public uint OwnerIndex
        {
            get { return this.issue.GetOwnerIndex(); }

            set
            {
                if (!this.issue.IsOperationAllowed(BC_Operation.operationIssueChangeOwner))
                {
                    return;
                }

                if (this.issue.GetOwnerIndex() != value)
                {
                    this.issue.SetOwnerByIndex(value);
                }
            }
        }

        public uint VisibilityID
        {
            get { return this.issue.GetVisibility(); }

            set
            {
                if (!this.issue.IsOperationAllowed(BC_Operation.operationIssueChangeVisibility))
                {
                    return;
                }

                if (this.issue.GetVisibility() != value)
                {
                    this.issue.SetVisibility(value);
                }
            }
        }

        public string Creator
        {
            get { return this.issue.GetCreator().GetName(); }
        }

        public ImageSource Snapshot
        {
            get { return this.GetIssueSnapshot(); }
        }

        public List<string> Labels { get; }

        public List<BC_Comment> Comments
        {
            get { return this.GetComments(); }
        }

        public void IncludeInPublish()
        {
            this.issue.IncludeInPublish(true);
        }

        public bool IsOperationAllowed(BC_Operation operation)
        {
            return this.issue.IsOperationAllowed(operation);
        }

        public bool IsOperationAllowed(BC_Operation operation, uint target)
        {
            return this.issue.IsOperationAllowed(operation, target);
        }

        private ImageSource GetIssueSnapshot()
        {
            var image = new Image();
            uint numberOfComments = this.issue.GetNumberOfComments();

            if (numberOfComments == 0)
            {
                return image.Source;
            }

            uint latestCommentIndex = numberOfComments - 1;
            BC_Comment comment = this.issue.GetCommentByIndex(latestCommentIndex);

            if (comment.HasViewPoint())
            {
                BC_ViewPoint viewPoint = comment.GetViewPoint();

                if (viewPoint.HasSnapShot())
                {
                    BC_SnapShot snapShot = viewPoint.GetSnapShot();

                    uint imageSize = snapShot.GetImageSize();

                    if (snapShot.HasImage())
                    {
                        var imageArray = new byte[(int)imageSize];
                        snapShot.GetImage(imageArray, imageSize);

                        using (var stream = new MemoryStream(imageArray))
                        {
                            image.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                        }
                    }
                }
            }

            return image.Source;
        }

        private List<string> CreateLabels(ref List<string> labels)
        {
            uint numberOfLabels = this.issue.GetNumberOfLabels();
            var issueLabels = new List<string>();

            for (uint i = 0; i < numberOfLabels; i++)
            {
                uint labelIndex = this.issue.GetLabelByIndex(i);
                issueLabels.Add(labels[(int)labelIndex]);
            }

            return issueLabels;
        }

        private List<BC_Comment> GetComments()
        {
            var comments = new List<BC_Comment>();

            uint numberOfComments = this.issue.GetNumberOfComments();

            for (uint i = 0; i < numberOfComments; i++)
            {
                comments.Add(this.issue.GetCommentByIndex(i));
            }

            return comments;
        }
    }
}

using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BIMcollab_BCF_WPF_MVVM.Model
{
    internal class Comment
    {
        private readonly BC_Comment comment;

        public Comment(BC_Comment comment)
        {
            this.comment = comment;
        }

        public string Created
        {
            get { return this.comment.GetCreatedOn(); }
        }

        public string Description
        {
            get { return this.comment.GetText(); }
        }

        public string Creator
        {
            get { return this.comment.GetCreator().GetName(); }
        }

        public ImageSource Thumbnail
        {
            get { return this.GetThumbnail(); }
        }

        private ImageSource GetThumbnail()
        {
            var image = new Image();

            if (this.comment.HasViewPoint())
            {
                BC_ViewPoint viewPoint = this.comment.GetViewPoint();

                if (viewPoint.HasSnapShot())
                {
                    BC_SnapShot snapShot = viewPoint.GetSnapShot();

                    uint imageSize = snapShot.GetThumbnailSize();

                    if (snapShot.HasImage())
                    {
                        var imageArray = new byte[(int)imageSize];
                        snapShot.GetThumbnail(imageArray, imageSize);

                        using (var stream = new MemoryStream(imageArray))
                        {
                            image.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                        }
                    }
                }
            }

            return image.Source;
        }
    }
}

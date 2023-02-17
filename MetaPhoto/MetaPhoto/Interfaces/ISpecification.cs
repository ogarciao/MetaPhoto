using MetaPhoto.Dtos;

namespace MetaPhoto.Interfaces
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T t);
    }

    public class PhotoTitleSpecification : ISpecification<Photo>
    {
        private string title;

        public PhotoTitleSpecification(string title)
        {
            this.title = title ?? throw new ArgumentNullException(nameof(title));
        }

        public bool IsSatisfiedBy(Photo t)
        {
            return t.Title.ToLower().Contains(title);
        }
    }

    public class AlbumTitleSpecification: ISpecification<Photo>
    {
        private string albumTitle;

        public AlbumTitleSpecification(string albumTitle)
        {
            this.albumTitle = albumTitle ?? throw new ArgumentNullException(nameof(albumTitle));
        }

        public bool IsSatisfiedBy(Photo t)
        {
            return t.Album != null
                && t.Album.Title.ToLower().Contains(albumTitle);
        }
    }

    public class UserEmailSpecification : ISpecification<Photo>
    {
        private string email;
        public UserEmailSpecification(string email)
        {
            this.email = email ?? throw new ArgumentNullException(nameof(email));
        }

        public bool IsSatisfiedBy(Photo t)
        {
            return t.Album != null
                && t.Album.User != null
                && t.Album.User.Email.ToLower().Equals(email);
        }
    }

    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T>? firstSpec;
        private ISpecification<T>? secondSpec;
        private ISpecification<T>? thirdSpec;

        public AndSpecification(ISpecification<T>? firstSpec, ISpecification<T>? secondSpec, ISpecification<T>? thirdSpec)
        {
            this.firstSpec = firstSpec;
            this.secondSpec = secondSpec;
            this.thirdSpec = thirdSpec;
        }

        public bool IsSatisfiedBy(T t)
        {
            bool isSatisfied = true;

            if (firstSpec != null)
            {
                isSatisfied &= firstSpec.IsSatisfiedBy(t); 
            }

            if (secondSpec != null)
            {
                isSatisfied &= secondSpec.IsSatisfiedBy(t);
            }

            if (thirdSpec != null)
            {
                isSatisfied &= thirdSpec.IsSatisfiedBy(t);
            }

            return isSatisfied;
        }
    }
}

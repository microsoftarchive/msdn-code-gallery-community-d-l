using System.Collections.Generic;
using System.Linq;

namespace Comments.Models
{
    public class DictionaryCommentRepository : ICommentRepository
    {
        int nextID = 0;
        Dictionary<int, Comment> comments = new Dictionary<int, Comment>();

        public IEnumerable<Comment> Get()
        {
            return comments.Values.OrderBy(comment => comment.ID);
        }

        public bool TryGet(int id, out Comment comment)
        {
            return comments.TryGetValue(id, out comment);
        }

        public Comment Add(Comment comment)
        {
            comment.ID = nextID++;
            comments[comment.ID] = comment;
            return comment;
        }

        public bool Delete(int id)
        {
            return comments.Remove(id);
        }

        public bool Update(Comment comment)
        {
            bool update = comments.ContainsKey(comment.ID);
            comments[comment.ID] = comment;
            return update;
        }
    }
}

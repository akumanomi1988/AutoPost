using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.Domain.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required List<string> ContentPath { get; set; }
        public required string Description { get; set; }
        public required string Category { get; set; }
        public required string Privacy { get; set; } // public, private, unlisted
        public DateTime Created { get; set; }
        public required ContentType ContentType { get; set; }
        public required List<SocialNetwork> PublishedNetworks { get; set; } = new List<SocialNetwork>();
        public required List<SocialNetwork> PendingNetworks { get; set; }= new List<SocialNetwork>();
        public required String[] Tags { get; set; }
        public PublishStatus Status()
        {
            if (PublishedNetworks.Count == 0 && PendingNetworks.Count == 0) { return PublishStatus.Error; }
            if (PublishedNetworks.Count == 0) { return PublishStatus.Pending; }
            if (PendingNetworks.Count > 0 && PendingNetworks.Count > 0) { return PublishStatus.OnWorking; }
            if (PendingNetworks.Count > 0 && PendingNetworks.Count == 0) { return PublishStatus.Published; }
            return PublishStatus.Error;
        }
        public enum PublishStatus
        {
            Error,
            Pending,
            OnWorking,
            Published
        }
    }
}

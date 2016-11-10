using System;
using System.Collections.Generic;

namespace kBackup.Classes
{
    public class ZApiModel
    {
        #region User

        public class UserCollection
        {
            public User user { get; set; }
            //public IList<User> users { get; set; }
            //public string next_page { get; set; }
        }

        public class User
        {
            public long? id { get; set; }
            public string email { get; set; }
            public string name { get; set; }
            public bool? active { get; set; }
            public string alias { get; set; }
            public bool? chat_only { get; set; }
            public DateTime? created_at { get; set; }
            public long? custom_role_id { get; set; }
            public string details { get; set; }
            public string external_id { get; set; }
            public DateTime? last_login_at { get; set; }
            public string locale { get; set; }
            public int? locale_id { get; set; }
            public bool? moderator { get; set; }
            public string notes { get; set; }
            public bool? only_private_comments { get; set; }
            public long? organization_id { get; set; }
            public string phone { get; set; }
            public Photo photo { get; set; }
            public bool? restricted_agent { get; set; }
            public string role { get; set; }
            public bool? shared { get; set; }
            public bool? shared_agent { get; set; }
            public string shared_phone_number { get; set; }
            public string signature { get; set; }
            public bool? suspended { get; set; }
            public IList<string> tags { get; set; }
            public string ticket_restriction { get; set; }
            public string time_zone { get; set; }
            public bool? two_factor_auth_enabled { get; set; }
            public DateTime? updated_at { get; set; }
            public string url { get; set; }
            public UserFields user_fields { get; set; }
            public bool? verified { get; set; }
        }

        public class UserFields
        {
        }

        public class Photo
        {
            public string url { get; set; }
            public long? id { get; set; }
            public string file_name { get; set; }
            public string content_url { get; set; }
            public string mapped_content_url { get; set; }
            public string content_type { get; set; }
            public int? size { get; set; }
            public int? width { get; set; }
            public int? height { get; set; }
            public bool? inline { get; set; }
            public IList<Thumbnail> thumbnails { get; set; }
        }

        public class Thumbnail
        {
            public string url { get; set; }
            public long? id { get; set; }
            public string file_name { get; set; }
            public string content_url { get; set; }
            public string mapped_content_url { get; set; }
            public string content_type { get; set; }
            public int? size { get; set; }
            public int? width { get; set; }
            public int? height { get; set; }
            public bool? inline { get; set; }
        }

        #endregion

        #region Help Center

        public class CategoryCollection
        {
            public IList<Category> categories { get; set; }
            public int page { get; set; }
            public object previous_page { get; set; }
            public object next_page { get; set; }
            public int per_page { get; set; }
            public int page_count { get; set; }
            public int count { get; set; }
            public string sort_by { get; set; }
            public string sort_order { get; set; }
        }

        public class Category
        {
            public int id { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
            public int position { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string locale { get; set; }
            public string source_locale { get; set; }
            public bool outdated { get; set; }
        }

        public class SectionCollection
        {
            public IList<Section> sections { get; set; }
            public int page { get; set; }
            public object previous_page { get; set; }
            public object next_page { get; set; }
            public int per_page { get; set; }
            public int page_count { get; set; }
            public int count { get; set; }
            public string sort_by { get; set; }
            public string sort_order { get; set; }
        }

        public class Section
        {
            public int id { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
            public int category_id { get; set; }
            public int position { get; set; }
            public string sorting { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string locale { get; set; }
            public string source_locale { get; set; }
            public bool outdated { get; set; }
        }

        public class ArticleCollection
        {
            public IList<Article> articles { get; set; }
            public IList<Article> topics { get; set; }
            public int page { get; set; }
            public string previous_page { get; set; }
            public string next_page { get; set; }
            public int per_page { get; set; }
            public int page_count { get; set; }
            public int count { get; set; }
            public string sort_by { get; set; }
            public string sort_order { get; set; }
        }

        public class Article
        {
            public int id { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
            public long author_id { get; set; }
            public bool comments_disabled { get; set; }
            public IList<object> label_names { get; set; }
            public bool draft { get; set; }
            public bool promoted { get; set; }
            public int position { get; set; }
            public int vote_sum { get; set; }
            public int vote_count { get; set; }
            public int section_id { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public string name { get; set; }
            public string title { get; set; }
            public string body { get; set; }
            public string source_locale { get; set; }
            public string locale { get; set; }
            public bool outdated { get; set; }
        }
        
        public class ArticleCommentCollection
        {
            public IList<ArticleComment> comments { get; set; }
            public int page { get; set; }
            public object previous_page { get; set; }
            public object next_page { get; set; }
            public int per_page { get; set; }
            public int page_count { get; set; }
            public int count { get; set; }
        }

        public class ArticleComment
        {
            public int id { get; set; }
            public string url { get; set; }
            public string body { get; set; }
            public long author_id { get; set; }
            public int source_id { get; set; }
            public string source_type { get; set; }
            public string html_url { get; set; }
            public string locale { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public int vote_sum { get; set; }
            public int vote_count { get; set; }
        }


        #endregion

        #region Community

        public class TopicCollection
        {
            public IList<Topic> topics { get; set; }
            public int page { get; set; }
            public string previous_page { get; set; }
            public string next_page { get; set; }
            public int per_page { get; set; }
            public int page_count { get; set; }
            public int count { get; set; }
        }

        public class Topic
        {
            public int id { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public int position { get; set; }
            public int follower_count { get; set; }
            public int community_id { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
        }

        public class PostCollection
        {
            public IList<Post> posts { get; set; }
            public int page { get; set; }
            public string previous_page { get; set; }
            public string next_page { get; set; }
            public int per_page { get; set; }
            public int page_count { get; set; }
            public int count { get; set; }
        }

        public class Post
        {
            public int id { get; set; }
            public string title { get; set; }
            public string details { get; set; }
            public long author_id { get; set; }
            public int vote_sum { get; set; }
            public int vote_count { get; set; }
            public int comment_count { get; set; }
            public int follower_count { get; set; }
            public int topic_id { get; set; }
            public string html_url { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public string url { get; set; }
            public bool featured { get; set; }
            public bool pinned { get; set; }
            public bool closed { get; set; }
            public string status { get; set; }
        }

        public class PostCommentCollection
        {
            public IList<Comment> comments { get; set; }
            public int page { get; set; }
            public object previous_page { get; set; }
            public object next_page { get; set; }
            public int per_page { get; set; }
            public int page_count { get; set; }
            public int count { get; set; }
        }

        public class Comment
        {
            public int id { get; set; }
            public string body { get; set; }
            public object author_id { get; set; }
            public int vote_sum { get; set; }
            public int vote_count { get; set; }
            public bool official { get; set; }
            public string html_url { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public string url { get; set; }
            public int post_id { get; set; }
        }

        #endregion
    }
}
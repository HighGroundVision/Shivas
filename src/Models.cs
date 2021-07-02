using System;
using System.Collections.Generic;
using System.Text;

namespace HGV.Shivas.Fun
{
    
    public class RedditDocument
    {
        public string id {get;set;}
        public string title {get;set;}
        public string url {get;set;}
    }

    public class RedditDocumentRoot
    {
        public string kind { get; set; }
        public ListingData data { get; set; }
    }

    public class ListingData
    {
        //public string modhash { get; set; }
        //public int dist { get; set; }
        //public Facets facets { get; set; }
        //public string after { get; set; }
        //public string geo_filter { get; set; }
        public Child[] children { get; set; }
        // public object before { get; set; }
    }

    //public class Facets
    //{
    //}

    public class Child
    {
        public string kind { get; set; }
        public PostData data { get; set; }
    }

    public class PostData
    {
        //public object approved_at_utc { get; set; }
        //public string subreddit { get; set; }
        //public string selftext { get; set; }
        //public string author_fullname { get; set; }
        //public bool saved { get; set; }
        //public object mod_reason_title { get; set; }
        //public int gilded { get; set; }
        //public bool clicked { get; set; }
        public string title { get; set; }
        //public Link_Flair_Richtext[] link_flair_richtext { get; set; }
        //public string subreddit_name_prefixed { get; set; }
        //public bool hidden { get; set; }
        //public int pwls { get; set; }
        //public string link_flair_css_class { get; set; }
        //public int downs { get; set; }
        //public object top_awarded_type { get; set; }
        //public bool hide_score { get; set; }
        //public Media_Metadata media_metadata { get; set; }
        //public string name { get; set; }
        //public bool quarantine { get; set; }
        //public string link_flair_text_color { get; set; }
        //public float upvote_ratio { get; set; }
        //public string author_flair_background_color { get; set; }
        //public string subreddit_type { get; set; }
        //public int ups { get; set; }
        //public int total_awards_received { get; set; }
        //public Media_Embed media_embed { get; set; }
        //public string author_flair_template_id { get; set; }
        //public bool is_original_content { get; set; }
        //public object[] user_reports { get; set; }
        //public Secure_Media secure_media { get; set; }
        //public bool is_reddit_media_domain { get; set; }
        //public bool is_meta { get; set; }
        //public object category { get; set; }
        //public Secure_Media_Embed secure_media_embed { get; set; }
        //public string link_flair_text { get; set; }
        //public bool can_mod_post { get; set; }
        //public int score { get; set; }
        //public object approved_by { get; set; }
        //public bool is_created_from_ads_ui { get; set; }
        //public bool author_premium { get; set; }
        //public string thumbnail { get; set; }
        //public object edited { get; set; }
        //public string author_flair_css_class { get; set; }
        //public Author_Flair_Richtext[] author_flair_richtext { get; set; }
        //public Gildings gildings { get; set; }
        //public object content_categories { get; set; }
        //public bool is_self { get; set; }
        //public object mod_note { get; set; }
        //public int created { get; set; }
        //public string link_flair_type { get; set; }
        //public int wls { get; set; }
        //public object removed_by_category { get; set; }
        //public object banned_by { get; set; }
        //public string author_flair_type { get; set; }
        //public string domain { get; set; }
        //public bool allow_live_comments { get; set; }
        //public string selftext_html { get; set; }
        //public bool? likes { get; set; }
        //public object suggested_sort { get; set; }
        //public object banned_at_utc { get; set; }
        //public object view_count { get; set; }
        //public bool archived { get; set; }
        //public bool no_follow { get; set; }
        //public bool is_crosspostable { get; set; }
        //public bool pinned { get; set; }
        //public bool over_18 { get; set; }
        //public All_Awardings[] all_awardings { get; set; }
        //public object[] awarders { get; set; }
        //public bool media_only { get; set; }
        //public string link_flair_template_id { get; set; }
        //public bool can_gild { get; set; }
        //public bool spoiler { get; set; }
        //public bool locked { get; set; }
        //public string author_flair_text { get; set; }
        //public object[] treatment_tags { get; set; }
        //public bool visited { get; set; }
        //public object removed_by { get; set; }
        //public object num_reports { get; set; }
        //public object distinguished { get; set; }
        //public string subreddit_id { get; set; }
        //public object mod_reason_by { get; set; }
        //public object removal_reason { get; set; }
        //public string link_flair_background_color { get; set; }
        public string id { get; set; }
        //public bool is_robot_indexable { get; set; }
        //public object report_reasons { get; set; }
        //public string author { get; set; }
        //public object discussion_type { get; set; }
        //public int num_comments { get; set; }
        //public bool send_replies { get; set; }
        //public string whitelist_status { get; set; }
        //public bool contest_mode { get; set; }
        //public object[] mod_reports { get; set; }
        //public bool author_patreon_flair { get; set; }
        //public string author_flair_text_color { get; set; }
        public string permalink { get; set; }
        //public string parent_whitelist_status { get; set; }
        //public bool stickied { get; set; }
        //public string url { get; set; }
        //public int subreddit_subscribers { get; set; }
        //public int created_utc { get; set; }
        //public int num_crossposts { get; set; }
        //public Media media { get; set; }
        //public bool is_video { get; set; }
        //public string url_overridden_by_dest { get; set; }
        //public string rte_mode { get; set; }
    }

    //public class Media_Metadata
    //{
    //    public Viemvkw70n871 viemvkw70n871 { get; set; }
    //}

    //public class Viemvkw70n871
    //{
    //    public string status { get; set; }
    //    public string e { get; set; }
    //    public string m { get; set; }
    //    public P[] p { get; set; }
    //    public S s { get; set; }
    //    public string id { get; set; }
    //}

    //public class S
    //{
    //    public int y { get; set; }
    //    public int x { get; set; }
    //    public string u { get; set; }
    //}

    //public class P
    //{
    //    public int y { get; set; }
    //    public int x { get; set; }
    //    public string u { get; set; }
    //}

    //public class Media_Embed
    //{
    //    public string content { get; set; }
    //    public int width { get; set; }
    //    public bool scrolling { get; set; }
    //    public int height { get; set; }
    //}

    //public class Secure_Media
    //{
    //    public string type { get; set; }
    //    public Oembed oembed { get; set; }
    //}

    //public class Oembed
    //{
    //    public string provider_url { get; set; }
    //    public string version { get; set; }
    //    public string title { get; set; }
    //    public string type { get; set; }
    //    public int thumbnail_width { get; set; }
    //    public int height { get; set; }
    //    public int width { get; set; }
    //    public string html { get; set; }
    //    public string author_name { get; set; }
    //    public string provider_name { get; set; }
    //    public string thumbnail_url { get; set; }
    //    public int thumbnail_height { get; set; }
    //    public string author_url { get; set; }
    //}

    //public class Secure_Media_Embed
    //{
    //    public string content { get; set; }
    //    public int width { get; set; }
    //    public bool scrolling { get; set; }
    //    public string media_domain_url { get; set; }
    //    public int height { get; set; }
    //}

    //public class Gildings
    //{
    //}

    //public class Media
    //{
    //    public string type { get; set; }
    //    public Oembed1 oembed { get; set; }
    //}

    //public class Oembed1
    //{
    //    public string provider_url { get; set; }
    //    public string version { get; set; }
    //    public string title { get; set; }
    //    public string type { get; set; }
    //    public int thumbnail_width { get; set; }
    //    public int height { get; set; }
    //    public int width { get; set; }
    //    public string html { get; set; }
    //    public string author_name { get; set; }
    //    public string provider_name { get; set; }
    //    public string thumbnail_url { get; set; }
    //    public int thumbnail_height { get; set; }
    //    public string author_url { get; set; }
    //}

    //public class Link_Flair_Richtext
    //{
    //    public string e { get; set; }
    //    public string t { get; set; }
    //}

    //public class Author_Flair_Richtext
    //{
    //    public string a { get; set; }
    //    public string e { get; set; }
    //    public string u { get; set; }
    //    public string t { get; set; }
    //}

    //public class All_Awardings
    //{
    //    public int giver_coin_reward { get; set; }
    //    public object subreddit_id { get; set; }
    //    public bool is_new { get; set; }
    //    public int days_of_drip_extension { get; set; }
    //    public int coin_price { get; set; }
    //    public string id { get; set; }
    //    public int penny_donate { get; set; }
    //    public string award_sub_type { get; set; }
    //    public int coin_reward { get; set; }
    //    public string icon_url { get; set; }
    //    public int days_of_premium { get; set; }
    //    public object tiers_by_required_awardings { get; set; }
    //    public Resized_Icons[] resized_icons { get; set; }
    //    public int icon_width { get; set; }
    //    public int static_icon_width { get; set; }
    //    public object start_date { get; set; }
    //    public bool is_enabled { get; set; }
    //    public object awardings_required_to_grant_benefits { get; set; }
    //    public string description { get; set; }
    //    public object end_date { get; set; }
    //    public int subreddit_coin_reward { get; set; }
    //    public int count { get; set; }
    //    public int static_icon_height { get; set; }
    //    public string name { get; set; }
    //    public Resized_Static_Icons[] resized_static_icons { get; set; }
    //    public string icon_format { get; set; }
    //    public int icon_height { get; set; }
    //    public int penny_price { get; set; }
    //    public string award_type { get; set; }
    //    public string static_icon_url { get; set; }
    //}

    //public class Resized_Icons
    //{
    //    public string url { get; set; }
    //    public int width { get; set; }
    //    public int height { get; set; }
    //}

    //public class Resized_Static_Icons
    //{
    //    public string url { get; set; }
    //    public int width { get; set; }
    //    public int height { get; set; }
    //}
}

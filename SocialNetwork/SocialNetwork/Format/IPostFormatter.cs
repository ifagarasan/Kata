﻿namespace SocialNetwork.Format
{
    public interface IPostFormatter
    {
        string FormatTimelinePost(IPost post);
        string FormatWallPost(IPost post);
    }
}
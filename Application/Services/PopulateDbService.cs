using Instagram.Data;
using Instagram.Models;
using Instagram.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Instagram.Services;

public class PopulateDbService : IPopulateDbService
{
    private readonly InstagramContext _context;

    public PopulateDbService(InstagramContext context)
    {
        _context = context;
    }

    public async Task PopulateUser(DataTable userDataTable)
    {
        List<User> userList = new List<User>();
        for (int i = 0; i < userDataTable.Rows.Count; i++)
        {
            User user = new User();
            user.Username = userDataTable.Rows[i]["Username"].ToString();
            userList.Add(user);
        }
        await _context.UserCollection.AddRangeAsync(userList);
        await _context.SaveChangesAsync();
    }

    public async Task PopulateStory(DataTable storyDataTable)
    {
        List<Story> storyList = new List<Story>();
        for (int i = 0; i < storyDataTable.Rows.Count; i++)
        {
            Story story = new Story();
            story.Caption = storyDataTable.Rows[i]["Caption"].ToString();
            story.MediaUrl = storyDataTable.Rows[i]["MediaUrl"].ToString();
            story.IsCloseFriendsOnly = Convert
                .ToBoolean(storyDataTable.Rows[i]["IsCloseFriendsOnly"].ToString());
            story.UserId = Convert
                .ToInt32(storyDataTable.Rows[i]["UserId"].ToString());
            storyList.Add(story);
        }
        await _context.StoryCollection.AddRangeAsync(storyList);
        await _context.SaveChangesAsync();
    }

    public async Task PopulateComment(DataTable commentDataTable)
    {
        List<Comment> commentList = new List<Comment>();
        for (int i = 0; i < commentDataTable.Rows.Count; i++)
        {
            Comment comment = new Comment();
            comment.Text = commentDataTable.Rows[i]["Text"].ToString();
            comment.UserId = Convert
                .ToInt32(commentDataTable.Rows[i]["UserId"].ToString());
            comment.StoryId = Convert
                .ToInt32(commentDataTable.Rows[i]["StoryId"].ToString());
            commentList.Add(comment);
        }
        await _context.CommentCollection.AddRangeAsync(commentList);
        await _context.SaveChangesAsync();
    }

    public async Task PopulateReaction(DataTable reactionDataTable)
    {
        List<Reaction> reactionList = new List<Reaction>();
        for (int i = 0; i < reactionDataTable.Rows.Count; i++)
        {
            Reaction reaction = new Reaction();
            reaction.Type = (Reaction.ReactionType)Convert
                .ToInt32(reactionDataTable.Rows[i]["Type"].ToString());
            reaction.UserId = Convert
                .ToInt32(reactionDataTable.Rows[i]["UserId"].ToString());
            reaction.StoryId = Convert
                .ToInt32(reactionDataTable.Rows[i]["StoryId"].ToString());
            reactionList.Add(reaction);
        }
        await _context.ReactionCollection.AddRangeAsync(reactionList);
        await _context.SaveChangesAsync();
    }
}
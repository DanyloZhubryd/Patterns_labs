using System.Data;

namespace Instagram.Interfaces;

public interface IPopulateDbService
{
    Task PopulateUser(DataTable userDataTable);
    Task PopulateStory(DataTable storyDataTable);
    Task PopulateComment(DataTable commentDataTable);
    Task PopulateReaction(DataTable reactionDataTable);
} 
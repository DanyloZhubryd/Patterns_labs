// using instagram_story.Repository;
// using instagram_story.Entities;
// using Microsoft.EntityFrameworkCore;

// namespace instagram_story.Services;

// public class MediaService : IMediaService
// {
//     private readonly StoryContext _context;

//     public MediaService(StoryContext context)
//     {
//         _context = context;
//     }
//     public async Task<Media?> FindMediaById(int id) => await _context.MediaCollection.FindAsync(id);

//     public async Task<Media?> FindMediaByStoryId(int storyId)
//     {
//         var media = await _context.MediaCollection
//             .FirstOrDefaultAsync(x => x.Story.Id == storyId) ?? null; ;
//         return media;
//     }

//     public async Task CreateMedia(Media media)
//     {
//         await _context.MediaCollection.AddAsync(media);
//         await _context.SaveChangesAsync();
//     }

//     public async Task<Media?> UpdateMedia(int id, Media updatedMedia)
//     {
//         var media = await FindMediaById(id);
//         if (media is null)
//             return null;

//         media.update(updatedMedia);
//         await _context.SaveChangesAsync();
//         return media;
//     }
// }
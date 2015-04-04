using PathFinder.Core.Filesystem;
using PathFinder.WinForms.App;

namespace PathFinder.WinForms.Tracking
{
    public static class Trackers
    {
        public static IGenericRepository<IFileFolderInfo> PopularFoldersTracker = new FavoritesRepository(Workspace.AppTempPath("popular-folders.json"));
        public static IGenericRepository<IFileFolderInfo> HistoryTracker = new HistoryRepository(Workspace.AppTempPath("folder-history.json"));
    }
}

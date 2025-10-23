namespace LibraryManagementSystem.Services
{
    using LibraryManagementSystem.Core;

    public interface IDataService
    {
        void Save(LibraryData data);
        LibraryData Load();
    }
}
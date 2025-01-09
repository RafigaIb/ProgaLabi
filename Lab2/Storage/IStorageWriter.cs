namespace Lab1.Storage;

public interface IStorageWriter
{
    public Task SaveCommandAsync(string command);
    public Task ClearFileAsync();
}
public interface ISaveable<T>
{
    T GetData();
    void SetData(T data);
}
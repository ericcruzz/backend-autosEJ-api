namespace AutosEJ.Models.Interfaces
{
    public interface IDataAccessObject
    {
        List<T> GetList<T>();
        T GetById<T>();
    }
}

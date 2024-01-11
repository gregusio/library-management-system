namespace library_management_system.Database;

public class UpdateDb
{
    private readonly Data _db = Data.GetInstance();

    public void SaveChanges()
    {
        _db.SaveChanges();
    }
}
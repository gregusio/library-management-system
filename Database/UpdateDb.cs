namespace library_management_system.Database;

public class UpdateDb(Data db)
{
    public void SaveChanges()
    {
        db.SaveChanges();
    }
}
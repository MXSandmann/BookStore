namespace Domain.Base
{
    public interface IAuditableEntity
    {

        void Create(int createdBy);
        void Update(int updatedBy);
    }
}

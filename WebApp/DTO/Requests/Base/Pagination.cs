namespace WebApp.DTO.Requests.Base
{
    public abstract class Pagination
    {
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 100;
    }
}

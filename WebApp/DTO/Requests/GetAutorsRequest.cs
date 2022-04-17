using WebApp.DTO.Requests.Base;

namespace WebApp.DTO.Requests
{
    public class GetAutorsRequest : Pagination
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}

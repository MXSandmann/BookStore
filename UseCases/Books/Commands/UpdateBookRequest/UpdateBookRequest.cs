using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace UseCases.Books.Commands.UpdateBookRequest
{
    public class UpdateBookRequest : IRequest<int>
    {
        public UpdateBookRequest(int id, string title, double price, int pagesCount, int year)
        {
            ID = id;
            Title = title;
            Price = price;
            PagesCount = pagesCount;
            Year = year;
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        public int PagesCount { get; set; }
        public int Year { get; set; }
    }
}

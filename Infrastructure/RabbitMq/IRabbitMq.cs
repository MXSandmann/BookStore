using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RabbitMq
{
    public interface IRabbitMq 
    {
        void SendMessage(string exchange, string key, string message);
        
    }
}

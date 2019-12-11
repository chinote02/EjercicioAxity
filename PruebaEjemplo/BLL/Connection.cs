using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Connection
    {
        //Por motivos del ejercicio, se deja así la conexión, en realidad deberia implementarse de otra manera
        public string ConnectionString { get; } = "Data Source=examen-server.database.windows.net,1433;Initial Catalog=ExamAxity;User ID=AxityAdm;Password=Axity&2019w2";
        public string Query { get; set; }
        public Object Params { get; set; }
    }
}

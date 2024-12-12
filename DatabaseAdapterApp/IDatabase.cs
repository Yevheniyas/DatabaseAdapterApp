using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAdapterApp
{
    public interface IDatabase
    {
        void Connect(); // Підключення до бази даних
        void Disconnect(); // Відключення від бази даних
        string FetchData(); // Отримання даних з бази
    }
}

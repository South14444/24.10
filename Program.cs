using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;

namespace EntityFramework.Classes
{

    partial class Program
    {
        static void Main(string[] args)
        {
            using (Context context = new Context())
            {
                context.SaveChanges();
                context.GetAllGames();//с вытягиванием данных чета не получилось
            }
        }
    }
}

using Data.Models;
using Inferastructure.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inferastructure.services
{
    public class UnitOfWork :IunitOfWork
    {
        public JournalDbcontext Context { get; }

        public UnitOfWork(JournalDbcontext context)
        {
            Context = context;
        }
        public void Commit()
        {
            Context.SaveChanges();
        }

        //public void Dispose()
        //{
        //    Context.Dispose();

        //}

    }
}

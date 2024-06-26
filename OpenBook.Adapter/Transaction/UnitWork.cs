﻿using OpenBook.App.Data.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBook.Adapter.Transaction
{
    public class UnitWork : IUnitWork
    {
        OpenBookContext context;
        public UnitWork(OpenBookContext context)
        {
            this.context = context;
        }
        public async Task Commit()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An exception occurred in UnitWork. Internal error.\n Error message:{ex.Message.ToString()}\n" +
                    $"Inner ex message: {ex.InnerException.Message.ToString()}");
            }
        }

        public void Rollback()
        {

        }
    }
}

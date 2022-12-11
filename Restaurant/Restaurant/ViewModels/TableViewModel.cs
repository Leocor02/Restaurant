using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.ViewModels
{
    public class TableViewModel : BaseViewModel
    {
        public Table MyTable { get; set; }
        public TableViewModel() {
        MyTable = new Table();
        }

        public async Task<bool> AddNewTable(int idFloor, int chairQuantity)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyTable.Floor = idFloor;
                MyTable.ChairQuantity = chairQuantity;

                bool R = await MyTable.AddTable();

                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}

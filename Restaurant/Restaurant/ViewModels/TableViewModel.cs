using Restaurant.Models;
using Restaurant.Models.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.ViewModels
{
    public class TableViewModel : BaseViewModel
    {
        public Table MyTable { get; set; }

        public TableDTO MyTableDTO { get; set; }
        public TableViewModel() {
        MyTable = new Table();
        MyTableDTO = new TableDTO();
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

        public async Task<ObservableCollection<TableDTO>> GetTablesList()
        {
            if (IsBusy)
            {
                return null;
            }
            else
            {
                IsBusy = true;

                try
                {
                    ObservableCollection<TableDTO> list = new ObservableCollection<TableDTO>();

                    list = await MyTableDTO.GetTablesList();

                    if (list == null)
                    {
                        return null;
                    }

                    return list;

                }
                catch (Exception)
                {
                    return null;
                }
                finally { IsBusy = false; }

            }





        }
    }
}

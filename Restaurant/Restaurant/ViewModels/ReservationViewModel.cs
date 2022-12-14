using Restaurant.Models;
using Restaurant.Models.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.ViewModels
{
   
    public class ReservationViewModel : BaseViewModel
    {
        public Reservation MyReservation { get; set; }

        public ReservationDTO MyReservationDTO { get; set; }

        public ReservationViewModel() { 
        MyReservation = new Reservation();
        MyReservationDTO = new ReservationDTO();
        }

        public async Task<bool> AddNewReservation(DateTime date,int dinnersQuantity,int idTable)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyReservation.Date = date;
                MyReservation.DinersQuantity= dinnersQuantity;
                MyReservation.Iduser = GlobalItems.GlobalUser.Iduser;
                MyReservation.Idtable= idTable;

                bool R = await MyReservation.AddReservation();

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

        public async Task<ObservableCollection<ReservationDTO>> GetAllReservationsList(bool listUserReservationsOnly)
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
                    ObservableCollection<ReservationDTO> list = new ObservableCollection<ReservationDTO>();

                    if (!listUserReservationsOnly) {
                        list = await MyReservationDTO.GetAllReservationsList();
                    }
                    else
                    {
                        list = await MyReservationDTO.GetUserReservationsList();
                    }
                    

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

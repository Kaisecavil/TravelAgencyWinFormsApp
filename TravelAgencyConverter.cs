using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyRepository.Models;

namespace TravelAgencyWinFormsApp
{
    public static class TravelAgencyConverter
    {
        public static List<int> DataGridToId(DataGridViewSelectedRowCollection rows)
        {
            List<int> list = new List<int>();
            foreach (DataGridViewRow row in rows)
            {
                list.Add(Convert.ToInt32(row.Cells[0].Value));
            }
            return list;
        }
        public static List<Client> DataGridViewSelctedRowsToClientList(DataGridViewSelectedRowCollection rows)
        {
            List<Client> list = new List<Client>();
            foreach (DataGridViewRow row in rows)
            {
                list.Add(new Client(Convert.ToInt32(row.Cells[0].Value)
                    , Convert.ToString(row.Cells[1].Value)
                    , Convert.ToString(row.Cells[2].Value)
                    , Convert.ToString(row.Cells[3].Value)
                    , Convert.ToString(row.Cells[4].Value)));
            }
            return list;
        }

        public static List<TourSale> DataGridViewSelctedRowsToTourSaleList(DataGridViewSelectedRowCollection rows)
        {
            List<TourSale> list = new List<TourSale>();
            foreach (DataGridViewRow row in rows)
            {
                list.Add(new TourSale(Convert.ToInt32(row.Cells[0].Value)
                    , Convert.ToDateTime(row.Cells[1].Value)
                    , Convert.ToDateTime(row.Cells[2].Value)
                    , Convert.ToInt32(row.Cells[3].Value)
                    , Convert.ToDecimal(row.Cells[4].Value)
                    , Convert.ToInt32(row.Cells[5].Value)
                    , Convert.ToInt32(row.Cells[6].Value)
                    , Convert.ToInt32(row.Cells[7].Value)
                    , Convert.ToInt32(row.Cells[8].Value)));
            }
            return list;
        }

        public static List<TransportKind> DataGridViewSelctedRowsToTransportKindList(DataGridViewSelectedRowCollection rows)
        {
            List<TransportKind> list = new List<TransportKind>();
            foreach (DataGridViewRow row in rows)
            {
                list.Add(new TransportKind(Convert.ToInt32(row.Cells[0].Value)
                    , Convert.ToString(row.Cells[1].Value)));
            }
            return list;
        }
    }
}

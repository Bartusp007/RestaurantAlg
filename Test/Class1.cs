using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar.Data.Infrastructure;
using Calendar.Data.Repositories;
using Calendar.Model;

namespace Test
{
    public class Class1
    {
        readonly IReservationsRepository _reservationsRepository;
        private IUnitOfWork _unitOfWork;
        private ITableRepositorycs _tableRepositorycs;
        public Class1(ReservationsRepository reservationsRepository, IUnitOfWork unitOfWork, ITableRepositorycs tableRepositorycs)
        {
            this._reservationsRepository = reservationsRepository;
            this._unitOfWork = unitOfWork;
            _tableRepositorycs = tableRepositorycs;
        }


        public void Update()
        {




            Reservations reservation = new Reservations
            {
                Email = "xyz",
                FromWhatTime= new TimeSpan(12,0,0),
                ToWhatTime = new TimeSpan(12,30,0),
                HowManyPeoples= 4,
                Name="Bartek",
                PhoneNumber="781198338",
                ReservationDate=new DateTime(2018,09,4),
                Surname="Pancerski",
            };

            Tables tables1 = _tableRepositorycs.GetAll().FirstOrDefault(w => w.TableId == "T1C2");
            Tables tables2 = _tableRepositorycs.GetAll().FirstOrDefault(w => w.TableId == "T2C2");
      
            List<Tables> tableList= new List<Tables>();

            tableList.Add(tables1);
            tableList.Add(tables2);
            reservation.Table = tableList;
            _reservationsRepository.Add(reservation, tableList);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

    }
}

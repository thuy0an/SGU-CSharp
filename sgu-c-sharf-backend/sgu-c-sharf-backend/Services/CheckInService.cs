using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgu_c_sharf_backend.Models.ThanhVien;
using sgu_c_sharf_backend.Repositories;

namespace sgu_c_sharf_backend.Services
{
    public class CheckInService
    {
        public readonly CheckInRepository _checkInRepository;

        public CheckInService(CheckInRepository checkInRepository)
        {
            _checkInRepository = checkInRepository;
        }

        public List<CheckIn> GetAll(int id)
        {
            return _checkInRepository.GetAll(id);
        }

        public bool Create(CheckIn checkIn)
        {
            return _checkInRepository.Create(checkIn);
        }
    }
}
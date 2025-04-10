using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgu_c_sharf_backend.Models.PhieuDatCho;
using sgu_c_sharf_backend.Repositories;
namespace sgu_c_sharf_backend.Services
{
    public class PhieuDatChoService
    {
        private readonly PhieuDatChoRepository _phieuDatChoRepository;

        public PhieuDatChoService(PhieuDatChoRepository phieuDatChoRepository)
        {
            _phieuDatChoRepository = phieuDatChoRepository;
        }

        public List<PhieuDatCho> GetAllNoPaging(){
            return _phieuDatChoRepository.GetAllPhieuDatChoNoPaging();
        }

        public PhieuDatCho? GetById(int id){
            return _phieuDatChoRepository.GetById(id);
        }
        public PhieuDatCho? AddPhieuDatCho(PhieuDatCho phieuDatCho){
            return _phieuDatChoRepository.Create(phieuDatCho);
        }
        public PhieuDatCho? UpdatePhieuDatCho(PhieuDatCho phieuDatCho){
            return _phieuDatChoRepository.Update(phieuDatCho);
        }
        public bool DeletePhieuDatCho(int id){
            return _phieuDatChoRepository.Delete(id); 
        }

    }
}
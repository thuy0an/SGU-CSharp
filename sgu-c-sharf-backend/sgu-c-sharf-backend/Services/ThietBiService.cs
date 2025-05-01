using System;
using System.Collections.Generic;
using sgu_c_sharf_backend.Models.ThietBi;
using sgu_c_sharf_backend.Repositories;

namespace sgu_c_sharf_backend.Services
{
    public class ThietBiService
    {
        private readonly ThietBiRepository _thietBiRepository;

        public ThietBiService(ThietBiRepository thietBiRepository)
        {
            _thietBiRepository = thietBiRepository;
        }

        public ThietBiDetailDTO GetById(int id)
        {
            var thietBi = _thietBiRepository.GetById(id);
            if (thietBi == null)
                throw new Exception("Thiết bị không tồn tại.");
            return thietBi;
        }

        public IEnumerable<ThietBiListDTO> GetAll()
        {
            return _thietBiRepository.GetAll();
        }

        public void Add(ThietBiCreateForm form)
        {
            _thietBiRepository.Add(form);
        }

        public void ThemDauThietBi(int idThietBi, int soLuong)
        {
            _thietBiRepository.ThemDauThietBi(idThietBi, soLuong);
        }


        public void Update(int id, ThietBiUpdateForm form)
        {
            _thietBiRepository.Update(id, form);
        }

        public void Delete(int id)
        {
            _thietBiRepository.Delete(id);
        }

        public IEnumerable<ThietBiListDTO> Search(string tenThietBi, int? idLoaiThietBi)
        {
            return _thietBiRepository.Search(tenThietBi, idLoaiThietBi);
        }
        public IEnumerable<DauThietBiListDTO> GetDauThietBiByThietBiId(int idThietBi)
        {
            // Kiểm tra thiết bị có tồn tại không
            var thietBi = _thietBiRepository.GetById(idThietBi);
            if (thietBi == null)
                throw new Exception("Thiết bị không tồn tại hoặc đã bị xóa.");

            return _thietBiRepository.GetDauThietBiByThietBiId(idThietBi);
        }

        public List<ThietBiListAvailabilityDTO> GetAllWithAvailability(){
            return _thietBiRepository.GetAllWithAvailability();
        }
    }
}
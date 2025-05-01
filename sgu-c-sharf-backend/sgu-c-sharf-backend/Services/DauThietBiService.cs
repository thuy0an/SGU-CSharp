using System;
using System.Collections.Generic;
using sgu_c_sharf_backend.Models.ThietBi;
using sgu_c_sharf_backend.Repositories;

namespace sgu_c_sharf_backend.Services
{
    public class DauThietBiService
    {
        private readonly DauThietBiRepository _dauThietBiRepository;

        public DauThietBiService(DauThietBiRepository dauThietBiRepository)
        {
            _dauThietBiRepository = dauThietBiRepository;
        }

        public DauThietBiDetailResponseDto GetById(int id)
        {
            var dauThietBi = _dauThietBiRepository.GetById(id);
            if (dauThietBi == null)
                throw new Exception("Đầu thiết bị không tồn tại.");
            return dauThietBi;
        }

        public IEnumerable<DauThietBiListDTO> GetAll()
        {
            return _dauThietBiRepository.GetAll();
        }

        public void Add(DauThietBiCreateForm form)
        {
            _dauThietBiRepository.Add(form);
        }

        public void Update(int id, DauThietBiUpdateForm form)
        {
            _dauThietBiRepository.Update(id, form);
        }

        public void Delete(int id)
        {
            _dauThietBiRepository.Delete(id);
        }

        public IEnumerable<DauThietBiListDTO> Search(int? idThietBi, string trangThai)
        {
            return _dauThietBiRepository.Search(idThietBi, trangThai);
        }

        public List<DauThietBiListDTO> GetDauThietBiByIdVaSoLuong(int idThietBi, int soLuong){
            return _dauThietBiRepository.GetDauThietBiByIdVaSoLuong(idThietBi, soLuong);
        }

        public bool UpdateDanhSachDauThietBi(List<DauThietBiListDTO> dauThietBiList)
        {
            return _dauThietBiRepository.UpdateDanhSachDauThietBi(dauThietBiList);
        }
    }
}
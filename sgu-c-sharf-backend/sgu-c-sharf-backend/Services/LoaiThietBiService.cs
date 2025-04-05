using sgu_c_sharf_backend.ApiResponse;
using sgu_c_sharf_backend.Models.LoaiThietBi;
using sgu_c_sharf_backend.Models.ThietBi;
using sgu_c_sharf_backend.Repositories;

namespace sgu_c_sharf_backend.Services;

public class LoaiThietBiService
{
    private readonly LoaiThietBiRepository _loaiThietBiRepository;

    public LoaiThietBiService(LoaiThietBiRepository loaiThietBiRepository)
    {
        _loaiThietBiRepository = loaiThietBiRepository;
    }

    public List<LoaiThietBi> GetNoPaging()
    {
        return _loaiThietBiRepository.GetAllLoaiThietBiNoPaging();
    }
    
    public PagedResult<LoaiThietBi> GetAll(int pageNumber, int pageSize, string? search, string? sortBy, string? sortDirection)
    {
        return _loaiThietBiRepository.GetAllLoaiThietBi(pageNumber, pageSize, search, false, sortBy, sortDirection);
    }
    
    public LoaiThietBi? GetById(int id)
    {
        return _loaiThietBiRepository.GetById(id);
    }
    
    public LoaiThietBi? AddLoaiThietBi(LoaiThietBi loaiThietBi)
    {
        // Gọi Repository để thêm mới thành viên
        return _loaiThietBiRepository.Create(loaiThietBi);
    }
        
    public LoaiThietBi? CapNhatLoaiThietBi(LoaiThietBi loaiThietBi)
    {
        // Gọi Repository để thêm mới thành viên
       return _loaiThietBiRepository.Update(loaiThietBi);
    }

    public void XoaLoaiThietBi(int id)
    {
        _loaiThietBiRepository.Delete(id); 
    }
    
    
}
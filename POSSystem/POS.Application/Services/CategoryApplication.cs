using AutoMapper;
using POS.Application.Commons.Base;
using POS.Application.Dtos.Request;
using POS.Application.Dtos.Response;
using POS.Application.Interfaces;
using POS.Application.Validators.Category;
using POS.Infraestructure.Commons.Bases.Request;
using POS.Infraestructure.Commons.Bases.Response;
using POS.Infraestructure.Persistences.Interfaces;

namespace POS.Application.Services
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CategoryValidator _validationRules;

        public CategoryApplication(IUnitOfWork unitOfWork, IMapper mapper, CategoryValidator validationRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public Task<BaseResponse<CategoryResponseDto>> CategoryById(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> EditCategory(int categoryId, CategoryRequestDto requestDto)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<BaseEntitiyResponse<CategoryResponseDto>>> ListCategories(BaseFilterRequest filters)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<CategorySelectResponseDto>>> ListSelectCategories()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> RegisterCategory(CategoryRequestDto requestDto)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> RemoveCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}

﻿using POS.Application.Commons.Base;
using POS.Application.Dtos.Request;
using POS.Application.Dtos.Response;
using POS.Infraestructure.Commons.Bases.Request;
using POS.Infraestructure.Commons.Bases.Response;

namespace POS.Application.Interfaces
{
    public interface ICategoryApplication
    {
        Task<BaseResponse<BaseEntitiyResponse<CategoryResponseDto>>> ListCategories(BaseFilterRequest filters);

        Task<BaseResponse<IEnumerable<CategorySelectResponseDto>>> ListSelectCategories();

        Task<BaseResponse<CategoryResponseDto>> CategoryById(int categoryId);

        Task<BaseResponse<bool>> RegisterCategory(CategoryRequestDto requestDto);

        Task<BaseResponse<bool>> EditCategory(int categoryId, CategoryRequestDto requestDto);

        Task<BaseResponse<bool>> RemoveCategory(int categoryId);
    }
}
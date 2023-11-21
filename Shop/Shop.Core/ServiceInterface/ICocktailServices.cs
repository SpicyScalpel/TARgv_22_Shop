using Shop.Core.Dto.CoctailsDtos;
using Shop.Core.Dto.OpenWeatherDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.ServiceInterface
{
    public interface ICocktailServices
    {
        Task<CocktailResultDto> GetCocktails(CocktailResultDto dto);
    }
}

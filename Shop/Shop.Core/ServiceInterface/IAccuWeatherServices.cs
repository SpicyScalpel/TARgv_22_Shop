using Shop.Core.Dto.AccuWeatherDtos;

namespace Shop.Core.ServiceInterface
{
    public interface IAccuWeatherServices
    {
        public Task<AccuWeatherResultDto> AccuWeatherResult(AccuWeatherResultDto dto);
    }
}
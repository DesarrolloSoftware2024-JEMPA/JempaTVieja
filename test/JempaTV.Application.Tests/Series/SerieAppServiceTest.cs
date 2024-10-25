using JempaTV.Califications;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Modularity;
using Xunit;

namespace JempaTV.Series
{
    public abstract class SerieAppServiceTests<TStartupModule> : JempaTVApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
    {
        private readonly SerieAppService _serieAppService;

        protected SerieAppServiceTests()
        {
            _serieAppService = GetRequiredService<SerieAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Califications()
        {
            //Arrange
            Guid Usuario = Guid.Parse("8802F6C4-043C-8EC2-6B82-3A15AE64EEF4");

            //Act
            
            var result = await _serieAppService.GetCalificationsAsync(Usuario);

            //Assert
            result.ShouldNotBeNull();
        }
    }
}

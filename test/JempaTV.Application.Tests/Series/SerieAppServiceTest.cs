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
            int Usuario = 9324823;

            //Act
            var result = await _serieAppService.GetCalificationsAsync(Usuario);

            //Assert
            result.ShouldContain(c => c.IdUsuario == Usuario);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Xunit;
using Shouldly;

namespace JempaTV.Califications
{
    public abstract class CalificationAppServiceTest<TStartupModule> : JempaTVApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
    {
        private readonly CalificationAppService _calificationAppService;


        protected CalificationAppServiceTest()
        {
            _calificationAppService = GetRequiredService<CalificationAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Califications()
        {
            //Arrange
            string Usuario = "8802F6C4-043C-8EC2-6B82-3A15AE64EEF4";

            //Act
            var result = await _calificationAppService.GetCalificationsAsync(Usuario);

            //Assert
            result.ShouldContain(b => b.IdUsuario == Usuario);
        }

    }
}

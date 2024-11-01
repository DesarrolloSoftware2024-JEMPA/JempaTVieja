using JempaTV.Series;
using Xunit;

namespace JempaTV.EntityFrameworkCore.Applications.Series;

[Collection(JempaTVTestConsts.CollectionDefinitionName)]
public class EfCoreSerieServiceTests : SerieAppServiceTests<JempaTVEntityFrameworkCoreTestModule>
{

}

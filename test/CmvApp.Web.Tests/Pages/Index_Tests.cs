using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace CmvApp.Pages;

public class Index_Tests : CmvAppWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}

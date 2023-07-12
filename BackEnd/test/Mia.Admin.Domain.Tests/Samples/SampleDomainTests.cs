using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Mia.Admin.Samples;

/* This is just an example test class.
 * Normally, you don't test code of the modules you are using
 * (like IdentityUserManager here).
 * Only test your own domain services.
 */
[Collection(MiaTestConsts.CollectionDefinitionName)]
public class SampleDomainTests : MiaDomainTestBase
{
    public SampleDomainTests()
    {
       
    }


}

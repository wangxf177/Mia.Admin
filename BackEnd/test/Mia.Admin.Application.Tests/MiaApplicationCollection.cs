using Mia.Admin.MongoDB;
using Xunit;

namespace Mia.Admin;

[CollectionDefinition(MiaTestConsts.CollectionDefinitionName)]
public class MiaApplicationCollection : MiaMongoDbCollectionFixtureBase
{

}

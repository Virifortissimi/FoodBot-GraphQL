using FoodBotGqlApi.Models;
using HotChocolate.Types;

namespace FoodBotGqlApi.GraphQl.Preparations
{
    public class AddPreparationPayloadType : ObjectType<AddPreparationPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<AddPreparationPayload> descriptor)
        {
            descriptor.Description("Represents the payload to return for an added preparation.");

            descriptor
                .Field(c => c.Preparation)
                .Description("Represents the added preparation.");

            base.Configure(descriptor);
        }
    };
}
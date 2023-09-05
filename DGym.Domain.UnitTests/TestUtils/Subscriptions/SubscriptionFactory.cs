using DGym.Domain.SubscriptionAggregate;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Constants = DGym.Domain.UnitTests.TestConstants.Constants;

namespace DGym.Domain.UnitTests.TestUtils.Subscriptions;

public class SubscriptionFactory
{
    public static Subscription CreateSubscription(
        SubscriptionType? subscriptionType = null,
        Guid? adminId = null,
        Guid? id = null)
    {
        return new Subscription(
            subscriptionType: subscriptionType ?? Constants.Subscriptions.DefaultSubscriptionType,
            adminId: Constants.Admin.Id,
            id ?? Constants.Subscriptions.Id);
    }
}
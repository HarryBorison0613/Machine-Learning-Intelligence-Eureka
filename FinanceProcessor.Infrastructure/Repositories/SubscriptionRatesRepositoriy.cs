using FinanceProcessor.Core.Aggregates.Customer.Enums;
using FinanceProcessor.Core.Aggregates.Customer.Models;
using FinanceProcessor.Core.Aggregates.Customer.Repository;
using FinanceProcessor.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinanceProcessor.Infrastructure.Repositories
{
    public class SubscriptionRatesRepositoriy : ISubscriptionRatesRepositoriy
    {
        private readonly FinanceContext _financeContext;
        private readonly ILogger<UserRepository> _logger;

        public SubscriptionRatesRepositoriy(FinanceContext financeContext,
            ILogger<UserRepository> logger)
        {
            _financeContext = financeContext;
            _logger = logger;
        }

        public /*async Task*/void AddRoleRate(SubscriptionRates rates)
        {
            try
            {
                /*await*/ _financeContext.Set<SubscriptionRates>().Add/*Async*//*<SubscriptionRates>*/(rates);
                /*await*/ _financeContext.SaveChanges();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Edding subscription rates has faild: {ex}");
                return;
            }
        }

        public /*async Task<*/IEnumerable<SubscriptionRates> GetRoleRate()
        {
            try
            {
                return /*await*/ _financeContext.SubscriptionRates.ToList/*Async*/();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Getting subscription rates has faild: {ex}");
                return Enumerable.Empty<SubscriptionRates>();
            }
        }

        public /*async Task*/void FeelRoleRateTable()
        {
            var rates = /*await*/ GetRoleRate();//new List<SubscriptionRates>();
            if (!rates.Any(x => x.UserRoleNume == (int)UserRole.BasicUser))
            {
                var basePrice = new SubscriptionRates
                {
                    UserRoleName = UserRole.BasicUser.ToString(),
                    UserRoleNume = (int)UserRole.BasicUser,
                    IntervalUnit = "MONTH",
                    //Period = TimeSpan.FromDays(30),
                    SubscriptionPrice = 30,
                    // = TimeSpan.FromDays(365),
                    TotalCycles = 12
                };
                /*await*/ AddRoleRate(basePrice);
            }

            if (!rates.Any(x => x.UserRoleNume == (int)UserRole.ProfessionalUser))
            {
                var professionalPrice = new SubscriptionRates
                {
                    UserRoleName = UserRole.ProfessionalUser.ToString(),
                    UserRoleNume = (int)UserRole.ProfessionalUser,
                    IntervalUnit = "MONTH",
                    //Period = TimeSpan.FromDays(30),
                    SubscriptionPrice = 60,
                    //TotalPeriod = TimeSpan.FromDays(365),
                    TotalCycles = 12,
                };
                /*await*/ AddRoleRate(professionalPrice);
            }

            if (!rates.Any(x => x.UserRoleNume == (int)UserRole.ExpertUser))
            {
                var expertPrice = new SubscriptionRates
                {
                    UserRoleName = UserRole.ExpertUser.ToString(),
                    UserRoleNume = (int)UserRole.ExpertUser,
                    IntervalUnit = "MONTH",
                    //Period = TimeSpan.FromDays(30),
                    SubscriptionPrice = 90,
                    //TotalPeriod = TimeSpan.FromDays(365),
                    TotalCycles = 12,
                };
                /*await*/ AddRoleRate(expertPrice);
            }
        }
    }
}

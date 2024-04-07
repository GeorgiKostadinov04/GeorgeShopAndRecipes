using GeorgeShopAndRecipe.Core.Models.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgeShopAndRecipe.Core.Contracts
{
    public interface IStatisticService
    {
        Task<StatisticsServiceModel> TotalAsync();
    }
}

using FinanceProcessor.Core.Aggregates.Customer.Enums;

namespace FinanceProcessor.Core.Aggregates.Customer.DTOs
{
    public class FilterUsersDto
    {
        public int UserCount = 20;
        public int PageNumber = 1;
        public int MinAge = 0;
        public int MaxAge = 150;
        public string SearchingSubstring = "";
        public SearchingType SearchingType = SearchingType.SearchingByLastName;
    }
}

using FinanceProcessor.Core.Models;

namespace FinanceProcessor.Static
{
	public static class Sectors
	{
		static readonly List<SectorDto> SectorList = new List<SectorDto>
		{
			new SectorDto { Name = "Energy Minerals" },
			new SectorDto { Name = "Electronic Technology" },
			new SectorDto { Name = "Real Estate and Rental and Leasing" },
			new SectorDto { Name = "Non-Energy Minerals" },
			new SectorDto { Name = "Other Services (except Public Administration)" },
			new SectorDto { Name = "Retail Trade" },
			new SectorDto { Name = "Communications" },
			new SectorDto { Name = "Arts, Entertainment, and Recreation" },
			new SectorDto { Name = "Transportation and Warehousing" },
			new SectorDto { Name = "Consumer Services" },
			new SectorDto { Name = "Wholesale Trade" },
			new SectorDto { Name = "Health Services" },
			new SectorDto { Name = "Information" },
			new SectorDto { Name = "Agriculture, Forestry, Fishing and Hunting" },
			new SectorDto { Name = "Educational Services" },
			new SectorDto { Name = "Public Administration" },
			new SectorDto { Name = "Health Care and Social Assistance" },
			new SectorDto { Name = "Utilities" },
			new SectorDto { Name = "Consumer Non-Durables" },
			new SectorDto { Name = "Commercial Services" },
			new SectorDto { Name = "Process Industries" },
			new SectorDto { Name = "Distribution Services" },
			new SectorDto { Name = "Finance and Insurance" },
			new SectorDto { Name = "Industrial Services" },
			new SectorDto { Name = "Administrative and Support and Waste Management and Remediation Services" },
			new SectorDto { Name = "Manufacturing" },
			new SectorDto { Name = "Transportation" },
			new SectorDto { Name = "Mining, Quarrying, and Oil and Gas Extraction" },
			new SectorDto { Name = "Technology Services" },
			new SectorDto { Name = "Miscellaneous" },
			new SectorDto { Name = "Finance" },
			new SectorDto { Name = "Consumer Durables" },
			new SectorDto { Name = "Producer Manufacturing" },
			new SectorDto { Name = "Construction" },
			new SectorDto { Name = "Accommodation and Food Services" },
			new SectorDto { Name = "Health Technology" },
			new SectorDto { Name = "Professional, Scientific, and Technical Services" },
			new SectorDto { Name = "Management of Companies and Enterprises" },
			new SectorDto { Name = "Government" } };

		public static List<SectorDto> GetList() => SectorList; 
	}
}

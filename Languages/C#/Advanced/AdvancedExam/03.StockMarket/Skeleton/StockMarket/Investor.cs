using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new Dictionary<string, Stock>();
        }

        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        public decimal MoneyToInvest { get; set; }

        public string BrokerName { get; set; }

        public Dictionary<string, Stock> Portfolio { get; set; }

        public int Count => Portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (!Portfolio.ContainsKey(stock.CompanyName) &&
                stock.MarketCapitalization > 10000 &&
                MoneyToInvest >= stock.PricePerShare)
            {
                Portfolio.Add(stock.CompanyName, stock);
                MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!Portfolio.ContainsKey(companyName))
            {
                return $"{companyName} does not exist.";
            }
            else
            {
                if (sellPrice < Portfolio[companyName].PricePerShare)
                {
                    return $"Cannot sell {companyName}.";
                }
                else
                {
                    Portfolio.Remove(companyName);
                    MoneyToInvest += sellPrice;
                    return $"{companyName} was sold.";
                }
            }
        }

        public Stock FindStock(string companyName)
        {
            if (Portfolio.ContainsKey(companyName))
            {
                return Portfolio[companyName];
            }

            return null;
        }

        public Stock FindBiggestCompany()
        {
            return Portfolio.OrderByDescending(s => s.Value.MarketCapitalization).FirstOrDefault().Value;
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");

            foreach (var stock in Portfolio)
            {
                sb.AppendLine(stock.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

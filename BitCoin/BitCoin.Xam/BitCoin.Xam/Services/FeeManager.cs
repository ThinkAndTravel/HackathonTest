using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitCoin.Xam.Services
{
    /// <summary>
    /// Returns fee of specified operation
    /// </summary>
    public static class FeeManager
    {
        public static double DefaultBtcFee = 0.000495;

        /// <summary>
        /// Returns withdraw fee
        /// </summary>
        public static class Withdraw
        {
            public static double WithdrawBtc(double amount, string from)
            {
                double res = 0;

                switch (from.Trim().ToLowerInvariant())
                {
                    case "bitstamp":
                        {
                            res = 0.0;
                            break;
                        }
                    case "bitfinex":
                        {
                            res = 0.0008;
                            break;
                        }
                    case "kraken":
                        {
                            res = 0.001;
                            break;
                        }
                    default:
                        throw new Exception("Unexpected `from` value");
                }

                return res + DefaultBtcFee;
            }

            public static double WithdrawUsd(double amount, string from)
            {
                double res = 0;

                switch (from.Trim().ToLowerInvariant())
                {
                    case "bitstamp":
                        {
                            res = (amount <= 1000.0 ? 10.0 : amount * 0.002);
                            break;
                        }
                    case "bitfinex":
                        {
                            res = Math.Max(20.0, amount * 0.001);
                            break;
                        }
                    case "kraken":
                        {
                            res = 60.0;
                            break;
                        }
                    default:
                        throw new Exception("Unexpected `from` value");
                }

                return res;
            }
        }

        /// <summary>
        /// Returns deposit fee
        /// </summary>
        public static class Deposit
        {
            public static double DepositUsd(double amount, string to)
            {
                double res = 0;

                switch (to.Trim().ToLowerInvariant())
                {
                    case "bitstamp":
                        {
                            res = Math.Max(7.5, amount * 0.00005);
                            break;
                        }
                    case "bitfinex":
                        {
                            res = Math.Max(20.0, amount * 0.001);
                            break;
                        }
                    case "kraken":
                        {
                            res = 10.0;
                            break;
                        }
                    default:
                        throw new Exception("Unexpected `to` value");
                }

                return res;
            }

            public static double DepositBtc(double amount, string to)
            {
                double res = 0;

                switch (to.Trim().ToLowerInvariant())
                {
                    case "bitstamp":
                        {
                            res = 0.0;
                            break;
                        }
                    case "bitfinex":
                        {
                            res = 0.0;
                            break;
                        }
                    case "kraken":
                        {
                            res = 0.0;
                            break;
                        }
                    default:
                        throw new Exception("Unexpected `to` value");
                }

                return res + DefaultBtcFee;
            }
        }
    }
}
